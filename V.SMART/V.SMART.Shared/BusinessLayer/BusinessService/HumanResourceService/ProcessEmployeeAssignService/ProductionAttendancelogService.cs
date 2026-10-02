using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IInventoryService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IProductionService.IProductionAttendancelogService;
using V.SMART.Shared.Data.HumanResource.ProcessEmployeeAssign;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.HumanResourceViewModel.ProcessEmployeeAssignVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.ProductionService.ProductionAttendanceService.cs
{
    public class ProductionAttendancelogService : IProductionAttendancelogService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly ILoggingService _logs;
        private readonly IMapper _mapper;
        private readonly IStockManagerService _stockManagerService;




        public ProductionAttendancelogService(
                 IUnitOfWork unitOfWork,
                 ICommonService commonService,
                 CurrentUserService userService,
                 IStockManagerService stockManagerService,
                 ILoggingService logs,
                 IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
            _currentUserService = userService;
            _stockManagerService = stockManagerService;
            _logs = logs;
            _mapper = mapper;
        }

        public async Task<List<ProcessEmployeeAssignVM>> GetAllWeeks()
        {
            try
            {
                var data = await _unitOfWork.ProcessEmployeeAssigns
                                             .GetQueryable()
                                             .Include(x => x.Process)
                                             .Where(x => !_unitOfWork.ProductionAttendancelogs
                                                 .GetQueryable()
                                                 .Any(a => a.WeekNo == x.WeekNo &&
                                                           a.ProcessId == x.ProcessId))
                                             .GroupBy(x => new
                                             {
                                                 x.WeekNo,
                                                 x.ProcessId,
                                                 x.fromDate,
                                                 x.toDate
                                             })
                                             .Select(g => g.First())
                                             .ToListAsync();

                return _mapper.Map<List<ProcessEmployeeAssignVM>>(data);
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error occurred while retrieving weeks.");
                throw;
            }
        }

        public async Task<List<ProductionAttendancelogVM>> GetAssignedEmployeesAsync(int weekNo, int processId)
        {
            var employees = await _unitOfWork.ProcessEmployeeAssigns
                .GetQueryable()
                .Where(x => x.WeekNo == weekNo &&
                            x.ProcessId == processId)
                .Include(x => x.Staff)
                .Select(x => new ProductionAttendancelogVM
                {
                    StaffId = x.StaffId,
                    StaffName = x.Staff.StaffName
                })
                .ToListAsync();

            foreach (var emp in employees)
            {
                emp.Days = CreateDays();
                emp.ProcessId = processId;
                emp.WeekNo = weekNo;
            }

            return employees;
        }

        private static List<AttendanceDayVM> CreateDays()
        {
            var list = new List<AttendanceDayVM>();

            for (int i = 0; i < 7; i++)
            {
                list.Add(new AttendanceDayVM
                {
                    AttendanceDate = i + 1,
                    Status = "",
                    InTime = "",
                    OutTime = "",
                    OT = "0.00"
                });
            }

            return list;
        }

        public async Task<int> SaveAttendanceAsync(List<ProductionAttendancelogVM> attendance)
        {
            try
            {
                var currentUser = await _currentUserService.GetUsernameAsync();

                foreach (var item in attendance)
                {
                    var entity = await _unitOfWork.ProductionAttendancelogs
                        .GetQueryable()
                        .FirstOrDefaultAsync(x =>
                            x.WeekNo == item.WeekNo &&
                            x.ProcessId == item.ProcessId &&
                            x.StaffId == item.StaffId);

                    if (entity == null)
                    {
                        entity = new ProductionAttendancelog
                        {
                            WeekNo = item.WeekNo,
                            ProcessId = item.ProcessId,
                            StaffId = item.StaffId,
                            CreatedBy = currentUser,
                            CreatedDate = DateTime.Now
                        };

                        entity.Ldetail = string.Join(",", item.Days.Select(x => x.Status ?? ""));
                        entity.InTime = string.Join(",", item.Days.Select(x => x.InTime ?? ""));
                        entity.OutTime = string.Join(",", item.Days.Select(x => x.OT ?? ""));
                        entity.OtDetail = string.Join(",", item.Days.Select(x => x.OT ?? "0"));

                        await _unitOfWork.ProductionAttendancelogs.CreateAsync(entity);
                    }
                    else
                    {
                        entity.Ldetail = string.Join(",", item.Days.Select(x => x.Status ?? ""));
                        entity.InTime = string.Join(",", item.Days.Select(x => x.InTime ?? ""));
                        entity.OutTime = string.Join(",", item.Days.Select(x => x.OutTime ?? ""));
                        entity.OtDetail = string.Join(",", item.Days.Select(x => x.OT ?? "0"));

                        entity.ModifiedBy = currentUser;
                        entity.ModifiedDate = DateTime.Now;

                        await _unitOfWork.ProductionAttendancelogs.UpdateAsync(entity);
                    }
                }

                await _unitOfWork.SaveAsync();
                return 1;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "SaveAttendanceAsync");
                return 0;
            }
        }

        public async Task<(List<ProductionAttendancelogVM> Attendance, int TotalCount)> SearchAttendanceAsync(int pageNumber,int pageSize,Dictionary<string, object>? filters)
        {
            try
            {
                var data = await _unitOfWork.ProductionAttendancelogs
                    .GetQueryable()
                    .Include(x => x.Process)
                    .Include(x => x.Staff)
                    .ToListAsync();

                // Apply filters here if required

                var grouped = data
                    .GroupBy(x => new { x.WeekNo, x.ProcessId })
                    .Select(g => g.OrderByDescending(x => x.CreatedDate).First())
                    .OrderByDescending(x => x.CreatedDate)
                    .ToList();

                var total = grouped.Count;

                var list = grouped
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(x => new ProductionAttendancelogVM
                    {
                        Id = x.Id,
                        WeekNo = x.WeekNo,
                        ProcessId = x.ProcessId,
                        ProcessName = x.Process?.ProcessName,
                        StaffId = x.StaffId,
                        StaffName = x.Staff?.StaffName,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate
                    })
                    .ToList();

                return (list, total);
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "SearchAttendanceAsync");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int weekNo, int processId)
        {
            try
            {
                var entities = await _unitOfWork.ProductionAttendancelogs
                    .GetQueryable()
                    .Where(x => x.WeekNo == weekNo &&
                                x.ProcessId == processId)
                    .ToListAsync();

                if (!entities.Any())
                    return false;

                foreach (var item in entities)
                {
                    await _unitOfWork.ProductionAttendancelogs.DeleteAsync(item);
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

        public async Task<List<ProductionAttendancelogVM>> GetByIdAsync(int id)
        {
            try
            {
                // Get the selected attendance row
                var selected = await _unitOfWork.ProductionAttendancelogs
                    .GetQueryable()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (selected == null)
                    return new List<ProductionAttendancelogVM>();

                // Get all employees for the same Week & Process
                var entities = await _unitOfWork.ProductionAttendancelogs
                    .GetQueryable()
                    .Include(x => x.Process)
                    .Include(x => x.Staff)
                    .Where(x => x.WeekNo == selected.WeekNo &&
                                x.ProcessId == selected.ProcessId)
                    .OrderBy(x => x.Staff.StaffName)
                    .ToListAsync();

                var result = new List<ProductionAttendancelogVM>();

                foreach (var entity in entities)
                {
                    var vm = new ProductionAttendancelogVM
                    {
                        Id = entity.Id,
                        WeekNo = entity.WeekNo,
                        ProcessId = entity.ProcessId,
                        ProcessName = entity.Process?.ProcessName,
                        StaffId = entity.StaffId,
                        StaffName = entity.Staff?.StaffName
                    };

                    var status = (entity.Ldetail ?? "").Split(',');
                    var inTime = (entity.InTime ?? "").Split(',');
                    var outTime = (entity.OutTime ?? "").Split(',');
                    var ot = (entity.OtDetail ?? "").Split(',');

                    vm.Days = new List<AttendanceDayVM>();

                    for (int i = 0; i < 7; i++)
                    {
                        vm.Days.Add(new AttendanceDayVM
                        {
                            AttendanceDate = i + 1,
                            Status = i < status.Length ? status[i] : "",
                            InTime = i < inTime.Length ? inTime[i] : "",
                            OutTime = i < outTime.Length ? outTime[i] : "",
                            OT = i < ot.Length ? ot[i] : "0"
                        });
                    }

                    result.Add(vm);
                }

                return result;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, $"Error retrieving Production Attendance. Id : {id}");
                return new List<ProductionAttendancelogVM>();
            }
        }

        public async Task<List<ProcessEmployeeAssignVM>> GetAllExistsWeeks()
        {
            try
            {
                var data = await _unitOfWork.ProcessEmployeeAssigns
                                             .GetQueryable()
                                             .Include(x => x.Process)
                                             .Include(x => x.Staff)
                                             .ToListAsync();

                return _mapper.Map<List<ProcessEmployeeAssignVM>>(data);
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex, "Error occurred while retrieving weeks.");
                throw;
            }
        }
    }
}
