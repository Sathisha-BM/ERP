
//namespace V.SMART
//{
//    public partial class App : Application
//    {
//        public App()
//        {
//            InitializeComponent();
//        }

//        protected override Window CreateWindow(IActivationState? activationState)
//        {
//            return new Window(new MainPage()) { Title = "V.SMART" };
//        }
//    }
//}




//using Microsoft.Extensions.Configuration;
//using System.Diagnostics;
//using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IDBBackupSetting_Service;
//using V.SMART.Shared.Services.Database_Backup;
//using V.SMART.Shared.ViewModels.BackupSettingVM;

//namespace V.SMART
//{
//    public partial class App : Application
//    {
//        private readonly IDatabaseBackupService _backupService;
//        private readonly IDBBackupSettingService _DBBackupSettingService;
//        private readonly IConfiguration _Configuration;

//        private int _backupStarted;
//        private bool _closing;
//        public App(IDatabaseBackupService backupService, IDBBackupSettingService dBBackupSettingService, IConfiguration Configuration)
//        {
//            InitializeComponent();

//            _backupService = backupService;

//        }

//        protected override Window CreateWindow(IActivationState? activationState)
//        {
//            var window = new Window(new MainPage())
//            {
//                Title = "V.SMART"
//            };

//            // =====================================================
//            // BACKUP DATABASE BEFORE DESKTOP APPLICATION CLOSES
//            // =====================================================

//            window.Destroying += async (_, _) =>
//            {
//                await BackupBeforeCloseAsync();

//            };

//            return window;
//        }
//        private async Task BackupBeforeCloseAsync()
//        {
//            if (Interlocked.Exchange(ref _backupStarted,1) == 1)
//            {
//                Debug.WriteLine("Backup already started. Skipping.");
//                return;
//            }


//            try
//            {
//                // 1. Create database backup
//                var result = await _backupService.BackupAsync();


//            }
//            catch (Exception ex)
//            {
//                Debug.WriteLine($"Backup before close failed: {ex}");
//            }
//        }

//    }
//}



using System.Diagnostics;
using V.SMART.Shared.Services.Database_Backup;

#if WINDOWS
using WinUIApplication = Microsoft.UI.Xaml.Application;
using WinUIWindow = Microsoft.UI.Xaml.Window;
#endif

namespace V.SMART
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        private readonly IDatabaseBackupService _backupService;

#if WINDOWS
        private bool _allowClose;
        private bool _backupStarted;
#endif

        public App(IDatabaseBackupService backupService)
        {
            InitializeComponent();

            _backupService = backupService;
        }

        protected override Microsoft.Maui.Controls.Window CreateWindow(
            IActivationState? activationState)
        {
            var mauiWindow =
                new Microsoft.Maui.Controls.Window(
                    new MainPage())
                {
                    Title = "V.SMART"
                };

#if WINDOWS

            mauiWindow.HandlerChanged += (_, _) =>
            {
                RegisterWindowsClose(mauiWindow);
            };

#endif

            return mauiWindow;
        }

#if WINDOWS

        private void RegisterWindowsClose(
            Microsoft.Maui.Controls.Window mauiWindow)
        {
            if (mauiWindow.Handler?.PlatformView
                is not WinUIWindow nativeWindow)
            {
                Debug.WriteLine(
                    "Native Windows window is not available.");

                return;
            }

            var appWindow = nativeWindow.AppWindow;

            appWindow.Closing += async (_, args) =>
            {
                // =================================================
                // BACKUP ALREADY COMPLETED
                // =================================================

                if (_allowClose)
                {
                    Debug.WriteLine(
                        "Allowing application to close.");

                    return;
                }

                // =================================================
                // CANCEL FIRST CLOSE
                // =================================================

                args.Cancel = true;

                // =================================================
                // PREVENT DUPLICATE BACKUP
                // =================================================

                if (_backupStarted)
                {
                    Debug.WriteLine(
                        "Backup already started.");

                    return;
                }

                _backupStarted = true;

                try
                {
                    Debug.WriteLine(
                        "======================================");

                    Debug.WriteLine(
                        "WINDOW CLOSE REQUESTED");

                    Debug.WriteLine(
                        "STARTING DATABASE BACKUP");

                    Debug.WriteLine(
                        "======================================");

                    // =================================================
                    // WAIT FOR COMPLETE BACKUP
                    // =================================================

                    var result =
                        await _backupService.BackupAsync();

                    Debug.WriteLine(
                        $"Backup Success: {result.Success}");

                    Debug.WriteLine(
                        $"Backup Message: {result.Message}");

                    Debug.WriteLine(
                        "BACKUP COMPLETED");

                    // =================================================
                    // ALLOW CLOSE
                    // =================================================

                    _allowClose = true;

                    Debug.WriteLine(
                        "Closing application...");

                    nativeWindow.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(
                        "BACKUP BEFORE CLOSE FAILED:");

                    Debug.WriteLine(
                        ex.ToString());

                    // If backup fails, close application anyway.
                    _allowClose = true;

                    nativeWindow.Close();
                }
            };
        }

#endif
    }
}
