using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.BackupSettingVM;

namespace V.SMART.Shared.Services.Database_Backup
{
    public interface IDatabaseBackupService
    {
        Task<DatabaseBackupResult> BackupAsync(CancellationToken cancellationToken = default);

    }
}
