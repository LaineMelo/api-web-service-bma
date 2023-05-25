using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_web_service_bma.Migrations
{
    /// <inheritdoc />
    public partial class M01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_nascimento",
                table: "Beneficiarios");

            migrationBuilder.DropColumn(
                name: "Perfil_acesso",
                table: "Beneficiarios");

            migrationBuilder.DropColumn(
                name: "beneficio_cesta_basica",
                table: "Beneficiarios");

            migrationBuilder.DropColumn(
                name: "beneficio_cesta_verde",
                table: "Beneficiarios");

            migrationBuilder.RenameColumn(
                name: "Situacao",
                table: "Beneficiarios",
                newName: "situacao");

            migrationBuilder.AlterColumn<int>(
                name: "situacao",
                table: "Beneficiarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Beneficiarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "tipoCesta",
                table: "Beneficiarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Beneficiarios");

            migrationBuilder.DropColumn(
                name: "tipoCesta",
                table: "Beneficiarios");

            migrationBuilder.RenameColumn(
                name: "situacao",
                table: "Beneficiarios",
                newName: "Situacao");

            migrationBuilder.AlterColumn<string>(
                name: "Situacao",
                table: "Beneficiarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Data_nascimento",
                table: "Beneficiarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Perfil_acesso",
                table: "Beneficiarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "beneficio_cesta_basica",
                table: "Beneficiarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "beneficio_cesta_verde",
                table: "Beneficiarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
