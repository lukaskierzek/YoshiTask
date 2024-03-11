using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoshiTaskWarehouseLukaszKierzek.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dostawca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaFirmy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dostawca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "etykieta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etykieta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "magazyn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_magazyn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dokumentPrzyjecia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MagazynDocelowyId = table.Column<int>(type: "int", nullable: false),
                    DostawcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dokumentPrzyjecia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dokumentPrzyjecia_dostawca_DostawcaId",
                        column: x => x.DostawcaId,
                        principalTable: "dostawca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dokumentPrzyjecia_magazyn_MagazynDocelowyId",
                        column: x => x.MagazynDocelowyId,
                        principalTable: "magazyn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dokumentPrzyjeciaEtykieta",
                columns: table => new
                {
                    DokumentPrzyjeciaId = table.Column<int>(type: "int", nullable: false),
                    EtykietaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dokumentPrzyjeciaEtykieta", x => new { x.DokumentPrzyjeciaId, x.EtykietaId });
                    table.ForeignKey(
                        name: "FK_dokumentPrzyjeciaEtykieta_dokumentPrzyjecia_DokumentPrzyjeciaId",
                        column: x => x.DokumentPrzyjeciaId,
                        principalTable: "dokumentPrzyjecia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dokumentPrzyjeciaEtykieta_etykieta_EtykietaId",
                        column: x => x.EtykietaId,
                        principalTable: "etykieta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "towar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DokumentPrzyjeciaId = table.Column<int>(type: "int", nullable: false),
                    DokumnetPrzyjeciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_towar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_towar_dokumentPrzyjecia_DokumentPrzyjeciaId",
                        column: x => x.DokumentPrzyjeciaId,
                        principalTable: "dokumentPrzyjecia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dostawca",
                columns: new[] { "Id", "Adres", "NazwaFirmy" },
                values: new object[,]
                {
                    { 1, "adres1", "Firma1" },
                    { 2, "adres2", "Firma2" },
                    { 3, "adres3", "Firma3" }
                });

            migrationBuilder.InsertData(
                table: "etykieta",
                columns: new[] { "Id", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Etykieta1" },
                    { 2, "Etykieta2" },
                    { 3, "Etykieta3" }
                });

            migrationBuilder.InsertData(
                table: "magazyn",
                columns: new[] { "Id", "Nazwa", "Symbol" },
                values: new object[,]
                {
                    { 1, "Magazyn1", "Sumbol1" },
                    { 2, "Magazyn2", "Sumbol2" },
                    { 3, "Magazyn3", "Sumbol3" }
                });

            migrationBuilder.InsertData(
                table: "dokumentPrzyjecia",
                columns: new[] { "Id", "DostawcaId", "MagazynDocelowyId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "dokumentPrzyjeciaEtykieta",
                columns: new[] { "DokumentPrzyjeciaId", "EtykietaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_dokumentPrzyjecia_DostawcaId",
                table: "dokumentPrzyjecia",
                column: "DostawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_dokumentPrzyjecia_MagazynDocelowyId",
                table: "dokumentPrzyjecia",
                column: "MagazynDocelowyId");

            migrationBuilder.CreateIndex(
                name: "IX_dokumentPrzyjeciaEtykieta_EtykietaId",
                table: "dokumentPrzyjeciaEtykieta",
                column: "EtykietaId");

            migrationBuilder.CreateIndex(
                name: "IX_towar_DokumentPrzyjeciaId",
                table: "towar",
                column: "DokumentPrzyjeciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dokumentPrzyjeciaEtykieta");

            migrationBuilder.DropTable(
                name: "towar");

            migrationBuilder.DropTable(
                name: "etykieta");

            migrationBuilder.DropTable(
                name: "dokumentPrzyjecia");

            migrationBuilder.DropTable(
                name: "dostawca");

            migrationBuilder.DropTable(
                name: "magazyn");
        }
    }
}
