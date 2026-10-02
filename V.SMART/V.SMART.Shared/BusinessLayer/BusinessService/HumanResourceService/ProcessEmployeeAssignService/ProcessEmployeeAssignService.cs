using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IHumanResourceService.IProcessEmployeeAssignService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IInventoryService;
using V.SMART.Shared.Data.HumanResource.ProcessEmployeeAssign;
using V.SMART.Shared.Data.Master.HumanResourceMaster_Module.V.SMART.Shared.Data.Master.HumanResourceMaster_Module;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.HumanResourceViewModel.ProcessEmployeeAssignVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.HumanResourceService.ProcessEmployeeAssignService
{
    public class ProcessEmployeeAssignService : IProcessEmployeeAssignService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly ILoggingService _logs;
        private readonly IMapper _mapper;

        private readonly IStockManagerService _stockManagerService;


        public ProcessEmployeeAssignService(
            IUnitOfWork unitOfWork,
            ICommonService commonService,
            CurrentUserService userService,
            ILoggingService logs,
            IMapper mapper, IStockManagerService stock)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
            _currentUserService = userService;
            _logs = logs;
            _mapper = mapper;
            _stockManagerService = stock;

        }

        public async Task<List<Staff>> GetAllStaffAsync()
        {
            return await _commonService.GetAllStaffAsync();
        }

        public async Task<int> GetNextWeekNo()
        {
            var lastWeekNo = await _unitOfWork.ProcessEmployeeAssigns
                .GetQueryable()
                .OrderByDescending(x => x.AssignmentId)
                .Select(x => x.WeekNo)
                .FirstOrDefaultAsync();

            return lastWeekNo + 1;
        }

        public async Task<bool> IsEmployeeAssignedToProcessAsync(ProcessEmployeeAssignVM model)
        {
            try
            {

                var exists = await _unitOfWork.ProcessEmployeeAssigns
                    .GetQueryable()
                    .AnyAsync(x =>
                        x.WeekNo == model.WeekNo &&
                        x.ProcessId == model.ProcessId &&
                        x.StaffId == model.StaffId);

                return exists;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error occurred while checking if employee is assigned to process");
                return false;
            }
        }

        public async Task<int> UpsertprocessEmployee(ProcessEmployeeAssignVM model)
        {
            try
            {
                var currentUser = await _currentUserService.GetUsernameAsync();

                if (model.AssignmentId == 0)
                {
                    // CREATE
                    foreach (var staffId in model.SelectedStaffIds)
                    {
                        var entity = new ProcessEmployeeAssign
                        {
                            WeekNo = model.WeekNo,
                            fromDate = model.fromDate,
                            toDate = model.toDate,
                            ProcessId = model.ProcessId,
                            StaffId = staffId,
                            CreatedBy = currentUser,
                            CreatedDate = DateTime.Now
                        };

                        await _unitOfWork.ProcessEmployeeAssigns.CreateAsync(entity);
                    }
                }
                else
                {
                    // UPDATE

                    // Remove all existing assignments for this Week + Process
                    var oldAssignments = await _unitOfWork.ProcessEmployeeAssigns
                        .GetQueryable()
                        .Where(x => x.WeekNo == model.WeekNo &&
                                    x.ProcessId == model.ProcessId)
                        .ToListAsync();

                    foreach (var item in oldAssignments)
                    {
                        await _unitOfWork.ProcessEmployeeAssigns.DeleteAsync(item);
                    }

                    // Insert newly selected employees
                    foreach (var staffId in model.SelectedStaffIds)
                    {
                        var entity = new ProcessEmployeeAssign
                        {
                            WeekNo = model.WeekNo,
                            fromDate = model.fromDate,
                            toDate = model.toDate,
                            ProcessId = model.ProcessId,
                            StaffId = staffId,
                            CreatedBy = currentUser,
                            CreatedDate = DateTime.Now
                        };

                        await _unitOfWork.ProcessEmployeeAssigns.CreateAsync(entity);
                    }
                }

                await _unitOfWork.SaveAsync();

                return 1;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex,
                    "Error occurred while upserting process employee assignment");

                return 0;
            }
        }

        public async Task<(List<ProcessEmployeeAssignVM> processes, int TotalCount)> SearchWithDynamicFilterAsync(int pageNumber, int pageSize, Dictionary<string, object>? filters)
        {
            try
            {
                // Base query
                var query = _unitOfWork.ProcessEmployeeAssigns
                    .GetQueryable()
                    .Include(x => x.Process)
                    .Include(x => x.Staff)
                    .AsQueryable();

                // Apply filters BEFORE GroupBy
                if (filters != null)
                {
                    foreach (var f in filters)
                    {
                        query = DynamicWhereBuilder.ApplyFilter(
                            query,
                            f.Key,
                            f.Value);
                    }
                }

                // Group the records
                var groupedQuery = query
                    .GroupBy(x => new
                    {
                        x.WeekNo,
                        x.fromDate,
                        x.toDate,
                        x.ProcessId,
                        x.Process.ProcessName
                    })
                    .Select(g => new ProcessEmployeeAssignVM
                    {
                        AssignmentId = g.Min(x => x.AssignmentId),
                        WeekNo = g.Key.WeekNo,
                        fromDate = g.Key.fromDate,
                        toDate = g.Key.toDate,
                        ProcessId = g.Key.ProcessId,
                        ProcessName = g.Key.ProcessName
                    });

                // Count AFTER grouping
                var total = await groupedQuery.CountAsync();

                // Apply ordering + pagination BEFORE ToListAsync
                var list = await groupedQuery
                    .OrderByDescending(x => x.AssignmentId)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return (list, total);
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error occurred while searching process employee assignments with dynamic filters");
                return (new List<ProcessEmployeeAssignVM>(), 0);
            }
        }


        public static class DynamicWhereBuilder
        {
            public static IQueryable<ProcessEmployeeAssign> ApplyFilter(
                IQueryable<ProcessEmployeeAssign> query, string field, object value)
            {
                if (value == null) return query;

                switch (field)
                {
                    //case "ProcessName":
                    //    return query.Where(x => x.ProcessName.Contains(value.ToString()));

                    //case "CreatedBy":
                    //    return query.Where(x => x.CreatedBy.Contains(value.ToString()));

                    //case "FromDate":
                    //    return query.Where(x => x.CreatedDate >= DateTime.Parse(value.ToString()));

                    //case "ToDate":
                    //    return query.Where(x => x.CreatedDate <= DateTime.Parse(value.ToString()));
                }

                return query;
            }


        }

        public async Task<(bool CanDelete, string Message)> CanDeleteProcessAsync(int processId)
        {
            try
            {
                //var process = await _unitOfWork.Processes
                //    .GetQueryable()
                //    .FirstOrDefaultAsync(s => s.ProcessId == processId);

                //if (process == null)
                //    return (false, "Process not found or already removed.");

                //var usedIn = await _fkChecker.GetUsageTableAsync<Process>(processId);

                //if (usedIn != null)
                //    return (false, $"Cannot delete store '{process.ProcessName}' because it is used in {usedIn}.");

                return (true, $"Process  can be safely deleted.");
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Process delete validation failed: {processId}");
                return (false, "Unexpected error occurred while validating Process.");
            }
        }

        public async Task<ProcessEmployeeAssignVM> GetProcessEmployeeAssignByIdAsync(int assignmentId)
        {
            try
            {
                var entity = await _unitOfWork.ProcessEmployeeAssigns
                              .GetQueryable()
                              .Include(x => x.Process)
                              .Include(x => x.Staff)
                              .FirstOrDefaultAsync(x => x.AssignmentId == assignmentId);

                if (entity == null)
                    return null;

                var vm = _mapper.Map<ProcessEmployeeAssignVM>(entity);

                vm.SelectedStaffIds = await _unitOfWork.ProcessEmployeeAssigns
                    .GetQueryable()
                    .Where(x => x.WeekNo == entity.WeekNo &&
                                x.ProcessId == entity.ProcessId)
                    .Select(x => x.StaffId)
                    .ToListAsync();

                return vm;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Error occurred while retrieving process employee assignment with ID: {assignmentId}");
                return null;
            }
        } 

        public async Task<bool> DeleteAsync(int weekNo, int processId)
        {
            try
            {
                var entities = await _unitOfWork.ProcessEmployeeAssigns
                    .GetQueryable()
                    .Where(x => x.WeekNo == weekNo &&
                                x.ProcessId == processId)
                    .ToListAsync();

                if (!entities.Any())
                    return false;

                foreach (var item in entities)
                {
                    await _unitOfWork.ProcessEmployeeAssigns.DeleteAsync(item);
                }

                await _unitOfWork.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Error occurred while deleting process employee assignments for WeekNo: {weekNo}, ProcessId: {processId}");
                return false;
            }
        }
    }
}
