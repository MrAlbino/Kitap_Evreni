using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Prog_Proje.Data.Migrations
{
    public partial class updateyazarkarakter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karakter_Ulke_UlkeId",
                table: "Karakter");

            migrationBuilder.DropForeignKey(
                name: "FK_Yazar_Ulke_UlkeId",
                table: "Yazar");

            migrationBuilder.AlterColumn<int>(
                name: "UlkeId",
                table: "Yazar",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "YazarTip",
                table: "KitapYazar",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UlkeId",
                table: "Karakter",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Karakter_Ulke_UlkeId",
                table: "Karakter",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yazar_Ulke_UlkeId",
                table: "Yazar",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karakter_Ulke_UlkeId",
                table: "Karakter");

            migrationBuilder.DropForeignKey(
                name: "FK_Yazar_Ulke_UlkeId",
                table: "Yazar");

            migrationBuilder.DropColumn(
                name: "YazarTip",
                table: "KitapYazar");

            migrationBuilder.AlterColumn<int>(
                name: "UlkeId",
                table: "Yazar",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UlkeId",
                table: "Karakter",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Karakter_Ulke_UlkeId",
                table: "Karakter",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yazar_Ulke_UlkeId",
                table: "Yazar",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
