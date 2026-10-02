using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.ViewModels.LiveDashBoardVM;

namespace V.SMART.Shared.Services
{
    public class ErpDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ErpDashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErpDashboardVM> GetDashboardAsync()
        {
            var dashboard = new ErpDashboardVM();

            await LoadProductionAsync(dashboard);
            await LoadLogsAsync(dashboard);

            return dashboard;
        }
        private async Task LoadProductionAsync(ErpDashboardVM dashboard)
        {
            // =====================================================
            // TODAY DATE RANGE
            // 00:00:00 TODAY -> 00:00:00 TOMORROW
            // Includes complete AM + PM data
            // =====================================================

            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            // =====================================================
            // ROUTE CARD QUERY
            // =====================================================

            var routeCardQuery = _unitOfWork.RouteCards
                .GetQueryable()
                .AsNoTracking();

            var todayRouteQuery = routeCardQuery
                .Where(x =>
                    x.CreatedDate >= today &&
                    x.CreatedDate < tomorrow);

            // =====================================================
            // PRODUCTION LOG QUERY
            // =====================================================

            var productionLogQuery = _unitOfWork.ProductionLogs
                .GetQueryable()
                .AsNoTracking();

            var todayLogQuery = productionLogQuery
                .Where(x =>
                    x.CreatedDate >= today &&
                    x.CreatedDate < tomorrow);

            // =====================================================
            // TODAY TOTAL PRODUCTION
            // =====================================================

            dashboard.ProductionToday =
                await todayLogQuery
                    .SumAsync(x =>
                        (decimal?)(
                            x.AccQty +
                            x.RejQty +
                            x.RewQty)) ?? 0m;

            // =====================================================
            // TODAY REWORK COUNT
            // =====================================================

            dashboard.ReworkCount =
                await todayLogQuery
                    .CountAsync(x => x.RewQty > 0);

            // =====================================================
            // TODAY REJECTION COUNT
            // =====================================================

            dashboard.RejectionCount =
                await todayLogQuery
                    .CountAsync(x => x.RejQty > 0);

            // =====================================================
            // TODAY ROUTE CARDS GENERATED
            // =====================================================

            dashboard.RouteCardsGeneratedToday =
                await todayRouteQuery
                    .CountAsync();

            // =====================================================
            // TODAY PENDING PRODUCTION
            // =====================================================

            dashboard.PendingProduction =
                await todayRouteQuery
                    .CountAsync(x =>
                        x.RcQty > 0 &&
                        x.RouteCardSubs.Any(sub =>
                            !sub.IsProcessSkip &&
                            sub.BalQty > 0));

            // =====================================================
            // TODAY COMPLETED ROUTE CARDS
            // =====================================================

            dashboard.CompletedRouteCards =
                await todayRouteQuery
                    .CountAsync(x =>
                        x.RcQty > 0 &&

                        x.RouteCardSubs.Any(sub =>
                            !sub.IsProcessSkip) &&

                        !x.RouteCardSubs.Any(sub =>
                            !sub.IsProcessSkip &&
                            sub.BalQty > 0));

            // =====================================================
            // TODAY ROUTE CARD DETAILS
            // =====================================================

            dashboard.TodayRouteCards =
                await todayRouteQuery
                    .Include(x => x.RouteCardSubs)
                    .Include(x => x.Customer)
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new RouteCardDetailVM
                    {
                        DocumentNo =
                            x.RCNo + x.Suffix,

                        CustomerName =
                            x.Customer != null
                                ? x.Customer.CustName
                                : "Unknown",

                        RouteCardQty =
                            x.RcQty,

                        Status =
                            // REWORK
                            x.RouteCardSubs.Any(s =>
                                !s.IsProcessSkip &&
                                s.RewQty > 0)
                                ? "Rework"

                            // CANCELLED
                            : x.RcStatus == 3
                                ? "Cancelled"

                            // COMPLETED
                            : x.RcStatus == 2
                                ? "Completed"

                            // WORK IN PROGRESS
                            : x.RcStatus == 1
                                ? "Work-In-Progress"

                            // PENDING
                            : "Pending",

                        CreatedTime =
                            x.CreatedDate
                    })
                    .ToListAsync();

            // =====================================================
            // OPERATOR-WISE TODAY PRODUCTION
            // ALL OPERATORS
            // =====================================================

