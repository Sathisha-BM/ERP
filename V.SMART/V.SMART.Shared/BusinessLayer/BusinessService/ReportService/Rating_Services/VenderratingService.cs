using AutoMapper;
using FastReport;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService;
using V.SMART.Shared.Data.Master.General;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.MasterViewModel.GeneralViewModel;
using V.SMART.Shared.ViewModels.ReportViewModel.VendorRatingVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.ReportService.TrackReportService
{
    public class VenderratingService : IVenderratingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly ILoggingService _logs;
        private readonly IReportExecutor _report;


        public VenderratingService(
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

        public async Task<List<VendorVM>> GetAllVendorsAsync(string selectedType, DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<Vendor> vendors;

                if (selectedType == "Purchase")
                {
                    vendors = await
                    (
                        from po in _unitOfWork.PurchPos.GetQueryable()

                        join poSub in _unitOfWork.PurchPoSubs.GetQueryable()
                            on po.PoId equals poSub.PoId

                        join grnSub in _unitOfWork.PurchaseGRNSubs.GetQueryable()
                            on poSub.PoSubId equals grnSub.RefPoSubId

                        join scnSub in _unitOfWork.PurchaseSCNSubs.GetQueryable()
                            on grnSub.GRNSubId equals scnSub.RefGRNSubId

                        join scn in _unitOfWork.PurchaseSCNs.GetQueryable()
                            on scnSub.SCNId equals scn.SCNId

                        where po.PODate.Date >= fromDate.Date
                           && po.PODate.Date <= toDate.Date
                           && po.PurchORSubCon == true
                           && scn.SCNId > 0

                        select po.Vendor
                    )
                    .Distinct()
                    .OrderBy(v => v.VendorName)
                    .ToListAsync();
                }
                else if (selectedType == "Subcontract")
                {
                    vendors = await
                    (
                        from po in _unitOfWork.PurchPos.GetQueryable()

                        join poSub in _unitOfWork.PurchPoSubs.GetQueryable()
                            on po.PoId equals poSub.PoId

                        join dcOutSub in _unitOfWork.SubConDCOutSubs.GetQueryable()
                            on poSub.PoSubId equals dcOutSub.RefPoSubId

                        join grnSub in _unitOfWork.SubConGRNSubs.GetQueryable()
                            on dcOutSub.DcSubId equals grnSub.RefDcSubId

                        join scnSub in _unitOfWork.SubConSCNSubs.GetQueryable()
                            on grnSub.GRNSubId equals scnSub.RefGRNSubId

                        join scn in _unitOfWork.SubConSCNs.GetQueryable()
                            on scnSub.SCNId equals scn.SCNId

                        where po.PODate.Date >= fromDate.Date
                           && po.PODate.Date <= toDate.Date
                           && po.PurchORSubCon == false
                           && scn.SCNId > 0

                        select po.Vendor
                    )
                    .Distinct()
                    .OrderBy(v => v.VendorName)
                    .ToListAsync();
                }
                else
                {
                    vendors = new List<Vendor>();
                }
               

                return _mapper.Map<List<VendorVM>>(vendors);
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error executing GetAllVendorsAsync");
                return new List<VendorVM>();
            }
        }

        public async Task<List<VendorRatingVM>> GetRatings(String SelectedType, string partyId, DateTime? fromDate, DateTime? toDate)
        {
                try
                {
                    var parameters = new[]
                    {
                        new SqlParameter("@SelectedType", (object?)SelectedType ?? DBNull.Value),
                        new SqlParameter("@SelectedParty", (object?)partyId ?? DBNull.Value),
                        new SqlParameter("@FromDate", (object?)fromDate ?? DBNull.Value),
                        new SqlParameter("@ToDate", (object?)toDate ?? DBNull.Value)
                    };

                    var result = await _report.ExecuteAsync<VendorRatingVM>(
                            "sp_VendorPerformance",
                            parameters
                        );

                    return result ?? new List<VendorRatingVM>();
                }
                catch (Exception ex)
                {
                    _logs.LogDeveloperError(
                        ex,
                        "Error executing stored procedure SP_BillPending"
                    );

                    return new List<VendorRatingVM>();
                }
            }

        }
    }
