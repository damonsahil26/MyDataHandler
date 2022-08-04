using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDataHandler_DataAccess.Migrations
{
    public partial class AddedInternsInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfjoining",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfjoining",
                table: "Employees");
        }
    }
}
