using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.ReportViewModel.GSTITCVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.IGSTITC
{
    public interface IGSTR1Service
    {
        Task<List<GSTR1VM>> GetGSTR1Async (DateTime fromDate,DateTime toDate,string section);

        Task<byte[]> ExportGSTR1JsonAsync(DateTime fromDate,DateTime toDate,string section);

        //Task<byte[]> ExportExcelAsync(List<GSTR1VM> data, string section);

        Task<byte[]> ExportExcelAsync(DateTime fromDate,DateTime toDate,List<string> sections);
    }    
}