            var operatorData =
                await todayLogQuery
                    .GroupBy(x => x.Operator)
                    .Select(g => new
                    {
                        OperatorName =
                            g.Key ?? "Unknown",

                        Quantity =
                            g.Sum(x =>
                                (decimal)(
                                    x.AccQty +
                                    x.RejQty +
                                    x.RewQty)),

                        AcceptedQty =
                            g.Sum(x =>
                                (decimal)x.AccQty),

                        RejectedQty =
                            g.Sum(x =>
                                (decimal)x.RejQty),

                        ReworkQty =
                            g.Sum(x =>
                                (decimal)x.RewQty),

                        LogCount =
                            g.Count(),

                        Efficiency =
                            g.Average(x =>
                                (decimal?)x.EfficiencyPercent) ?? 0m
                    })
                    .OrderByDescending(x => x.Quantity)
                    .ToListAsync();

            // =====================================================
            // MAP OPERATOR DATA
            // =====================================================

            dashboard.OperatorProductionToday =
                operatorData
                    .Select(x => new OperatorProductionVM
                    {
                        OperatorName =
                            x.OperatorName,

                        Quantity =
                            x.Quantity,

                        AcceptedQty =
                            x.AcceptedQty,

                        RejectedQty =
                            x.RejectedQty,

                        ReworkQty =
                            x.ReworkQty,

                        LogCount =
                            x.LogCount,

                        Efficiency =
                            x.Efficiency
                    })
                    .ToList();

            // =====================================================
            // MACHINE-WISE TODAY PRODUCTION
            // ALL MACHINES
            // =====================================================

            var machineData =
                await todayLogQuery
                    .Include(x => x.Machine)
                    .GroupBy(x => new
                    {
                        x.MachineId,

                        MachineName =
                            x.Machine != null
                                ? x.Machine.MachineName
                                : "Unknown Machine"
                    })
                    .Select(g => new
                    {
                        MachineId =
                            g.Key.MachineId,

                        MachineName =
                            g.Key.MachineName,

                        Quantity =
                            g.Sum(x =>
                                (decimal)(
                                    x.AccQty +
                                    x.RejQty +
                                    x.RewQty)),

                        AcceptedQty =
                            g.Sum(x =>
                                (decimal)x.AccQty),

                        RejectedQty =
                            g.Sum(x =>
                                (decimal)x.RejQty),

                        ReworkQty =
                            g.Sum(x =>
                                (decimal)x.RewQty),

                        LogCount =
                            g.Count(),

                        Efficiency =
                            g.Average(x =>
                                (decimal?)x.EfficiencyPercent) ?? 0m
                    })
                    .OrderByDescending(x => x.Quantity)
                    .ToListAsync();

            // =====================================================
            // MAP MACHINE DATA
            // =====================================================

            dashboard.MachineProductionToday =
                machineData
                    .Select(x => new MachineProductionVM
                    {
                        MachineId =
                            x.MachineId ?? 0,

                        MachineName =
                            x.MachineName,

                        Quantity =
                            x.Quantity,

                        AcceptedQty =
                            x.AcceptedQty,

                        RejectedQty =
                            x.RejectedQty,

                        ReworkQty =
                            x.ReworkQty,

                        LogCount =
                            x.LogCount,

                        Efficiency =
                            x.Efficiency
                    })
                    .ToList();

            // =====================================================
            // OPERATION-WISE TODAY PRODUCTION
            // ALL OPERATIONS
            // =====================================================

            var operationData =
                await todayLogQuery
                    .Include(x => x.Process)
                    .GroupBy(x => new
                    {
                        ProcessId =
                            x.Process != null
                                ? x.Process.ProcessId
                                : 0,

                        ProcessName =
                            x.Process != null
                                ? x.Process.ProcessName
                                : "Unknown Process"
                    })
                    .Select(g => new
                    {
                        ProcessId =
                            g.Key.ProcessId,

                        OperationName =
                            g.Key.ProcessName,

                        Quantity =
                            g.Sum(x =>
                                (decimal)(
                                    x.AccQty +
                                    x.RejQty +
                                    x.RewQty)),

                        AcceptedQty =
                            g.Sum(x =>
                                (decimal)x.AccQty),

                        RejectedQty =
                            g.Sum(x =>
                                (decimal)x.RejQty),

                        ReworkQty =
                            g.Sum(x =>
                                (decimal)x.RewQty),

                        LogCount =
                            g.Count(),

                        Efficiency =
                            g.Average(x =>
                                (decimal?)x.EfficiencyPercent) ?? 0m
                    })
                    .OrderByDescending(x => x.Quantity)
                    .ToListAsync();

            // =====================================================
            // MAP OPERATION DATA
            // =====================================================

