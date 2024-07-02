using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChamadoSystemBackend.Migrations
{
    public partial class alterStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tickets");

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Tickets",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
