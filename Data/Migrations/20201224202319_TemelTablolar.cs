using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Prog_Proje.Data.Migrations
{
    public partial class TemelTablolar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ulke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UlkeAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Karakter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    UlkeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karakter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Karakter_Ulke_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yazar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    UlkeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yazar_Ulke_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapKarakter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapId = table.Column<int>(nullable: false),
                    KarakterId = table.Column<int>(nullable: false),
                    Sira = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapKarakter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KitapKarakter_Karakter_KarakterId",
                        column: x => x.KarakterId,
                        principalTable: "Karakter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapKarakter_Kitap_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapYazar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapId = table.Column<int>(nullable: false),
                    YazarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapYazar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KitapYazar_Kitap_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapYazar_Yazar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karakter_UlkeId",
                table: "Karakter",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapKarakter_KarakterId",
                table: "KitapKarakter",
                column: "KarakterId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapKarakter_KitapId",
                table: "KitapKarakter",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapYazar_KitapId",
                table: "KitapYazar",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapYazar_YazarId",
                table: "KitapYazar",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_Yazar_UlkeId",
                table: "Yazar",
                column: "UlkeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapKarakter");

            migrationBuilder.DropTable(
                name: "KitapYazar");

            migrationBuilder.DropTable(
                name: "Karakter");

            migrationBuilder.DropTable(
                name: "Yazar");

            migrationBuilder.DropTable(
                name: "Ulke");
        }
    }
}
