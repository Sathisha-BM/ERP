using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V.SMART.Shared.Migrations
{
    /// <inheritdoc />
    public partial class inspectSat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefLabGRNSubId",
                table: "IncomingInspections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefSubconGRNSubId",
                table: "IncomingInspections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefLabDcSubID",
                table: "FinalInspection",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncomingInspections_RefLabGRNSubId",
                table: "IncomingInspections",
                column: "RefLabGRNSubId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingInspections_RefSubconGRNSubId",
                table: "IncomingInspections",
                column: "RefSubconGRNSubId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalInspection_RefLabDcSubID",
                table: "FinalInspection",
                column: "RefLabDcSubID");

            migrationBuilder.AddForeignKey(
                name: "FK_FinalInspection_LabourDcOutgoingSub_RefLabDcSubID",
                table: "FinalInspection",
                column: "RefLabDcSubID",
                principalTable: "LabourDcOutgoingSub",
                principalColumn: "DcSubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomingInspections_LabourGRNSub_RefLabGRNSubId",
                table: "IncomingInspections",
                column: "RefLabGRNSubId",
                principalTable: "LabourGRNSub",
                principalColumn: "GRNSubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomingInspections_SubConGRNSub_RefSubconGRNSubId",
                table: "IncomingInspections",
                column: "RefSubconGRNSubId",
                principalTable: "SubConGRNSub",
                principalColumn: "GRNSubId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinalInspection_LabourDcOutgoingSub_RefLabDcSubID",
                table: "FinalInspection");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomingInspections_LabourGRNSub_RefLabGRNSubId",
                table: "IncomingInspections");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomingInspections_SubConGRNSub_RefSubconGRNSubId",
                table: "IncomingInspections");

            migrationBuilder.DropIndex(
                name: "IX_IncomingInspections_RefLabGRNSubId",
                table: "IncomingInspections");

            migrationBuilder.DropIndex(
                name: "IX_IncomingInspections_RefSubconGRNSubId",
                table: "IncomingInspections");

            migrationBuilder.DropIndex(
                name: "IX_FinalInspection_RefLabDcSubID",
                table: "FinalInspection");

            migrationBuilder.DropColumn(
                name: "RefLabGRNSubId",
                table: "IncomingInspections");

            migrationBuilder.DropColumn(
                name: "RefSubconGRNSubId",
                table: "IncomingInspections");

            migrationBuilder.DropColumn(
                name: "RefLabDcSubID",
                table: "FinalInspection");
        }
    }
}
