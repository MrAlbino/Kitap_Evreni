using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Prog_Proje.Data.Migrations
{
    public partial class updatekitap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_Dil_DilId",
                table: "Kitap");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_Kategori_KategoriId",
                table: "Kitap");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Kitap",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DilId",
                table: "Kitap",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_Dil_DilId",
                table: "Kitap",
                column: "DilId",
                principalTable: "Dil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_Kategori_KategoriId",
                table: "Kitap",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_Dil_DilId",
                table: "Kitap");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_Kategori_KategoriId",
                table: "Kitap");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Kitap",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DilId",
                table: "Kitap",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_Dil_DilId",
                table: "Kitap",
                column: "DilId",
                principalTable: "Dil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_Kategori_KategoriId",
                table: "Kitap",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
