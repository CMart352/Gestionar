using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UserRoles.Migrations
{
    public partial class newcaractersvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Caracters ON");
            migrationBuilder.Sql("insert into Caracters (Id, Name) values (1, 'Legal')");
            migrationBuilder.Sql("insert into Caracters (Id, Name) values (2, 'Apoderado')");
            migrationBuilder.Sql("SET IDENTITY_INSERT Caracters OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Caracters");
        }
    }
}