            dashboard.OperationProductionToday =
                operationData
                    .Select(x => new OperationProductionVM
                    {
                        OperationName =
                            x.OperationName,

                        Quantity =
                            x.Quantity,

                        AcceptedQty =
                            x.AcceptedQty,

                        RejectedQty =
                            x.RejectedQty,

                        ReworkQty =
                            x.ReworkQty,

                        LogCount =
                            x.LogCount,

                        Efficiency =
                            x.Efficiency
                    })
                    .ToList();

            // =====================================================
            // HOURLY PRODUCTION
            // TODAY ONLY
            // =====================================================

            var hourlyData =
                await todayLogQuery
                    .GroupBy(x => x.CreatedDate.Hour)
                    .Select(g => new
                    {
                        Hour =
                            g.Key,

                        Quantity =
                            g.Sum(x =>
                                (decimal)(
                                    x.AccQty +
                                    x.RejQty +
                                    x.RewQty))
                    })
                    .ToListAsync();

            // =====================================================
            // 24-HOUR PRODUCTION GRAPH
            //
            // 12:00 AM
            // 01:00 AM
            // ...
            // 11:00 AM
            // 12:00 PM
            // ...
            // 11:00 PM
            // =====================================================

            dashboard.ProductionHourlyGraph.Clear();

            for (int hour = 0; hour < 24; hour++)
            {
                var result =
                    hourlyData.FirstOrDefault(x =>
                        x.Hour == hour);

                dashboard.ProductionHourlyGraph.Add(
                    new DashboardGraphVM
                    {
                        Label =
                            today
                                .AddHours(hour)
                                .ToString("hh:mm tt"),

                        Value =
                            result?.Quantity ?? 0m
                    });
            }

            // =====================================================
            // MAIN PRODUCTION GRAPH
            // TODAY 24 HOURS ONLY
            // =====================================================

            dashboard.ProductionGraph.Clear();

