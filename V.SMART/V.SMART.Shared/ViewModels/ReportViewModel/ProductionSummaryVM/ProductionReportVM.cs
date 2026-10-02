using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.ProdAssStatusVM
{
    public class ProductionReportVM
    {
        public int SlNo { get; set; }

        public DateTime ProductionDate { get; set; }

        public string ProductionNo { get; set; }

        public string Customer { get; set; }

        public string RouteCardNo { get; set; }

        public string PONo { get; set; }

        public string PODate { get; set; }

        public string MfgOrLab { get; set; }

        public string EntryType { get; set; }

        public string ItemCode { get; set; }

        public string Process { get; set; }

        public string Shift { get; set; }

        public string Machine { get; set; }

        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }

        public decimal WorkedHours { get; set; }

        public string Operator { get; set; }

        public decimal TargetQty { get; set; }

        public decimal ExpectedTargetQty { get; set; }

        public string GRNNo { get; set; }

        public decimal IssuedQty { get; set; }

        public decimal ProduceableQty { get; set; }

        public string SCNNo { get; set; }

        public decimal AcceptedQty { get; set; }

        public decimal RejectedQty { get; set; }

        public decimal ReworkQty { get; set; }

        public decimal BalQty { get; set; }

        public string? POLineNo { get; set; }

        //public string ReasonForRej { get; set; }

        public string LogDetail { get; set; }

        public decimal MachineIdleTime { get; set; }

        public decimal OperatorEfficiency { get; set; }

        public string Status { get; set; }
        public string? TransType { get; set; }


        //public decimal MachineEfficiency { get; set; }
    }
}
