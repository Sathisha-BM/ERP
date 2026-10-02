using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IInternetStatus_Service;

namespace V.SMART.Shared.BusinessLayer.BusinessService.InternetStatus_Service
{
    public sealed class InternetStatusService : IInternetStatusService, IAsyncDisposable
    {
        private readonly IJSRuntime _js;

        private CancellationTokenSource? _cts;
        private Task? _monitorTask;

        private bool _started;
        private bool _disposed;

        private readonly object _lock = new();

        public bool IsOnline { get; private set; }

        public double DownloadMbps { get; private set; }

        public double UploadMbps { get; private set; }

        public int LatencyMs { get; private set; }

        public DateTime LastChecked { get; private set; }

        public event Action? StatusChanged;

        public InternetStatusService(IJSRuntime js)
        {
            _js = js;
        }
        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                if (_started)
                    return Task.CompletedTask;

                _started = true;

                _cts = CancellationTokenSource.CreateLinkedTokenSource(
                    cancellationToken);

                _monitorTask = MonitorAsync(_cts.Token);
            }

            return Task.CompletedTask;
        }
        private async Task MonitorAsync(CancellationToken cancellationToken)
        {
            // Initial check immediately
            try
            {
                await CheckNowAsync(cancellationToken);
            }
            catch
            {
                // Do not crash the application
            }

            using var timer = new PeriodicTimer(
                TimeSpan.FromSeconds(60));

            try
            {
                while (await timer.WaitForNextTickAsync(
                    cancellationToken))
                {
                    try
                    {
                        await CheckNowAsync(cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch
                    {
                        // Network failures must not crash the application
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Normal shutdown
            }
        }
        public async Task CheckNowAsync(
        CancellationToken cancellationToken = default)
        {
            if (_disposed)
                return;

            try
            {
                var result =
                    await _js.InvokeAsync<InternetStatusResult>(
                        "vsmartInternetStatus.check",
                        cancellationToken);

                IsOnline = result.IsOnline;

                DownloadMbps = result.DownloadMbps;

                UploadMbps = result.UploadMbps;

                LatencyMs = result.LatencyMs;

                LastChecked = DateTime.Now;

                NotifyChanged();
            }
            catch (JSDisconnectedException)
            {
                // Blazor Server circuit disconnected
            }
            catch (OperationCanceledException)
            {
                // Normal cancellation
            }
            catch
            {
                // If JS/network check fails, consider offline
                IsOnline = false;

                DownloadMbps = 0;

                UploadMbps = 0;

                LatencyMs = 0;

                LastChecked = DateTime.Now;

                NotifyChanged();
            }
        }

        private void NotifyChanged()
        {
            try
            {
                StatusChanged?.Invoke();
            }
            catch
            {
                // Never allow UI event errors to break service
            }
        }

        public async Task StopAsync()
        {
            CancellationTokenSource? cts;

            lock (_lock)
            {
                if (!_started)
                    return;

                _started = false;

                cts = _cts;

                _cts = null;
            }

            if (cts == null)
                return;

            try
            {
                await cts.CancelAsync();

                if (_monitorTask != null)
                {
                    try
                    {
                        await _monitorTask;
                    }
                    catch (OperationCanceledException)
                    {
                    }
                }
            }
            finally
            {
                cts.Dispose();
                _monitorTask = null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed)
                return;

            _disposed = true;

            await StopAsync();

            StatusChanged = null;
        }

        private sealed class InternetStatusResult
        {
            public bool IsOnline { get; set; }

            public double DownloadMbps { get; set; }

            public double UploadMbps { get; set; }

            public int LatencyMs { get; set; }
        }
     
    }
}
