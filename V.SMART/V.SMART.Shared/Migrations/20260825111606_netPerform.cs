using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V.SMART.Shared.Migrations
{
    /// <inheritdoc />
    public partial class netPerform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "SubConDcOutSub",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Weightkgs",
                table: "SubConDcOutSub",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BoxSize",
                table: "PerformaInv",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossWt",
                table: "PerformaInv",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NetWt",
                table: "PerformaInv",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "IsPrintRequired", "Navigation", "ScreenCode", "ScreenName" },
                values: new object[] { 166, false, "ProductionReport", 166, "Daily Log Summary" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "SubConDcOutSub");

            migrationBuilder.DropColumn(
                name: "Weightkgs",
                table: "SubConDcOutSub");

            migrationBuilder.DropColumn(
                name: "BoxSize",
                table: "PerformaInv");

            migrationBuilder.DropColumn(
                name: "GrossWt",
                table: "PerformaInv");

            migrationBuilder.DropColumn(
                name: "NetWt",
                table: "PerformaInv");
        }
    }
}
