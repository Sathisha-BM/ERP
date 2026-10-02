
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.IMatIssueNoteSumService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels;
using V.SMART.Shared.ViewModels.ReportViewModel.SummaryViewModel;

namespace V.SMART.Shared.BusinessLayer.BusinessService.ReportService.MatIssueNoteSumService
{
    public class MaterialIssNoteSumReportService : IMaterialIssueNoteSummaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly ILoggingService _logs;

        private readonly IReportExecutor _report;


        public MaterialIssNoteSumReportService(
            IUnitOfWork unitOfWork,
            ICommonService commonService,
            CurrentUserService userService,
            ILoggingService logs,
            IReportExecutor report)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
            _currentUserService = userService;
            _logs = logs;
            _report = report;
        }


        //screens

        public async Task<int> GetScreenCodeByScreenNameAsync(string screenName)
                 => await _commonService.GetScreenCodeByScreenNameAsync(screenName);
        public async Task<IEnumerable<ItemVM>> SearchItemsAsync(string searchText)
            => await _commonService.SearchItemsAsync(searchText);

        public async Task<List<MaterialIssueReportVM>> GetMINSummaryReportAsync(DateTime? fromDate, DateTime? toDate, string? toWhom)
        {
            try
            {
                var result = await _report.ExecuteAsync<MaterialIssueReportVM>(
                    "Sp_GetMatIssueNoteSummaryReport",

                    new SqlParameter("@FromDate", fromDate),

                    new SqlParameter("@ToDate", toDate),

                    new SqlParameter("@ToWhom", toWhom)
                );

                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
