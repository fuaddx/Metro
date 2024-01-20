using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetroMvc.Migrations
{
    public partial class hnhnh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Blogs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Blogs");
        }
    }
}
