using Microsoft.EntityFrameworkCore.Migrations;

namespace IsBasvuruKaydi.DataAccess.Migrations
{
    public partial class goruntulemeColumunEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Goruntuleme",
                table: "Cvler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goruntuleme",
                table: "Cvler");
        }
    }
}
