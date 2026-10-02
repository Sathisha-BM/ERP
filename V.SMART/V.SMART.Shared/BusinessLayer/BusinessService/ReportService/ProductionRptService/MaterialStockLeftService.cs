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
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.ReportViewModel.MaterialStockLeftVM;
using V.SMART.Shared.ViewModels.ReportViewModel.RatingsVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.ReportService.TrackReportService
{
    public class MaterialStockLeftService : IMaterialstockLeftService
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly ILoggingService _logs;
        private readonly IReportExecutor _report;
       


        public MaterialStockLeftService(
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
        public async Task<List<MaterialStockLeftVM>> GetPartyPendingAsync(string partyType, string? partyId, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var parameters = new[]
                {

                    new SqlParameter("@partyType", partyType ?? (object)DBNull.Value),
                    new SqlParameter("@partyId", partyId ?? (object)DBNull.Value),
                    new SqlParameter("@FromDate", fromDate ?? (object)DBNull.Value),
                    new SqlParameter("@ToDate", toDate ?? (object)DBNull.Value)

                };

                var result = await _report.ExecuteAsync<MaterialStockLeftVM>(
                    "sp_GetMaterialStockLeftReport",
                    parameters
                );

                return result ?? new List<MaterialStockLeftVM>();
            }
            catch (Exception ex)
            {
                _logs.LogDeveloperError(
                    ex,
                    "Error executing stored procedure SP_BillPending"
                );

                return new List<MaterialStockLeftVM>();
            }
        }



        public async Task<List<PartyVM>> GetPartiesAsync(
        string selectedType,
        DateTime? fromDate,
        DateTime? toDate)
        {
            switch (selectedType)
            {
                //case "SubContract":
                //    {
                //        var data = await _unitOfWork.SubConDCOuts
                //            .GetQueryable()
                //            .Include(x => x.Vendor)
                //            .Include(x => x.SubConDcOutSubs)
                //            .ToListAsync();

                //        return data
                //            .Where(x =>
                //                !x.DcTally &&
                //                x.Vendor != null &&
                //                x.VendorCode.HasValue &&
                //                x.SubConDcOutSubs.Any(s => s.BalQty > 0))
                //            .Select(x => new PartyVM
                //            {
                //                Id = x.VendorCode.Value,
                //                Name = x.Vendor.VendorName
                //            })
                //            .DistinctBy(x => x.Id)
                //            .OrderBy(x => x.Name)
                //            .ToList();
                //    }

                //case "Labour":
                //    {
                //        var data = await _unitOfWork.LabourGRNs
                //            .GetQueryable()
                //            .Include(x => x.Customer)
                //            .Include(x => x.LabourGRNSubs)
                //            .ToListAsync();

                //        return data
                //            .Where(x =>
                //                !x.DcTally &&
                //                x.Customer != null &&
                //                x.LabourGRNSubs.Any(s => s.BalQty > 0))
                //            .Select(x => new PartyVM
                //            {
                //                Id = x.CustId,
                //                Name = x.Customer.CustName
                //            })
                //            .DistinctBy(x => x.Id)
                //            .OrderBy(x => x.Name)
                //            .ToList();
                //    }

                //case "ProductionComponent":
                //    {
                //        var data = await _unitOfWork.ProductionIssueComps
                //            .GetQueryable()
                //            .Include(x => x.ProductionIssueCompSubs)
                //            .ToListAsync();

                //        return data
                //            .Where(x => !x.IssueTally && x.ProductionIssueCompSubs.Any(s => s.BalQty > 0))
                //            .Select(x => new PartyVM
                //            {
                //                Id = x.IssueId,
                //                Name = x.IssueNo + "/" + x.Suffix
                //            })
                //            .DistinctBy(x => x.Id)
                //            .OrderBy(x => x.Name)
                //            .ToList();
                //    }

                //case "ProductionAssy":
                //    {
                //        var data = await _unitOfWork.ProductionIssueAssys
                //            .GetQueryable()
                //            .Include(x => x.ProductionIssueAssySubs)
                //            .ToListAsync();

                //        return data
                //            .Where(x => !x.IssueTally && x.ProductionIssueAssySubs.Any(s => s.BalQty > 0))
                //            .Select(x => new PartyVM
                //            {
                //                Id = x.IssueId,
                //                Name = x.IssueNo + "/" + x.Suffix
                //            })
                //            .DistinctBy(x => x.Id)
                //            .OrderBy(x => x.Name)
                //            .ToList();
                //    }

                //case "ProductionLog":
                //    {
                //        var data = await _unitOfWork.RouteCards
                //            .GetQueryable()
                //            .Include(x => x.Customer)
                //            .Include(x => x.RouteCardSubs)
                //            .ToListAsync();

                //        return data
                //            .Where(x =>
                //                x.CustId.HasValue &&
                //                x.Customer != null &&
                //                x.RcStatus == 0 &&
                //                x.RouteCardSubs.Any(s => s.BalQty > 0))
                //            .Select(x => new PartyVM
                //            {
                //                Id = x.CustId.Value,
                //                Name = x.Customer.CustName
                //            })
                //            .DistinctBy(x => x.Id)
                //            .OrderBy(x => x.Name)
                //            .ToList();
                //    }


                case "SubContract":
                    {
                        var data = await _unitOfWork.SubConDCOuts
                            .GetQueryable()
                            .Include(x => x.Vendor)
                            .Include(x => x.SubConDcOutSubs)
                            .Where(x =>
                                !x.DcTally &&
                                x.Vendor != null &&
                                x.VendorCode.HasValue &&
                                x.SubConDcOutSubs.Any(s => s.BalQty > 0) &&
                                (!fromDate.HasValue || x.DcDate >= fromDate.Value) &&
                                (!toDate.HasValue || x.DcDate < toDate.Value.AddDays(1)))
                            .ToListAsync();

                        return data
                            .Select(x => new PartyVM
                            {
                                Id = x.VendorCode.Value,
                                Name = x.Vendor.VendorName
                            })
                            .DistinctBy(x => x.Id)
                            .OrderBy(x => x.Name)
                            .ToList();
                    }
                case "Labour":
                    {
                        var data = await _unitOfWork.LabourGRNs
                            .GetQueryable()
                            .Include(x => x.Customer)
                            .Include(x => x.LabourGRNSubs)
                            .Where(x =>
                                !x.DcTally &&
                                x.Customer != null &&
                                x.LabourGRNSubs.Any(s => s.BalQty > 0) &&
                                (!fromDate.HasValue || x.GRNDate >= fromDate.Value) &&
                                (!toDate.HasValue || x.GRNDate < toDate.Value.AddDays(1)))
                            .ToListAsync();

                        return data
                            .Select(x => new PartyVM
                            {
                                Id = x.CustId,
                                Name = x.Customer.CustName
                            })
                            .DistinctBy(x => x.Id)
                            .OrderBy(x => x.Name)
                            .ToList();
                    }
                case "ProductionComponent":
                    {
                        var data = await _unitOfWork.ProductionIssueComps
                            .GetQueryable()
                            .Include(x => x.ProductionIssueCompSubs)
                            .Where(x =>
                                !x.IssueTally &&
                                x.ProductionIssueCompSubs.Any(s => s.BalQty > 0) &&
                                (!fromDate.HasValue || x.IssueDate >= fromDate.Value) &&
                                (!toDate.HasValue || x.IssueDate < toDate.Value.AddDays(1)))
                            .ToListAsync();

                        return data
                            .Select(x => new PartyVM
                            {
                                Id = x.IssueId,
                                Name = $"{x.IssueNo}/{x.Suffix}"
                            })
                            .DistinctBy(x => x.Id)
                            .OrderBy(x => x.Name)
                            .ToList();
                    }
                case "ProductionAssy":
                    {
                        var data = await _unitOfWork.ProductionIssueAssys
                            .GetQueryable()
                            .Include(x => x.ProductionIssueAssySubs)
                            .Where(x =>
                                !x.IssueTally &&
                                x.ProductionIssueAssySubs.Any(s => s.BalQty > 0) &&
                                (!fromDate.HasValue || x.IssueDate >= fromDate.Value) &&
                                (!toDate.HasValue || x.IssueDate < toDate.Value.AddDays(1)))
                            .ToListAsync();

                        return data
                            .Select(x => new PartyVM
                            {
                                Id = x.IssueId,
                                Name = $"{x.IssueNo}/{x.Suffix}"
                            })
                            .DistinctBy(x => x.Id)
                            .OrderBy(x => x.Name)
                            .ToList();
                    }
                case "ProductionLog":
                    {
                        var data = await _unitOfWork.ProductionLogs
                         .GetQueryable()
                         .AsNoTracking()
                         .Where(x =>
                             (x.InputQty - (x.AccQty + x.RejQty + x.RewQty)) > 0 &&
                             (!fromDate.HasValue || x.LogDate >= fromDate.Value) &&
                             (!toDate.HasValue || x.LogDate < toDate.Value.AddDays(1)))
                         .ToListAsync();

                        return data
                            .Select(x => new PartyVM
                            {
                                Id = (int)x.LogId,
                                Name = $"{x.LogNo}{x.Suffix}"
                            })
                            .DistinctBy(x => x.Id)
                            .OrderBy(x => x.Name)
                            .ToList();
                    }

                default:
                    return new List<PartyVM>();
            }
        }
    }
  
}
    
