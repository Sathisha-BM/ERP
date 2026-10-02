using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Vml.Office;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IInspectionService;
using V.SMART.Shared.Data.Inspection.FinalInspection;
using V.SMART.Shared.Data.Inspection.IncomingInspection;
using V.SMART.Shared.Data.Inspection.MasterInspection;
using V.SMART.Shared.Data.Master.HumanResourceMaster_Module.V.SMART.Shared.Data.Master.HumanResourceMaster_Module;
using V.SMART.Shared.Data.Master.Inventory_module;
using V.SMART.Shared.Data.Master.MasterScreeenManagement_Module;
using V.SMART.Shared.Data.OutSourcing.PurchaseGRN;
using V.SMART.Shared.Data.Production.ProductionComponent;
using V.SMART.Shared.Data.Production.ProductionReturnGrnAssy;
using V.SMART.Shared.Data.SalesAndLabour.SalesDC;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels;
using V.SMART.Shared.ViewModels.InspectionViewModel.IncomingInspectionVM;
using V.SMART.Shared.ViewModels.InspectionViewModel.MasterInspectionVM;
using V.SMART.Shared.ViewModels.MasterViewModel.AccountsViewModel;
using V.SMART.Shared.ViewModels.MasterViewModel.GeneralViewModel;
using V.SMART.Shared.ViewModels.MfgAndlabourViewModel.SalesDCVM;
using V.SMART.Shared.ViewModels.OutSourcingViewModel.PurchaseGRNVM;
using V.SMART.Shared.ViewModels.ProductionViewModel.ProductionLogViewModel;
using V.SMART.Shared.ViewModels.ProductionViewModel.ProductionReturnAssyViewModel;
using V.SMART.Shared.ViewModels.ProductionViewModel.ProuctionCompViewModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.OutSourcingViewModel.SubContractViewModel;
using V.SMART.Shared.Data.OutSourcing.SubContractGRN;
using V.SMART.Shared.ViewModels.MfgAndlabourViewModel.LabourGRN_VM;
using V.SMART.Shared.Data.SalesAndLabour.LabourGRN;

namespace V.SMART.Shared.BusinessLayer.BusinessService.InspectionService
{
    public class IncomingInspectionService : IIncomingInspectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly ILoggingService _logs;
        private readonly IMapper _mapper;

        public IncomingInspectionService(
            IUnitOfWork unitOfWork,
            ICommonService commonService,
            CurrentUserService userService,
            ILoggingService logs,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
            _currentUserService = userService;
            _logs = logs;
            _mapper = mapper;
        }

        // Get All Instruments
        public async Task<List<ItemVM>> GetAllInstrumentsAsync()
            => await _commonService.GetAllActiveItemsAsync();

        // Get All Get No Of Samples
        public async Task<int> GetNoOfSamples()
            => await _commonService.GetNoOfSamples();

        // Get All Get All Active Customers
        public async Task<List<CustomerVM>> GetAllActiveCustomersAsync()
            => await _commonService.GetAllActiveCustomersAsync();

        // Get All Active Defects
        public async Task<List<DefectInfo>> GetAllActiveDefectsAsync()
            => await _commonService.GetAllActiveDefectsAsync();

        // Get All All Cost Center Details
        public async Task<List<CostCenterVM>> GetAllCostCenterDetails()
            => await _commonService.GetAllCostCenterDetails();

        // Get All Components
        public async Task<List<ItemVM>> GetAllComponentsAsync()
            => await _commonService.GetAllItemsByCategoryCode(2);

        // Get All Staff
        public async Task<List<Staff>> GetAllStaffAsync()
            => await _commonService.GetAllStaffAsync();

        // Get Customer By Id Async
        public async Task<CustomerVM?> GetCustomerByIdAsync(int custId)
            => await _commonService.GetCustomerByIdAsync(custId);
        public async Task<IEnumerable<CustomerVM>> SearchCustomersAsync(string searchText)
            => await _commonService.SearchCustomersAsync(searchText);

