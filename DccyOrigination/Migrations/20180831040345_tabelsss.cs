using Microsoft.EntityFrameworkCore.Migrations;

namespace DccyOrigination.Migrations
{
    public partial class tabelsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "admUserRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "admUserJur",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "admUserDep",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "admRoleJur",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "admRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "admJurisdiction",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "admDepRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "admDepJur",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "admDepartment",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "admUserRole");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "admUserJur");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "admUserDep");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "admRoleJur");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "admRole");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "admJurisdiction");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "admDepRole");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "admDepJur");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "admDepartment");
        }
    }
}
