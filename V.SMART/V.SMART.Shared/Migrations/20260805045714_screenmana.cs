using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace V.SMART.Shared.Migrations
{
    /// <inheritdoc />
    public partial class screenmana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ScreenManagements",
                columns: new[] { "Id", "Description", "Display", "Required", "ScreenName", "Topic" },
                values: new object[,]
                {
                    { 37, "When enabled, a prefix must be defined for the document number. The system will not allow saving or generating the Credit Note without a valid prefix.", "Prefix", false, "Credit Note", "Document Number Prefix Requirement" },
                    { 38, "When enabled, a prefix must be defined for the document number. The system will not allow saving or generating the Debit Note without a valid prefix.", "Prefix", false, "Debit Note", "Document Number Prefix Requirement" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScreenManagements",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ScreenManagements",
                keyColumn: "Id",
                keyValue: 38);
        }
    }
}
