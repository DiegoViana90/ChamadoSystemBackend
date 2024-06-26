﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChamadoSystemBackend.Migrations
{
    public partial class AddIsFirstAccessToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFirstAccess",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstAccess",
                table: "Users");
        }
    }
}
