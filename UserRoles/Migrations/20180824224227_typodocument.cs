using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UserRoles.Migrations
{
    public partial class typodocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT TypoDocumentos ON");
            migrationBuilder.Sql("insert into TypoDocumentos (Id, Name) values (1, 'CUIT')");
            migrationBuilder.Sql("insert into TypoDocumentos (Id, Name) values (2, 'CUIL')");
            migrationBuilder.Sql("insert into TypoDocumentos (Id, Name) values (3, 'CDI')");
            migrationBuilder.Sql("SET IDENTITY_INSERT TypoDocumentos OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM TypoDocumentos");
        }
    }
}
