using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.LiveDashBoardVM
{
    public class RouteCardDetailVM
    {
        public string DocumentNo { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public decimal RouteCardQty { get; set; }

        public string Status { get; set; } = "";

        public DateTime CreatedTime { get; set; }

        public string Time => CreatedTime.ToString("HH:mm:ss");
    }


    public class OperatorProductionVM
    {
        public string OperatorName { get; set; } = "";

        public decimal Quantity { get; set; }

        public decimal AcceptedQty { get; set; }

        public decimal RejectedQty { get; set; }

        public decimal ReworkQty { get; set; }

        public int LogCount { get; set; }

        public decimal Efficiency { get; set; }
    }

    public class MachineProductionVM
    {
        public int MachineId { get; set; }

        public string MachineName { get; set; } = "";

        public decimal Quantity { get; set; }

        public decimal AcceptedQty { get; set; }

        public decimal RejectedQty { get; set; }

        public decimal ReworkQty { get; set; }

        public int LogCount { get; set; }

        public decimal Efficiency { get; set; }
    }

    // ============================================================
    // OPERATION PRODUCTION
    // ============================================================

    public class OperationProductionVM
    {
        public string OperationName { get; set; } = "";

        public decimal Quantity { get; set; }

        public decimal AcceptedQty { get; set; }

        public decimal RejectedQty { get; set; }

        public decimal ReworkQty { get; set; }

        public int LogCount { get; set; }

        public decimal Efficiency { get; set; }
    }


    // ============================================================
    // GRAPH
    // ============================================================

    public class DashboardGraphVM
    {
        public string Label { get; set; } = "";

        public decimal Value { get; set; }
    }


    // ============================================================
    // ACTIVITY
    // ============================================================

    public class ActivityLogVM
    {
        public string Time { get; set; } = "";

        public string DocumentNo { get; set; } = "";

        public string Activity { get; set; } = "";

        public string UserName { get; set; } = "";
    }


    // ============================================================
    // MAIN DASHBOARD
    // ============================================================

    public class ErpDashboardVM
    {
        public decimal ProductionToday { get; set; }

        public int PendingProduction { get; set; }

        public int CompletedRouteCards { get; set; }

        public int ReworkCount { get; set; }

        public int RejectionCount { get; set; }

        public int RouteCardsGeneratedToday { get; set; }


        // ---------------------------------------------------------
        // ROUTE CARDS
        // ---------------------------------------------------------

        public List<RouteCardDetailVM> TodayRouteCards { get; set; }
            = new();


        // ---------------------------------------------------------
        // OPERATOR
        // ---------------------------------------------------------

        public List<OperatorProductionVM> OperatorProductionToday { get; set; }
            = new();


        // ---------------------------------------------------------
        // MACHINE
        // ---------------------------------------------------------

        public List<MachineProductionVM> MachineProductionToday { get; set; }
            = new();


        // ---------------------------------------------------------
        // OPERATION
        // ---------------------------------------------------------

        public List<OperationProductionVM> OperationProductionToday { get; set; }
            = new();


        // ---------------------------------------------------------
        // HOURLY
        // ---------------------------------------------------------

        public List<DashboardGraphVM> ProductionHourlyGraph { get; set; }
            = new();


        // ---------------------------------------------------------
        // 7 DAY
        // ---------------------------------------------------------

        public List<DashboardGraphVM> ProductionGraph { get; set; }
            = new();


        // ---------------------------------------------------------
        // LOGS
        // ---------------------------------------------------------

        public List<ActivityLogVM> RecentActivities { get; set; }
            = new();
    }
}
