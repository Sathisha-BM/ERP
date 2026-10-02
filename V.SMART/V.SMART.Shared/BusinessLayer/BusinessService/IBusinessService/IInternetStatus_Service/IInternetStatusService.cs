using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IInternetStatus_Service
{
    public interface IInternetStatusService
    {
        bool IsOnline { get; }

        double DownloadMbps { get; }

        double UploadMbps { get; }

        int LatencyMs { get; }

        DateTime LastChecked { get; }

        event Action? StatusChanged;

        Task StartAsync(CancellationToken cancellationToken = default);

        Task StopAsync();

        Task CheckNowAsync(CancellationToken cancellationToken = default);
    }
}
