using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Prog_Proje.Data.Migrations
{
    public partial class customizekitap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArkaplanResim",
                table: "Kitap",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArkaplanResim",
                table: "Kitap");
        }
    }
}
