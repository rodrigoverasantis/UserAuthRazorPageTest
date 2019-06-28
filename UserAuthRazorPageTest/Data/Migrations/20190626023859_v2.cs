using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAuthRazorPageTest.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaterno",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoNombre",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApellidoPaterno",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SegundoNombre",
                table: "AspNetUsers");
        }
    }
}
