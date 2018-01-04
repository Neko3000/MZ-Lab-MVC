using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MZ_Lab_MVC.Migrations
{
    public partial class DropRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_AcademicArticles_AcademicArticleId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_AcademicArticleId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AcademicArticleId",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "Editors",
                table: "AcademicArticles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Editors",
                table: "AcademicArticles");

            migrationBuilder.AddColumn<int>(
                name: "AcademicArticleId",
                table: "Members",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_AcademicArticleId",
                table: "Members",
                column: "AcademicArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_AcademicArticles_AcademicArticleId",
                table: "Members",
                column: "AcademicArticleId",
                principalTable: "AcademicArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
