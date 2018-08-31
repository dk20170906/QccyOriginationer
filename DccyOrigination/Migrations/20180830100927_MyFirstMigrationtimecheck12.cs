using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DccyOrigination.Migrations
{
    public partial class MyFirstMigrationtimecheck12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "admUserRole",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "admUserRole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "admUserJur",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "admUserJur",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "admUserDep",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "admUserDep",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "admRoleJur",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "admRoleJur",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "admDepRole",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "admDepRole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "admDepJur",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "admDepJur",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "admUserRole");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "admUserRole");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "admUserJur");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "admUserJur");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "admUserDep");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "admUserDep");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "admRoleJur");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "admRoleJur");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "admDepRole");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "admDepRole");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "admDepJur");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "admDepJur");
        }
    }
}
