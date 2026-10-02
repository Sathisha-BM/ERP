using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.BackupSetting;
using V.SMART.Shared.ViewModels.BackupSettingVM;

namespace V.SMART.Shared.Mappings.DBBackupSetting_Profile
{
    public class DBBackupSettingProfile : Profile
    {
        public DBBackupSettingProfile()
        {
            CreateMap<DBBackupSetting, DBBackupSettingVM>();

            CreateMap<DBBackupSettingVM, DBBackupSetting>();
        }
    }
}
