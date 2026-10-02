using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V.SMART.Shared.Migrations
{
    /// <inheritdoc />
    public partial class estimateinquote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstiamateSubId",
                table: "MfgQuoteSub",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MfgQuoteSub_EstiamateSubId",
                table: "MfgQuoteSub",
                column: "EstiamateSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_MfgQuoteSub_EstimateSub_EstiamateSubId",
                table: "MfgQuoteSub",
                column: "EstiamateSubId",
                principalTable: "EstimateSub",
                principalColumn: "EstiamateSubId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MfgQuoteSub_EstimateSub_EstiamateSubId",
                table: "MfgQuoteSub");

            migrationBuilder.DropIndex(
                name: "IX_MfgQuoteSub_EstiamateSubId",
                table: "MfgQuoteSub");

            migrationBuilder.DropColumn(
                name: "EstiamateSubId",
                table: "MfgQuoteSub");
        }
    }
}
