using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoshiTaskWarehouseLukaszKierzek.Server.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "dokumentPrzyjecia",
                keyColumn: "Id",
                keyValue: 2,
                column: "MagazynDocelowyId",
                value: 1);

            migrationBuilder.InsertData(
                table: "dokumentPrzyjecia",
                columns: new[] { "Id", "DostawcaId", "MagazynDocelowyId" },
                values: new object[] { 3, 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dokumentPrzyjecia",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "dokumentPrzyjecia",
                keyColumn: "Id",
                keyValue: 2,
                column: "MagazynDocelowyId",
                value: 2);
        }
    }
}