        public async Task<List<TermsAndConditions>> GetTermsAsync()
            => await _commonService.GetAllActiveTermsAsync();


        #region  Get All Get Inspection RowVMs Async
        public async Task<List<InspectionRowVM>> GetInspectionRowVMsAsync(int ItemId, int ProcessId)
        {
            try
            {
                var Dimensions = await _commonService.GetInspectionRowVMsAsync(ItemId, ProcessId);
                if (Dimensions == null || (Dimensions.Count == 0))
                {
                    Dimensions = await _commonService.GetIncomingInspectionRowVMsAsync(ItemId, ProcessId);
                }
                return Dimensions;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "GetInspectionRowVMsAsync");
                return new List<InspectionRowVM>();
            }
        }
        #endregion

        #region  Get ItemVm by ItemId
        public async Task<string> GetCategorynameByItemIdAsync(int? itemId)
        {
            try
            {
                var itemVm = await _commonService.GetItemByItemIdAsync(itemId);
                return itemVm.CategoryName ?? "";
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error Occured in GetCategorynameByItemIdAsync()");
                return string.Empty;
            }
        }
        #endregion

        #region Generating new Inspection Number
        public async Task<String> GenerateNewInspectionNoAsync(String Screen)
        {
            try
            {

                var latestInspection = "";
                if (Screen == "Random")
                {
                    latestInspection = await _unitOfWork.IncomingInspections.GetQueryable()
                                                           .OrderByDescending(i => i.Id)
                                                           .Where(i => i.IsRandom == true)
                                                           .Select(i => i.InspectNo)
                                                           .FirstOrDefaultAsync();
                }
                else
                {
                    latestInspection = await _unitOfWork.IncomingInspections.GetQueryable()
                                                            .OrderByDescending(i => i.Id)
                                                            .Where(i => i.IsRandom == false)
                                                            .Select(i => i.InspectNo)
                                                            .FirstOrDefaultAsync();
                }
                if (latestInspection != null)
                {

                    var serialNo = int.Parse(latestInspection);
                    serialNo++;
                    return serialNo.ToString();
                }
                else
                {
                    return "1";
                }

            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error in GenerateNewInspectionNoAsync: ");
                return ""; // Default to 1 if error occurs
            }
        }
        #endregion

        #region Saving Incoming-Inspection
        public async Task<IncomingInspectionVM> UpsertInspectAsync(IncomingInspectionVM inspectVM)
        {
            if (inspectVM == null)
                throw new ArgumentNullException(nameof(inspectVM));

            var now = DateTime.Now;
            var currentUser = await _currentUserService.GetUsernameAsync();

            try
            {
                IncomingInspection entity;

                if (inspectVM.Id == 0)
                {
                    entity = _mapper.Map<IncomingInspection>(inspectVM);
                    entity.CreatedBy = currentUser;
                    entity.CreatedDate = now;

                    await _unitOfWork.IncomingInspections.CreateAsync(entity);
                }
                else
                {
                    entity = await _unitOfWork.IncomingInspections
                        .GetQueryable()
                        .FirstOrDefaultAsync(x => x.Id == inspectVM.Id)
                        ?? throw new InvalidOperationException("Inspection not found.");

                    _mapper.Map(inspectVM, entity);
                    entity.ModifiedBy = currentUser;
                    entity.ModifiedDate = now;
                }

                var refEntity = await _unitOfWork.IncomingInspectionRefs
                    .GetQueryable()
                    .FirstOrDefaultAsync(x => x.ItemID == inspectVM.ItemId && x.ProcessId == inspectVM.ProcessId);

                if (refEntity == null)
                {
                    refEntity = new IncomingInspectionRef
                    {
                        ItemID = inspectVM.ItemId ?? 0,
                        InsRefData = inspectVM.InspectionData,
                        TotRows = (short)inspectVM.TotRows,
                        ProcessId = inspectVM.ProcessId ?? 0
                    };

                    await _unitOfWork.IncomingInspectionRefs.CreateAsync(refEntity);
                }
                else
                {
                    refEntity.InsRefData = inspectVM.InspectionData;
                    refEntity.TotRows = (short)inspectVM.TotRows;
                }

                await _unitOfWork.SaveAsync();

                var savedEntity = await _unitOfWork.IncomingInspections
                    .GetQueryable()
                    .Include(x => x.Item)
                    .FirstAsync(x => x.Id == entity.Id);

                //Updating the Inspection No. in Production Log
                if (entity.DcType == "Production_Log")
                {

                    var production = await _unitOfWork.ProductionLogs.GetQueryable()
                    .FirstOrDefaultAsync(p => p.LogNo == entity.Grnno);
                    if (production != null)
                    {
                        production.InspectId = entity.Id;
                        production.AccQty = entity.AcceptQty ?? 0;
                        production.RejQty = entity.RejQty ?? 0;
                        production.RewQty = entity.ReWorkQty ?? 0;
                    }
                    await _unitOfWork.SaveAsync();
                }
                return _mapper.Map<IncomingInspectionVM>(savedEntity);
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Failed to save inspection");
                throw new InvalidOperationException("Failed to save inspection. Please try again.");
            }
        }

        #endregion

        #region Get All Inspections 
        public async Task<(List<IncomingInspectionVM> IncomingInspectionVMs, int TotalCount)>
           SearchIncomingInspectionAsync(int pageNumber, int pageSize, Dictionary<string, object>? filters)
        {
            try
            {
                var query = _unitOfWork.IncomingInspections
                    .GetQueryable()
                    .Include(x => x.Item)
                    .Include(x => x.ProductionLog.Customer)
                    .AsQueryable();

                // Apply dynamic filters
                if (filters != null)
                {
                    foreach (var filter in filters)
                    {
                        query = IncomingInspectionFilterBuilder.ApplyFilter(query, filter.Key, filter.Value);
                    }
                }

                var totalCount = await query.CountAsync();

                var list = await query
                    .OrderByDescending(x => x.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var vmList = _mapper.Map<List<IncomingInspectionVM>>(list);

                return (vmList, totalCount);
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error in SearchIncomingInspectionAsync");
                throw new InvalidOperationException("Failed to load Incoming Inspection list.", ex);
            }
        }
        #endregion

        #region Get Inspection By Id
        public async Task<IncomingInspectionVM?> GetInspectionByIdAsync(int inspectionId)
        {
            try
            {
                var inspectionEntity = await _unitOfWork.IncomingInspections
                    .GetQueryable()
                    .Include(x => x.Item)
                    .FirstOrDefaultAsync(x => x.Id == inspectionId);

                if (inspectionEntity == null)
                {
                    return null;
                }
                var inspectionVM = _mapper.Map<IncomingInspectionVM>(inspectionEntity);
                return inspectionVM;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Error in GetInspectionByIdAsync for ID : {inspectionId}");
                return null;
            }
        }
        #endregion

        #region Validate the SCN is generated or not 
        //full method copy
        public async Task<bool> ValidateSCNgenerated(IncomingInspectionVM data)
        {
            try
            {
                if (data != null)
                {
                    if (data.DcType == "Purchase")
                    {
                        // Grn <= GrnSub <= Scnsub

                        return await _unitOfWork.PurchaseSCNSubs.GetQueryable()
                               .AnyAsync(scn =>
                                   _unitOfWork.PurchaseGRNSubs.GetQueryable()
                                       .Where(sub => sub.GRNSubId == scn.RefGRNSubId && sub.ItemId == data.ItemId)
                                       .Join(_unitOfWork.PurchaseGRNs.GetQueryable(),
                                             sub => sub.GRNId,
                                             grn => grn.GRNId,
                                             (sub, grn) => grn)
                                       .Any(grn => grn.GRNNo == data.Grnno)
                               );

                    }
                    else if (data.DcType == "Production_Comp")
                    {
                        // Grn <= GrnSub <= Scnsub

                        return await _unitOfWork.ProductionSCNCompSubs.GetQueryable()
                               .AnyAsync(scn =>
                                   _unitOfWork.ProductionReturnCompSubs.GetQueryable()
                                       .Where(sub => sub.ReturnSubId == scn.RefReturnSubId && sub.ItemId == data.ItemId)
                                       .Join(_unitOfWork.ProductionReturnComps.GetQueryable(),
                                             sub => sub.ReturnId,
                                             grn => grn.ReturnId,
                                             (sub, grn) => grn)
                                       .Any(grn => grn.ReturnNo == data.Grnno)
                               );

                    }
                    else if (data.DcType == "Production_Assy")
                    {
                        // Grn <= GrnSub <= Scnsub

                        return await _unitOfWork.ProductionSCNAssySubs.GetQueryable()
                               .AnyAsync(scn =>
                                   _unitOfWork.ProductionReturnAssySubs.GetQueryable()
                                       .Where(sub => sub.ReturnSubId == scn.RefReturnSubId && sub.ItemId == data.ItemId)
                                       .Join(_unitOfWork.ProductionReturnAssys.GetQueryable(),
                                             sub => sub.ReturnId,
                                             grn => grn.ReturnId,
                                             (sub, grn) => grn)
                                       .Any(grn => grn.ReturnNo == data.Grnno)
                               );

                    }
                    else if (data.DcType == "Production_Log")
                    {
                        var scnGenerated = await _unitOfWork.ProductionLogs.GetQueryable()
                            .AnyAsync(x => x.LogNo == data.Grnno &&
                                          (x.AccQty > 0 ||
                                           x.RejQty > 0 ||
                                           x.ReturnQty > 0 ||
                                           x.RewQty > 0));

                        return scnGenerated; // true if any record matches
                    }


                    else if (data.DcType == "SubContract")
                    {
                        // Grn <= GrnSub <= Scnsub

                        return await _unitOfWork.SubConSCNSubs.GetQueryable()
                               .AnyAsync(scn =>
                                   _unitOfWork.SubConGRNSubs.GetQueryable()
                                       .Where(sub => sub.GRNSubId == scn.RefGRNSubId && sub.ItemId == data.ItemId)
                                       .Join(_unitOfWork.SubConGRNs.GetQueryable(),
                                             sub => sub.GRNId,
                                             grn => grn.GRNId,
                                             (sub, grn) => grn)
                                       .Any(grn => grn.GRNNo == data.Grnno)
                               );
                    }

                    else if (data.DcType == "Labour")
                    {
                        // Grn <= GrnSub <= Scnsub
                        return await _unitOfWork.LabourSCNSubs.GetQueryable()
                               .AnyAsync(scn =>
                                   _unitOfWork.LabourGRNSubs.GetQueryable()
                                       .Where(sub => sub.GRNSubId == scn.RefGRNSubId && sub.ItemId == data.ItemId)
                                       .Join(_unitOfWork.LabourGRNs.GetQueryable(),
                                             sub => sub.GRNId,
                                             grn => grn.GRNId,
                                             (sub, grn) => grn)
                                       .Any(grn => grn.GRNNo == data.Grnno)
                               );
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Error in ValidateSCNgenerated()");
                return false;
            }

        }
        #endregion

        #region Delete Inspection By Id
        public async Task<bool> DeleteInspectionByIdAsync(int inspectionId)
        {
            try
            {
                var inspectionEntity = await _unitOfWork.IncomingInspections.GetQueryable().FirstOrDefaultAsync(x => x.Id == inspectionId);
                if (inspectionEntity == null)
                {
                    return false; // Not found
                }
                await _unitOfWork.IncomingInspections.DeleteAsync(inspectionEntity);

                //Updating the Inspection No in Production Log
                if (inspectionEntity.DcType == "Production_Log")
                {
                    var production = await _unitOfWork.ProductionLogs.GetQueryable()
                        .FirstOrDefaultAsync(p => p.LogNo == inspectionEntity.Grnno);
                    if (production != null)
                    {
                        production.InspectId = null;
                    }
                    await _unitOfWork.SaveAsync();
                }

                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Error in DeleteInspectionByIdAsync for ID : {inspectionId} in Final Inspection");
                return false;
            }
        }
        #endregion

        #region To Check Duplicate Inspection
        public async Task<bool> CheckDuplicateRandom(string inspNo, bool isRandom, string suffix)
        {
            try
            {
                if (isRandom == true)
                {
                    return await _unitOfWork.IncomingInspections
                        .GetQueryable()
                        .AnyAsync(i => i.InspectNo == inspNo && i.IsRandom == true && i.Suffix == suffix);
                }
                else
                {
                    return await _unitOfWork.IncomingInspections
                       .GetQueryable()
                       .AnyAsync(i => i.InspectNo == inspNo && i.IsRandom == false && i.Suffix == suffix);
                }
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Error in CheckDuplicateRandom() in Final Inspection Service");
                return false;
            }
        }
        #endregion

        #region Get All Dcs which is BalQty Pending
        public async Task<List<IncomingInspectionVM>> GetBalQtyDcs()
        {
            try
            {
                var allDcs = await _unitOfWork.IncomingInspections
                                .GetQueryable()
                                .Where(i => i.BalQty > 0).ToListAsync();

                var allDcsVM = _mapper.Map<List<IncomingInspectionVM>>(allDcs);
                return allDcsVM;

            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Error in GetBalQtyDcs() in Final Inspection Service");
                return new List<IncomingInspectionVM>();
            }
        }
        #endregion

        #region Get All Production logs
        public async Task<List<ProductionLogVM>> GetAllProductionLogsAsync()
        {
            try
            {
                var productionLogEntities = await _unitOfWork.ProductionLogs
                                            .GetQueryable()
                                            .Where(x => x.AccQty <= 0
                                                    && x.RejQty <= 0 && x.ReturnQty <= 0 && x.InspectId == null)
                                            .Include(x => x.Process)
                                            .Include(x => x.ItemIn)
                                            .OrderByDescending(x => x.LogId)
                                            .ToListAsync();

                var productionLogVMs = _mapper.Map<List<ProductionLogVM>>(productionLogEntities);
                return productionLogVMs;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error in GetAllProductionLogsAsync: ");
                return new List<ProductionLogVM>();
            }
        }
        #endregion

        #region Get All Production Component GRNs
        public async Task<List<ProductionReturnCompVM>> GetAllProductionCompGRNAsync()
        {
            try
            {
                var productionCompEntities = await _unitOfWork.ProductionReturnComps
                    .GetQueryable()

                    // Get GRNs having at least one sub
                    // which is NOT inspected
                    .Where(dc => dc.ProductionReturnCompSubs.Any(sub =>
                        !_unitOfWork.IncomingInspections
                            .GetQueryable()
                            .Any(ins =>
                                ins.RefProductionCompGRNSubId == sub.ReturnSubId
                            )
                    ))

                    .Select(dc => new ProductionReturnComp
                    {
                        ReturnId = dc.ReturnId,
                        ReturnNo = dc.ReturnNo + dc.Suffix,
                        ReturnDate = dc.ReturnDate,

                        // Sathish
                        Customer = dc.Customer,
                        CustId = dc.CustId,

                        // ONLY subs which are NOT inspected
                        ProductionReturnCompSubs = dc.ProductionReturnCompSubs
                            .Where(sub =>
                                !_unitOfWork.IncomingInspections
                                    .GetQueryable()
                                    .Any(ins =>
                                        ins.RefProductionCompGRNSubId == sub.ReturnSubId
                                    ) && sub.TransType == "In" && sub.BalQty > 0
                            )
                            .Select(sub => new ProductionReturnCompSub
                            {
                                ReturnSubId = sub.ReturnSubId,
                                ReturnId = sub.ReturnId,
                                Item = sub.Item,
                                ItemId = sub.ItemId,
                                Qty = sub.Qty
                            })
                            .ToList()
                    })
                    .ToListAsync();

                var productionCompVMs =
                    _mapper.Map<List<ProductionReturnCompVM>>(productionCompEntities);

                return productionCompVMs;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error in GetAllProductionCompGRNAsync: ");
                return new List<ProductionReturnCompVM>();
            }
        }
        #endregion

        #region Get All Production Assembly GRNs
        public async Task<List<ProductionReturnAssyVM>> GetAllProductionAssymblyGRNAsync()
        {
            try
            {
                var productionAssyEntities = await _unitOfWork.ProductionReturnAssys
                    .GetQueryable()

                    // Get Return GRNs having at least one sub
                    // which is NOT inspected
                    .Where(dc => dc.ProductionReturnAssySubs.Any(sub =>
                        !_unitOfWork.IncomingInspections
                            .GetQueryable()
                            .Any(ins =>
                                ins.RefProductionCompGRNSubId == sub.ReturnSubId
                            ) && sub.BalQty > 0
                    ))

                    .Select(dc => new ProductionReturnAssy
                    {
                        ReturnId = dc.ReturnId,
                        ReturnNo = dc.ReturnNo + dc.Suffix,
                        ReturnDate = dc.ReturnDate,

                        // ONLY subs which are NOT inspected
                        ProductionReturnAssySubs = dc.ProductionReturnAssySubs
                            .Where(sub =>
                                !_unitOfWork.IncomingInspections
                                    .GetQueryable()
                                    .Any(ins =>
                                        ins.RefProductionCompGRNSubId == sub.ReturnSubId
                                    )
                            )
                            .Select(sub => new ProductionReturnAssySub
                            {
                                ReturnSubId = sub.ReturnSubId,
                                ReturnId = sub.ReturnId,
                                Item = sub.Item,
                                ItemId = sub.ItemId,
                                QtyReturned = sub.QtyReturned
                            })
                            .ToList()
                    })
                    .ToListAsync();

                var productionAssyVMs =
                    _mapper.Map<List<ProductionReturnAssyVM>>(productionAssyEntities);

                return productionAssyVMs;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error in GetAllProductionAssymblyGRNAsync()");
                return new List<ProductionReturnAssyVM>();
            }
        }
        #endregion

        #region Get All Purchase Grns
        public async Task<List<PurchaseGRNVM>> GetAllPurchaseGRNsAsync()
        {
            try
            {
                var PurchaseGRN = await _unitOfWork.PurchaseGRNs
                    .GetQueryable()

                    // Only Purchase GRNs having at least one
                    // PurchaseGRNSub which is NOT inspected
                    .Where(grn => grn.PurchaseGRNSubs.Any(sub =>
                        !_unitOfWork.IncomingInspections
                            .GetQueryable()
                            .Any(ins =>
                                ins.RefPurchaseGRNSubId == sub.GRNSubId
                            ) && sub.BalQty > 0
                    ))

                    .Select(grn => new PurchaseGRN
                    {
                        GRNId = grn.GRNId,
                        GRNNo = grn.GRNNo + grn.Suffix,
                        Vendor = grn.Vendor,
                        GRNDate = grn.GRNDate,
                        VendorCode = grn.VendorCode,
                        RefDcNo = grn.RefDcNo,

                        // ONLY subs which are NOT inspected
                        PurchaseGRNSubs = grn.PurchaseGRNSubs
                            .Where(sub =>
                                !_unitOfWork.IncomingInspections
                                    .GetQueryable()
                                    .Any(ins =>
                                        ins.RefPurchaseGRNSubId == sub.GRNSubId
                                    )
                            )
                            .Select(sub => new PurchaseGRNSub
                            {
                                GRNSubId = sub.GRNSubId,
                                GRNId = sub.GRNId,
                                Item = sub.Item,
                                ItemId = sub.ItemId,
                                RefPoSubId = sub.RefPoSubId,
                                PurchPoSub = sub.PurchPoSub,
                                Qty = sub.Qty
                            })
                            .ToList()
                    }).ToListAsync();

                return _mapper.Map<List<PurchaseGRNVM>>(PurchaseGRN);
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error in GetAllPurchaseGRNsAsync: ");
                return new List<PurchaseGRNVM>();
            }
        }
        #endregion

        #region Incoming Inspection Filter Builder
        public static class IncomingInspectionFilterBuilder
        {
            public static IQueryable<IncomingInspection> ApplyFilter(
                IQueryable<IncomingInspection> query,
                string field,
                object value)
            {
                try
                {
                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                        return query;

                    string val = value.ToString()!.Trim();

                    switch (field)
                    {
                        case "ScreenType":
                            return ScreenTypeFilter(query, val);

                        case "DcType":
                            return InspectionTypeFilter(query, val);

                        case "InspectNo":
                            string part1 = val;
                            string part2 = string.Empty;

                            int slashIndex = val.IndexOf('/');
                            if (slashIndex > -1)
                            {
                                part1 = val[..slashIndex].Trim();
                                part2 = val[(slashIndex + 1)..].Trim();
                            }

                            return query.Where(x => (string.IsNullOrEmpty(part1) || x.InspectNo.StartsWith(part1)) &&
                                (string.IsNullOrEmpty(part2) || (x.Suffix != null && x.Suffix.Contains(part2)))
                            );

                        case "ItemName":
                            return query.Where(x =>
                                x.Item != null &&
                                x.Item.ItemName.Contains(val));

                        case "ItemCode":
                            return query.Where(x =>
                                x.Item != null &&
                                x.Item.ItemCode.Contains(val));
                        case "CreatedBy":
                            return query.Where(x =>
                                x.CreatedBy != null &&
                                x.CreatedBy.Contains(val));

                        case "FromDate":
                            if (DateTime.TryParse(val, out var fromDate))
                                return query.Where(x => x.InspectDate >= fromDate.Date);
                            return query;

                        case "ToDate":
                            if (DateTime.TryParse(val, out var toDate))
                                return query.Where(x =>
                                    x.InspectDate <= toDate.Date.AddDays(1).AddTicks(-1));
                            return query;


                    }

                    return query;
                }
                catch
                {
                    return query;
                }
            }
        }

        private static IQueryable<IncomingInspection> InspectionTypeFilter(
           IQueryable<IncomingInspection> query, string status)
        {
            return status switch
            {
                "Random Inspection" => query.Where(x => x.IsRandom == true),
                "Individual Inspection" => query.Where(x => x.IsRandom == false),
                _ => query
            };
        }

        private static IQueryable<IncomingInspection> ScreenTypeFilter(
           IQueryable<IncomingInspection> query, string status)
        {
            return status switch
            {

                "SubContract" => query.Where(x => x.DcType == "SubContract"),
                "Purchase" => query.Where(x => x.DcType == "Purchase"),
                "Labour" => query.Where(x => x.DcType == "Labour"),
                "Production_Comp" => query.Where(x => x.DcType == "Production_Comp"),
                "Production_Assy" => query.Where(x => x.DcType == "Production_Assy"),
                "Production_Log" => query.Where(x => x.DcType == "Production_Log"),
                _ => query
            };
        }
        #endregion

        #region Update the Status to the Incoming InspectionVM
        public async Task<List<IncomingInspectionVM>> UpdateStatus(List<IncomingInspectionVM> incomingInspectionVMs)
        {
            try
            {
                if (incomingInspectionVMs == null || !incomingInspectionVMs.Any())
                    return new List<IncomingInspectionVM>();

                foreach (var vm in incomingInspectionVMs)
                {
                    if (vm == null) continue;

                    vm.status = await ValidateSCNgenerated(vm);
                }

                return incomingInspectionVMs;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error in UpdateStatus in IncomingInspection Service");
                return incomingInspectionVMs ?? new List<IncomingInspectionVM>();
            }
        }
        #endregion

        public async Task<List<SubConGRNVM>> GetAllSubcontractGRNsAsync()
        {
            try
            {
                var SubConGRN = await _unitOfWork.SubConGRNs
                    .GetQueryable()

                    // Get GRNs having at least one "In" sub
                    // which does NOT have an Incoming Inspection
                    .Where(dc => dc.SubConGRNSubs.Any(sub =>
                        sub.TransType == "In" &&
                        !_unitOfWork.IncomingInspections
                            .GetQueryable()
                            .Any(ins =>
                                ins.RefSubconGRNSubId == sub.GRNSubId
                            ) && sub.BalQty > 0
                    ))

                    .Select(dc => new SubConGRN
                    {
                        GRNId = dc.GRNId,
                        GRNNo = dc.GRNNo + dc.Suffix,
                        vendor = dc.vendor,
                        GRNDate = dc.GRNDate,
                        VendorCode = dc.VendorCode,
                        PartyDC = dc.PartyDC,

                        // ONLY "In" subs which are NOT inspected
                        SubConGRNSubs = dc.SubConGRNSubs
                            .Where(sub =>
                                sub.TransType == "In" &&
                                !_unitOfWork.IncomingInspections
                                    .GetQueryable()
                                    .Any(ins =>
                                        ins.RefSubconGRNSubId == sub.GRNSubId
                                    )
                            )
                            .Select(sub => new SubConGRNSub
                            {
                                GRNSubId = sub.GRNSubId,
                                GRNId = sub.GRNId,
                                Item = sub.Item,
                                ItemId = sub.ItemId ?? 0,
                                RefPoSubId = sub.RefPoSubId,
                                PurchPoSub = sub.PurchPoSub,
                                Qty = sub.Qty ?? 0,
                                Process = sub.Process,
                                ProcessId = sub.ProcessId

                            })
                            .ToList()
                    })
                    .ToListAsync();

                return _mapper.Map<List<SubConGRNVM>>(SubConGRN);
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error in GetAllSubConGRNsAsync: ");
                return new List<SubConGRNVM>();
            }
        }


        public async Task<List<LabourGRNVM>> GetAllLabourGRNsAsync()
        {
            try
            {
                var LabourGRNdata = await _unitOfWork.LabourGRNs
                                    .GetQueryable()
                                    .Where(grn => grn.LabourGRNSubs
                                        .Any(sub =>
                                            sub.TransType == "In" &&
                                            !_unitOfWork.IncomingInspections
                                                .GetQueryable()
                                                .Any(ins => ins.RefLabGRNSubId == sub.GRNSubId) && sub.BalQty > 0
                                        ))
                                    .Select(grn => new LabourGRN
                                    {
                                        GRNId = grn.GRNId,
                                        GRNNo = grn.GRNNo + grn.Suffix,
                                        Customer = grn.Customer,
                                        GRNDate = grn.GRNDate,
                                        CustId = grn.CustId,
                                        RefDcNo = grn.RefDcNo,

                                        LabourGRNSubs = grn.LabourGRNSubs
                                            .Where(sub =>
                                                sub.TransType == "In" &&
                                                !_unitOfWork.IncomingInspections
                                                    .GetQueryable()
                                                    .Any(ins => ins.RefLabGRNSubId == sub.GRNSubId)
                                            )
                                            .Select(sub => new LabourGRNSub
                                            {
                                                GRNSubId = sub.GRNSubId,
                                                GRNId = sub.GRNId,
                                                Item = sub.Item,
                                                ItemId = sub.ItemId ?? 0,
                                                RefPoSubId = sub.RefPoSubId,
                                                MfgPoSub = sub.MfgPoSub,
                                                Qty = sub.Qty
                                            })
                                            .ToList()
                                    })
                                    .ToListAsync();

                return _mapper.Map<List<LabourGRNVM>>(LabourGRNdata);
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error in GetAllLabourGRNsAsync: ");
                return new List<LabourGRNVM>();
            }
        }
    }
}
