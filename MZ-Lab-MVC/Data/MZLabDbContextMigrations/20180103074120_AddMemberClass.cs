using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MZ_Lab_MVC.Migrations
{
    public partial class AddMemberClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookInfo",
                table: "AcademicArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "AcademicArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventPlace",
                table: "AcademicArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_EN",
                table: "AcademicArticles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AcademicArticleId = table.Column<int>(nullable: true),
                    AvatarUrl = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FamilyName = table.Column<string>(nullable: true),
                    FamilyNamePronunciation = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true),
                    GivenNamePronunciation = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_AcademicArticles_AcademicArticleId",
                        column: x => x.AcademicArticleId,
                        principalTable: "AcademicArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_AcademicArticleId",
                table: "Members",
                column: "AcademicArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropColumn(
                name: "BookInfo",
                table: "AcademicArticles");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "AcademicArticles");

            migrationBuilder.DropColumn(
                name: "EventPlace",
                table: "AcademicArticles");

            migrationBuilder.DropColumn(
                name: "Title_EN",
                table: "AcademicArticles");
        }
    }
}
