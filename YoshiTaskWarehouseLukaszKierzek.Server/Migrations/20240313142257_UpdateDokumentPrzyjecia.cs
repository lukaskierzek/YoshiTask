using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoshiTaskWarehouseLukaszKierzek.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDokumentPrzyjecia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Anulowany",
                table: "dokumentPrzyjecia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Zatwierdzony",
                table: "dokumentPrzyjecia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "dokumentPrzyjecia",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Anulowany", "Zatwierdzony" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "dokumentPrzyjecia",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Anulowany", "Zatwierdzony" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "dokumentPrzyjecia",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Anulowany", "Zatwierdzony" },
                values: new object[] { 1, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anulowany",
                table: "dokumentPrzyjecia");

            migrationBuilder.DropColumn(
                name: "Zatwierdzony",
                table: "dokumentPrzyjecia");
        }
    }
}
