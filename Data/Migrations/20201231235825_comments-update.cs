using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Prog_Proje.Data.Migrations
{
    public partial class commentsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Kitap_KitapId",
                table: "Yorumlar");

            migrationBuilder.AlterColumn<int>(
                name: "KitapId",
                table: "Yorumlar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Kitap_KitapId",
                table: "Yorumlar",
                column: "KitapId",
                principalTable: "Kitap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Kitap_KitapId",
                table: "Yorumlar");

            migrationBuilder.AlterColumn<int>(
                name: "KitapId",
                table: "Yorumlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Kitap_KitapId",
                table: "Yorumlar",
                column: "KitapId",
                principalTable: "Kitap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
