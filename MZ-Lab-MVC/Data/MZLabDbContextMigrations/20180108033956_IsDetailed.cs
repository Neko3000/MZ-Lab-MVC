using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MZ_Lab_MVC.Migrations
{
    public partial class IsDetailed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "AcademicArticles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDetailed",
                table: "AcademicArticles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "AcademicArticles");

            migrationBuilder.DropColumn(
                name: "IsDetailed",
                table: "AcademicArticles");
        }
    }
}
