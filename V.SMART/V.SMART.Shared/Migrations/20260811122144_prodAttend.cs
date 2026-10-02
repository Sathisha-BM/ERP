using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace V.SMART.Shared.Migrations
{
    /// <inheritdoc />
    public partial class prodAttend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemUnits",
                table: "MfgQuote",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Regards",
                table: "MfgQuote",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProcessEmployeeAssigns",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekNo = table.Column<int>(type: "int", nullable: false),
                    fromDate = table.Column<DateOnly>(type: "date", nullable: false),
                    toDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessEmployeeAssigns", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_ProcessEmployeeAssigns_Process_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Process",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessEmployeeAssigns_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionAttendancelog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekNo = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Ldetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionAttendancelog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionAttendancelog_Process_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Process",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionAttendancelog_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "IsPrintRequired", "Navigation", "ScreenCode", "ScreenName" },
                values: new object[,]
                {
                    { 160, false, "processemployeeassignlist", 160, "ProcessEmployeeAssign" },
                    { 161, false, "productionattendanceloglist", 161, "ProductionAttendancelog" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessEmployeeAssigns_ProcessId",
                table: "ProcessEmployeeAssigns",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessEmployeeAssigns_StaffId",
                table: "ProcessEmployeeAssigns",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionAttendancelog_ProcessId",
                table: "ProductionAttendancelog",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionAttendancelog_StaffId",
                table: "ProductionAttendancelog",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessEmployeeAssigns");

            migrationBuilder.DropTable(
                name: "ProductionAttendancelog");

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DropColumn(
                name: "ItemUnits",
                table: "MfgQuote");

            migrationBuilder.DropColumn(
                name: "Regards",
                table: "MfgQuote");
        }
    }
}
