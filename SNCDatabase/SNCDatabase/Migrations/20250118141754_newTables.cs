using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SNCDatabase.Migrations
{
    /// <inheritdoc />
    public partial class newTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrojTelefona",
                table: "Restorani",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Cena",
                table: "Restorani",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumOsnivanja",
                table: "Restorani",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Restorani",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Lokacija",
                table: "Restorani",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "Ocena",
                table: "Restorani",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "PraviTortu",
                table: "Restorani",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Sifra",
                table: "Restorani",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SigurnosniKod",
                table: "Restorani",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "Restorani",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojTelefona",
                table: "Restorani");

            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Restorani");

            migrationBuilder.DropColumn(
                name: "DatumOsnivanja",
                table: "Restorani");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Restorani");

            migrationBuilder.DropColumn(
                name: "Lokacija",
                table: "Restorani");

            migrationBuilder.DropColumn(
                name: "Ocena",
                table: "Restorani");

            migrationBuilder.DropColumn(
                name: "PraviTortu",
                table: "Restorani");

            migrationBuilder.DropColumn(
                name: "Sifra",
                table: "Restorani");

            migrationBuilder.DropColumn(
                name: "SigurnosniKod",
                table: "Restorani");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Restorani");
        }
    }
}
