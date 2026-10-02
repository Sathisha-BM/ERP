using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService;
using V.SMART.Shared.Data.Master.General;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.MasterViewModel.GeneralViewModel;
using V.SMART.Shared.ViewModels.ReportViewModel.ProductionWorkOrder;

namespace V.SMART.Shared.BusinessLayer.BusinessService.ReportService.TrackReportService
{
    public class ProductionWorkOrderIssueAssemblyComponentService : IProductionWorkOrderIssueAssemblyComponentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly ILoggingService _logs;
        private readonly IReportExecutor _report;


        public ProductionWorkOrderIssueAssemblyComponentService(
            IUnitOfWork unitOfWork,
            ICommonService commonService,
            CurrentUserService userService,
            ILoggingService logs,
            IMapper mapper,
            IReportExecutor report
            )
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
            _currentUserService = userService;
            _logs = logs;
            _mapper = mapper;
            _report = report;

        }



        public async Task<List<CustomerVM>> GetAllCustomerAsync(string selectedType, DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<Customer> customers;
               
                if (selectedType == "Production Component")
                {
                    customers = await _unitOfWork.ProductionIssueComps.GetQueryable()
                     .Where(x => x.IssueDate.Date >= fromDate.Date &&
                                 x.IssueDate.Date <= toDate.Date &&
                                 !string.IsNullOrEmpty(x.IssueToWhom))
                     .Select(x => new Customer
                     {
                         CustName = x.IssueToWhom
                     })
                     .Distinct()
                     .OrderBy(x => x.CustName)
                     .ToListAsync();
                }
                else if (selectedType == "Production Assembly")
                {
                    customers = await _unitOfWork.ProductionIssueAssys.GetQueryable()
                    .Where(x => x.IssueDate >= fromDate.Date
                                && x.IssueDate <= toDate.Date
                                && !string.IsNullOrEmpty(x.IssueToWhom))
                    .Select(x => x.IssueToWhom)
                    .Distinct()
                    .OrderBy(x => x)
                    .Select(x => new Customer
                    {
                        CustName = x
                    })
                    .ToListAsync();
                }
                else
                {
                    customers = new List<Customer>();
                }

                return _mapper.Map<List<CustomerVM>>(customers);

            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error executing GetAllCustomerAsync");
                return new List<CustomerVM>();
            }
        }

        public async Task<List<ProductionWorkOrderVM>> GetProductionWorkOrderIssueAsync(bool? detailsView, string? selectedType, string? selectedParty, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var parameters = new[]
                {
                     new SqlParameter(
                         "@DetailsView",
                         detailsView.HasValue
                             ? (object)detailsView.Value
                             : DBNull.Value),

                     new SqlParameter(
                         "@PartyType",
                         (object?)selectedType ?? DBNull.Value),

                     new SqlParameter(
                         "@SelectedParty",
                         (object?)selectedParty ?? DBNull.Value),

                     new SqlParameter(
                         "@FromDate",
                         fromDate.HasValue
                             ? (object)fromDate.Value
                             : DBNull.Value),

                     new SqlParameter(
                         "@ToDate",
                         toDate.HasValue
                             ? (object)toDate.Value
                             : DBNull.Value)
                };

                var result = await _report.ExecuteAsync<ProductionWorkOrderVM>("sp_GetProductionWorkOrderIssueReport",parameters);

                return result ?? new List<ProductionWorkOrderVM>();
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(
                    ex,
                    "Error executing stored procedure sp_GetProductionWorkOrderIssueReport");

                return new List<ProductionWorkOrderVM>();
            }
        }
    }
}
