using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UserRoles.Migrations
{
    public partial class addtypodocumentoRep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Representantes_Caracters_CaracterId",
                table: "Representantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Representantes_TypoDocumentos_TypoDocumentId",
                table: "Representantes");

            migrationBuilder.DropIndex(
                name: "IX_Representantes_CaracterId",
                table: "Representantes");

            migrationBuilder.DropIndex(
                name: "IX_Representantes_TypoDocumentId",
                table: "Representantes");

            migrationBuilder.DropColumn(
                name: "CaracterId",
                table: "Representantes");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Representantes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Representantes");

            migrationBuilder.DropColumn(
                name: "TypoDocumentId",
                table: "Representantes");

            migrationBuilder.AddColumn<int>(
                name: "TypoDocumento",
                table: "Representantes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypoDocumento",
                table: "Representantes");

            migrationBuilder.AddColumn<int>(
                name: "CaracterId",
                table: "Representantes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Document",
                table: "Representantes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Representantes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypoDocumentId",
                table: "Representantes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Representantes_CaracterId",
                table: "Representantes",
                column: "CaracterId");

            migrationBuilder.CreateIndex(
                name: "IX_Representantes_TypoDocumentId",
                table: "Representantes",
                column: "TypoDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Representantes_Caracters_CaracterId",
                table: "Representantes",
                column: "CaracterId",
                principalTable: "Caracters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Representantes_TypoDocumentos_TypoDocumentId",
                table: "Representantes",
                column: "TypoDocumentId",
                principalTable: "TypoDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
