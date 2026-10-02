using AutoMapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.IIssueSummaryService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.ReportViewModel.IssueSummaryVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.ReportService.IssueSummaryService
{
    public class StoreAddService:IStoreAddService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly ILoggingService _logs;
        private readonly IMapper _mapper;
        private readonly IReportExecutor _report;

        string filteredData;
        public StoreAddService(IUnitOfWork unitOfWork, ICommonService commonService, CurrentUserService userService, ILoggingService logs, IMapper mapper, IReportExecutor report)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
            _currentUserService = userService;
            _logs = logs;
            _mapper = mapper;
            _report = report;
        }

        public async Task<List<StoreAddVM>> GetStoreAddDetails(DateTime Fromdate, DateTime Todate)
        {
            try
            {
                var result = await _report.ExecuteAsync<StoreAddVM>(
                    "Sp_GetStoreAddReport",
                    new SqlParameter("@FromDate", Fromdate.ToString("yyyy-MM-dd 00:00:000.00")),
                    new SqlParameter("@ToDate", Todate.ToString("yyyy-MM-dd 23:59:59.00"))


                );

                return result.ToList();
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(
                    ex,
                    "Failed to load GetViewTallyDcInOutAsync");

                return new List<StoreAddVM>();
            }
        }
    }
}