            for (int hour = 0; hour < 24; hour++)
            {
                var result =
                    hourlyData.FirstOrDefault(x =>
                        x.Hour == hour);

                dashboard.ProductionGraph.Add(
                    new DashboardGraphVM
                    {
                        Label =
                            today
                                .AddHours(hour)
                                .ToString("hh:mm tt"),

                        Value =
                            result?.Quantity ?? 0m
                    });
            }
        }
        //private async Task LoadProductionAsync(ErpDashboardVM dashboard)
        //{
        //    var today = DateTime.Today;
        //    var tomorrow = today.AddDays(1);
        //    var sevenDaysAgo = today.AddDays(-6);

        //    var routeCardQuery = _unitOfWork.RouteCards
        //        .GetQueryable()
        //        .AsNoTracking();

        //    var todayRouteQuery = routeCardQuery
        //        .Where(x =>
        //            x.CreatedDate >= today &&
        //            x.CreatedDate < tomorrow);



        //    var productionLogQuery = _unitOfWork.ProductionLogs
        //        .GetQueryable()
        //        .AsNoTracking();

        //    var todayLogQuery = productionLogQuery
        //        .Where(x =>
        //            x.CreatedDate >= today &&
        //            x.CreatedDate < tomorrow);



        //    dashboard.ProductionToday =
        //        await todayLogQuery
        //            .SumAsync(x =>
        //                (decimal?)(
        //                    x.AccQty +
        //                    x.RejQty +
        //                    x.RewQty)) ?? 0m;

        //    dashboard.ReworkCount =
        //        await todayLogQuery
        //            .CountAsync(x => x.RewQty > 0);


        //    dashboard.RejectionCount =
        //        await todayLogQuery
        //            .CountAsync(x => x.RejQty > 0);

        //    dashboard.RouteCardsGeneratedToday =
        //        await todayRouteQuery.CountAsync();


        //    dashboard.PendingProduction =
        //        await todayRouteQuery
        //            .CountAsync(x =>
        //                x.RcQty > 0 &&
        //                x.RouteCardSubs.Any(sub =>
        //                    !sub.IsProcessSkip &&
        //                    sub.BalQty > 0));


        //    dashboard.CompletedRouteCards =
        //        await todayRouteQuery
        //            .CountAsync(x =>
        //                x.RcQty > 0 &&

        //                x.RouteCardSubs.Any(sub =>
        //                    !sub.IsProcessSkip) &&

        //                !x.RouteCardSubs.Any(sub =>
        //                    !sub.IsProcessSkip &&
        //                    sub.BalQty > 0));

        //    dashboard.TodayRouteCards =
        //        await todayRouteQuery
        //            .Include(x => x.RouteCardSubs)
        //            .Include(x => x.Customer)
        //            .OrderByDescending(x => x.CreatedDate)
        //            .Select(x => new RouteCardDetailVM
        //            {
        //                DocumentNo = x.RCNo + x.Suffix,

        //                CustomerName =
        //                    x.Customer != null
        //                        ? x.Customer.CustName
        //                        : "Unknown",

        //                RouteCardQty = x.RcQty,

        //                Status =
        //        x.RouteCardSubs.Any(s =>
        //            !s.IsProcessSkip &&
        //            s.RewQty > 0)
        //            ? "Rework"

        //            : x.RcStatus == 3
        //                ? "Cancelled"

        //            : x.RcStatus == 2
        //                ? "Completed"

        //            : x.RcStatus == 1
        //                ? "Work-In-Progress"

        //            : "Pending",

        //                CreatedTime = x.CreatedDate
        //            })
        //            .ToListAsync();

        //    var operatorData =
        //        await todayLogQuery
        //            .GroupBy(x => x.Operator)
        //            .Select(g => new
        //            {
        //                OperatorName =
        //                    g.Key ?? "Unknown",

        //                Quantity =
        //                    g.Sum(x =>
        //                        (decimal)(
        //                            x.AccQty +
        //                            x.RejQty +
        //                            x.RewQty)),

        //                AcceptedQty =
        //                    g.Sum(x =>
        //                        (decimal)x.AccQty),

        //                RejectedQty =
        //                    g.Sum(x =>
        //                        (decimal)x.RejQty),

        //                ReworkQty =
        //                    g.Sum(x =>
        //                        (decimal)x.RewQty),

        //                LogCount =
        //                    g.Count(),

        //                Efficiency =
        //                    g.Average(x =>
        //                        (decimal?)x.EfficiencyPercent) ?? 0m
        //            })
        //            .OrderByDescending(x => x.Quantity)
        //            .Take(10)
        //            .ToListAsync();


        //    dashboard.OperatorProductionToday =
        //        operatorData
        //            .Select(x => new OperatorProductionVM
        //            {
        //                OperatorName = x.OperatorName,

        //                Quantity = x.Quantity,

        //                AcceptedQty = x.AcceptedQty,

        //                RejectedQty = x.RejectedQty,

        //                ReworkQty = x.ReworkQty,

        //                LogCount = x.LogCount,

        //                Efficiency = x.Efficiency
        //            })
        //            .ToList();

        //    var machineData =
        //        await todayLogQuery
        //            .Include(x => x.Machine)
        //            .GroupBy(x => new
        //            {
        //                x.MachineId,

        //                MachineName =
        //                    x.Machine != null
        //                        ? x.Machine.MachineName
        //                        : "Unknown Machine"
        //            })
        //            .Select(g => new
        //            {
        //                MachineId = g.Key.MachineId,

        //                MachineName = g.Key.MachineName,

        //                Quantity =
        //                    g.Sum(x =>
        //                        (decimal)(
        //                            x.AccQty +
        //                            x.RejQty +
        //                            x.RewQty)),

        //                AcceptedQty =
        //                    g.Sum(x =>
        //                        (decimal)x.AccQty),

        //                RejectedQty =
        //                    g.Sum(x =>
        //                        (decimal)x.RejQty),

        //                ReworkQty =
        //                    g.Sum(x =>
        //                        (decimal)x.RewQty),

        //                LogCount =
        //                    g.Count(),

        //                Efficiency =
        //                    g.Average(x =>
        //                        (decimal?)x.EfficiencyPercent) ?? 0m
        //            })
        //            .OrderByDescending(x => x.Quantity)
        //            .Take(10)
        //            .ToListAsync();


        //    dashboard.MachineProductionToday =
        //        machineData
        //            .Select(x => new MachineProductionVM
        //            {
        //                MachineId =
        //                    x.MachineId ?? 0,

        //                MachineName =
        //                    x.MachineName,

        //                Quantity =
        //                    x.Quantity,

        //                AcceptedQty =
        //                    x.AcceptedQty,

        //                RejectedQty =
        //                    x.RejectedQty,

        //                ReworkQty =
        //                    x.ReworkQty,

        //                LogCount =
        //                    x.LogCount,

        //                Efficiency =
        //                    x.Efficiency
        //            })
        //            .ToList();


        //    var operationData =
        //        await todayLogQuery
        //            .Include(x => x.Process)
        //            .GroupBy(x => new
        //            {
        //                ProcessId =
        //                    x.Process != null
        //                        ? x.Process.ProcessId
        //                        : 0,

        //                ProcessName =
        //                    x.Process != null
        //                        ? x.Process.ProcessName
        //                        : "Unknown Process"
        //            })
        //            .Select(g => new
        //            {
        //                ProcessId =
        //                    g.Key.ProcessId,

        //                OperationName =
        //                    g.Key.ProcessName,

        //                Quantity =
        //                    g.Sum(x =>
        //                        (decimal)(
        //                            x.AccQty +
        //                            x.RejQty +
        //                            x.RewQty)),

        //                AcceptedQty =
        //                    g.Sum(x =>
        //                        (decimal)x.AccQty),

        //                RejectedQty =
        //                    g.Sum(x =>
        //                        (decimal)x.RejQty),

        //                ReworkQty =
        //                    g.Sum(x =>
        //                        (decimal)x.RewQty),

        //                LogCount =
        //                    g.Count(),

        //                Efficiency =
        //                    g.Average(x =>
        //                        (decimal?)x.EfficiencyPercent) ?? 0m
        //            })
        //            .OrderByDescending(x => x.Quantity)
        //            .Take(10)
        //            .ToListAsync();


        //    dashboard.OperationProductionToday =
        //        operationData
        //            .Select(x => new OperationProductionVM
        //            {
        //                OperationName =
        //                    x.OperationName,

        //                Quantity =
        //                    x.Quantity,

        //                AcceptedQty =
        //                    x.AcceptedQty,

        //                RejectedQty =
        //                    x.RejectedQty,

        //                ReworkQty =
        //                    x.ReworkQty,

        //                LogCount =
        //                    x.LogCount,

        //                Efficiency =
        //                    x.Efficiency
        //            })
        //            .ToList();


        //    var hourlyData =
        //        await todayLogQuery
        //            .GroupBy(x => x.CreatedDate.Hour)
        //            .Select(g => new
        //            {
        //                Hour = g.Key,

        //                Quantity =
        //                    g.Sum(x =>
        //                        (decimal)(
        //                            x.AccQty +
        //                            x.RejQty +
        //                            x.RewQty))
        //            })
        //            .OrderBy(x => x.Hour)
        //            .ToListAsync();


        //    dashboard.ProductionHourlyGraph =
        //        hourlyData
        //            .Select(x => new DashboardGraphVM
        //            {
        //                Label =
        //                    $"{x.Hour:00}:00",

        //                Value =
        //                    x.Quantity
        //            })
        //            .ToList();

        //    var sevenDayData =
        //        await productionLogQuery
        //            .Where(x =>
        //                x.CreatedDate >= sevenDaysAgo &&
        //                x.CreatedDate < tomorrow)
        //            .GroupBy(x => x.CreatedDate.Date)
        //            .Select(g => new
        //            {
        //                Date = g.Key,

        //                Quantity =
        //                    g.Sum(x =>
        //                        (decimal)(
        //                            x.AccQty +
        //                            x.RejQty +
        //                            x.RewQty))
        //            })
        //            .ToListAsync();


        //    dashboard.ProductionGraph.Clear();


        //    for (int i = 6; i >= 0; i--)
        //    {
        //        var date =
        //            today.AddDays(-i);

        //        var result =
        //            sevenDayData.FirstOrDefault(x =>
        //                x.Date == date);

        //        dashboard.ProductionGraph.Add(
        //            new DashboardGraphVM
        //            {
        //                Label =
        //                    date == today
        //                        ? "Today"
        //                        : date.ToString("ddd"),

        //                Value =
        //                    result?.Quantity ?? 0m
        //            });
        //    }
        //}


        // =====================================================
        // RECENT PRODUCTION LOGS
        // =====================================================

        private async Task LoadLogsAsync(
            ErpDashboardVM dashboard)
        {
            try
            {
                var query =
                    _unitOfWork
                        .ProductionLogs
                        .GetQueryable()
                        .AsNoTracking()
                        .Include(x => x.RouteCard);


                dashboard.RecentActivities =
                    await query
                        .OrderByDescending(x => x.CreatedDate)
                        .Take(20)
                        .Select(x =>
                            new ActivityLogVM
                            {
                                Time =
                                    x.CreatedDate
                                        .ToString("HH:mm:ss"),

                                DocumentNo =
                                    x.LogNo,

                                Activity =
                                    x.RouteCard != null
                                        ? x.RouteCard.RCNo
                                        : "",

                                UserName =
                                    x.Operator ?? ""
                            })
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Production log error: {ex}");

                dashboard.RecentActivities =
                    new List<ActivityLogVM>();
            }
        }
    }
}