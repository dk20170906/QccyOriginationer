using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DccyOrigination.Migrations
{
    public partial class tabelssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeftMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimestampV = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Pid = table.Column<int>(nullable: false),
                    Guid = table.Column<string>(nullable: true),
                    PGuid = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    MenuStyle = table.Column<string>(nullable: true),
                    IsOpen = table.Column<bool>(nullable: false),
                    IsChildren = table.Column<bool>(nullable: false),
                    LeftMenuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeftMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeftMenu_LeftMenu_LeftMenuId",
                        column: x => x.LeftMenuId,
                        principalTable: "LeftMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeftMenu_LeftMenuId",
                table: "LeftMenu",
                column: "LeftMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeftMenu");
        }
    }
}
