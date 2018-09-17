using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UserRoles.Migrations
{
    public partial class addclientewc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusCliente",
                table: "Personas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypoClienteWC",
                table: "Personas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusCliente",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "TypoClienteWC",
                table: "Personas");
        }
    }
}
