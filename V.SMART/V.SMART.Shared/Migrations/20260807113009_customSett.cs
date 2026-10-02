using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace V.SMART.Shared.Migrations
{
    /// <inheritdoc />
    public partial class customSett : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Navigation",
                table: "Screens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CustomScreenSetting",
                columns: table => new
                {
                    CustomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomChildId = table.Column<int>(type: "int", nullable: false),
                    ScreenId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomScreenSetting", x => x.CustomId);
                });

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 1,
                column: "Navigation",
                value: "user");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 2,
                column: "Navigation",
                value: "category");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 3,
                column: "Navigation",
                value: "uom");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 4,
                column: "Navigation",
                value: "state");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 5,
                column: "Navigation",
                value: "currency");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 6,
                column: "Navigation",
                value: "userRights");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 7,
                column: "Navigation",
                value: "stores");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 8,
                column: "Navigation",
                value: "rawMaterialList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 9,
                column: "Navigation",
                value: "factorlist");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 10,
                column: "Navigation",
                value: "processList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 11,
                column: "Navigation",
                value: "machineList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 12,
                column: "Navigation",
                value: "groupingList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 13,
                column: "Navigation",
                value: "itemList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 14,
                column: "Navigation",
                value: "hsnMaster");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 15,
                column: "Navigation",
                value: "customer");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 16,
                column: "Navigation",
                value: "expense");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 17,
                column: "Navigation",
                value: "screenManagement");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 18,
                column: "Navigation",
                value: "vendor");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 19,
                column: "Navigation",
                value: "bomList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 20,
                column: "Navigation",
                value: "income");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 21,
                column: "Navigation",
                value: "currency_today");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 22,
                column: "Navigation",
                value: "bank");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 23,
                column: "Navigation",
                value: "myCompany");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 24,
                column: "Navigation",
                value: "correspondenceList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 25,
                column: "Navigation",
                value: "master-upload");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 26,
                column: "Navigation",
                value: "hrMaster/holidayList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 27,
                column: "Navigation",
                value: "Staff");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 28,
                column: "Navigation",
                value: "leaveType");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 29,
                column: "Navigation",
                value: "employeeLeaveBalance");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 30,
                column: "Navigation",
                value: "leaveApplication");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 31,
                column: "Navigation",
                value: "project-type-master");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 32,
                column: "Navigation",
                value: "costCenter");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 33,
                column: "Navigation",
                value: "userLevelAuthorization");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 34,
                column: "Navigation",
                value: "shiftAllocation");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 35,
                column: "Navigation",
                value: "");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 36,
                column: "Navigation",
                value: "mfgQuoteList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 37,
                column: "Navigation",
                value: "terms-and-conditions");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 38,
                column: "Navigation",
                value: "Leads");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 39,
                column: "Navigation",
                value: "enquirySales");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 40,
                column: "Navigation",
                value: "approval");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 41,
                column: "Navigation",
                value: "mfgPOList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 42,
                column: "Navigation",
                value: "mfgDcList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 43,
                column: "Navigation",
                value: "generalSettings");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 44,
                column: "Navigation",
                value: "store-map");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 45,
                column: "Navigation",
                value: "PerformaInvList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 46,
                column: "Navigation",
                value: "scnGenList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 47,
                column: "Navigation",
                value: "materialRequisitionList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 48,
                column: "Navigation",
                value: "minIssList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 49,
                column: "Navigation",
                value: "EnquiryPurchase");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 50,
                column: "Navigation",
                value: "materialReqAnalysis");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 51,
                column: "Navigation",
                value: "print-management");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 52,
                column: "Navigation",
                value: "enquiryFeasibility");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 53,
                column: "Navigation",
                value: "jobOrderList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 54,
                column: "Navigation",
                value: "productionIssueList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 55,
                column: "Navigation",
                value: "productionReturnAssyList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 56,
                column: "Navigation",
                value: "productionAssySCNList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 57,
                column: "Navigation",
                value: "tcIssueList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 58,
                column: "Navigation",
                value: "tcReturnList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 59,
                column: "Navigation",
                value: "instantSearch");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 60,
                column: "Navigation",
                value: "routeCardList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 61,
                column: "Navigation",
                value: "production-log-settings");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 62,
                column: "Navigation",
                value: "productionLogList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 63,
                column: "Navigation",
                value: "Process Flow-RC");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 64,
                column: "Navigation",
                value: "MaintenanceSchedule");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 65,
                column: "Navigation",
                value: "MaintenanceProcess");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 66,
                column: "Navigation",
                value: "BreakdownMaintenance");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 67,
                column: "Navigation",
                value: "CalibrationMaintenance");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 68,
                column: "Navigation",
                value: "productionCompIssueList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 69,
                column: "Navigation",
                value: "storeIntertransList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 70,
                column: "Navigation",
                value: "productionCompReturnList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 71,
                column: "Navigation",
                value: "productionCompSCNList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 72,
                column: "Navigation",
                value: "contractReviewMasterList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 73,
                column: "Navigation",
                value: "contractReviewCheckList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 74,
                column: "Navigation",
                value: "stockPosition");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 75,
                column: "Navigation",
                value: "purchaseQuoteList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 76,
                column: "Navigation",
                value: "PurchPOList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 77,
                column: "Navigation",
                value: "purchaseGRNList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 78,
                column: "Navigation",
                value: "purchaseSCNList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 79,
                column: "Navigation",
                value: "purchaseInvoiceList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 80,
                column: "Navigation",
                value: "mfgInvList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 81,
                column: "Navigation",
                value: "subConDcOutList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 82,
                column: "Navigation",
                value: "subConGrnList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 83,
                column: "Navigation",
                value: "subConScnList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 84,
                column: "Navigation",
                value: "subConInvList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 85,
                column: "Navigation",
                value: "expInvList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 86,
                column: "Navigation",
                value: "MasterInspection");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 87,
                column: "Navigation",
                value: "FinalInspection");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 88,
                column: "Navigation",
                value: "IncomingInspection");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 89,
                column: "Navigation",
                value: "InspectionSettings");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 90,
                column: "Navigation",
                value: "DefectInfo");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 91,
                column: "Navigation",
                value: "assemblyReqAnalysis");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 92,
                column: "Navigation",
                value: "labourGRNList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 93,
                column: "Navigation",
                value: "labourSCNList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 94,
                column: "Navigation",
                value: "labourDcoutgoingList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 95,
                column: "Navigation",
                value: "LabourInvoiceList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 96,
                column: "Navigation",
                value: "rcReleaseList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 97,
                column: "Navigation",
                value: "Excel Upload");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 98,
                column: "Navigation",
                value: "creditNoteList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 99,
                column: "Navigation",
                value: "print-management");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 100,
                column: "Navigation",
                value: "LabourCostManagement");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 101,
                column: "Navigation",
                value: "costcalculator");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 102,
                column: "Navigation",
                value: "SalesTrack");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 103,
                column: "Navigation",
                value: "debitNoteList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 104,
                column: "Navigation",
                value: "Tags");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 105,
                column: "Navigation",
                value: "labourTrack");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 106,
                column: "Navigation",
                value: "PaymentList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 107,
                column: "Navigation",
                value: "AdvanceAdjustmentList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 108,
                column: "Navigation",
                value: "ReceiptList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 109,
                column: "Navigation",
                value: "Fundtransactions");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 110,
                column: "Navigation",
                value: "dashboard");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 111,
                column: "Navigation",
                value: "StockLedger");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 112,
                column: "Navigation",
                value: "StockAnalysis");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 113,
                column: "Navigation",
                value: "dc-inout-report");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 114,
                column: "Navigation",
                value: "Pending_Bills");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 115,
                column: "Navigation",
                value: "PaidBills");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 116,
                column: "Navigation",
                value: "serviceBills");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 117,
                column: "Navigation",
                value: "SalesPoPending");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 118,
                column: "Navigation",
                value: "PendingStatements");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 119,
                column: "Navigation",
                value: "ToolCribReport");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 120,
                column: "Navigation",
                value: "ItemWiseReport");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 121,
                column: "Navigation",
                value: "confirmationaccounts");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 122,
                column: "Navigation",
                value: "stockPositionInternalExternal");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 123,
                column: "Navigation",
                value: "taxDetailsList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 124,
                column: "Navigation",
                value: "Profit_LossAccounts");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 125,
                column: "Navigation",
                value: "ItemModificationReport");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 126,
                column: "Navigation",
                value: "RejectionMaster");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 127,
                column: "Navigation",
                value: "Daybook");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 128,
                column: "Navigation",
                value: "labourpending");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 129,
                column: "Navigation",
                value: "po-tally");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 130,
                column: "Navigation",
                value: "ProductionPending");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 131,
                column: "Navigation",
                value: "Rejection");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 132,
                column: "Navigation",
                value: "GSTITC");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 133,
                column: "Navigation",
                value: "hr-hrmaster");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 134,
                column: "Navigation",
                value: "biometric-Excel");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 135,
                column: "Navigation",
                value: "print-salaryHeadSettings");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 136,
                column: "Navigation",
                value: "salaryList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 137,
                column: "Navigation",
                value: "attendanceList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 138,
                column: "Navigation",
                value: "staffLoanList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 139,
                column: "Navigation",
                value: "bomLabourList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 140,
                column: "Navigation",
                value: "Ratings");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 141,
                column: "Navigation",
                value: "Purchase-Sales_Track");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 142,
                column: "Navigation",
                value: "estimationList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 143,
                column: "Navigation",
                value: "RouteCardAnalysis");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 144,
                column: "Navigation",
                value: "stockIssReqList");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 145,
                column: "Navigation",
                value: "creditdebitSummaryReport");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 146,
                column: "Navigation",
                value: "tdsSummaryReport");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 147,
                column: "Navigation",
                value: "hsnCodeSummaryReport");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 148,
                column: "Navigation",
                value: "prpoRating");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 149,
                column: "Navigation",
                value: "candidate");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 150,
                column: "Navigation",
                value: "offer_Letter");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 151,
                column: "Navigation",
                value: "appointment_Letter");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 152,
                column: "Navigation",
                value: "joborderAnalysis");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 153,
                column: "Navigation",
                value: "Material_stockLeft");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 154,
                column: "Navigation",
                value: "qmsdocuments");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 155,
                column: "Navigation",
                value: "VendorPerformance");

            migrationBuilder.UpdateData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 156,
                column: "Navigation",
                value: "OperatorSummary");

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "IsPrintRequired", "Navigation", "ScreenCode", "ScreenName" },
                values: new object[,]
                {
                    { 157, false, "bomPRScn", 157, "BOM PRSCN" },
                    { 158, false, "summarygraphs", 158, "Summary and Graphs" },
                    { 159, false, "customscreensetting", 159, "CustomScreenSetting" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomScreenSetting");

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DropColumn(
                name: "Navigation",
                table: "Screens");
        }
    }
}
