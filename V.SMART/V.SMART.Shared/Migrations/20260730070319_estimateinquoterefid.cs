using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V.SMART.Shared.Migrations
{
    /// <inheritdoc />
    public partial class estimateinquoterefid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MfgQuoteSub_EstimateSub_EstiamateSubId",
                table: "MfgQuoteSub");

            migrationBuilder.RenameColumn(
                name: "EstiamateSubId",
                table: "MfgQuoteSub",
                newName: "EstiamateId");

            migrationBuilder.RenameIndex(
                name: "IX_MfgQuoteSub_EstiamateSubId",
                table: "MfgQuoteSub",
                newName: "IX_MfgQuoteSub_EstiamateId");

            migrationBuilder.AddForeignKey(
                name: "FK_MfgQuoteSub_Estimate_EstiamateId",
                table: "MfgQuoteSub",
                column: "EstiamateId",
                principalTable: "Estimate",
                principalColumn: "EstiamateId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MfgQuoteSub_Estimate_EstiamateId",
                table: "MfgQuoteSub");

            migrationBuilder.RenameColumn(
                name: "EstiamateId",
                table: "MfgQuoteSub",
                newName: "EstiamateSubId");

            migrationBuilder.RenameIndex(
                name: "IX_MfgQuoteSub_EstiamateId",
                table: "MfgQuoteSub",
                newName: "IX_MfgQuoteSub_EstiamateSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_MfgQuoteSub_EstimateSub_EstiamateSubId",
                table: "MfgQuoteSub",
                column: "EstiamateSubId",
                principalTable: "EstimateSub",
                principalColumn: "EstiamateSubId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
