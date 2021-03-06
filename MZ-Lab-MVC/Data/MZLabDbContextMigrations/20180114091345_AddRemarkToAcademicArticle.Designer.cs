﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using MZ_Lab_MVC.Data;
using System;

namespace MZ_Lab_MVC.Migrations
{
    [DbContext(typeof(MZLabDbContext))]
    [Migration("20180114091345_AddRemarkToAcademicArticle")]
    partial class AddRemarkToAcademicArticle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("MZ_Lab_MVC.Models.AcademicArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookInfo");

                    b.Property<string>("CoverImgUrl");

                    b.Property<string>("Editors");

                    b.Property<string>("EventName");

                    b.Property<string>("EventPlace");

                    b.Property<string>("FullDescription");

                    b.Property<bool>("IsDetailed");

                    b.Property<DateTime>("PostTime");

                    b.Property<string>("PublishTime");

                    b.Property<string>("Remark");

                    b.Property<string>("Title");

                    b.Property<string>("Title_EN");

                    b.HasKey("Id");

                    b.ToTable("AcademicArticles");
                });

            modelBuilder.Entity("MZ_Lab_MVC.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AvatarUrl");

                    b.Property<string>("Email");

                    b.Property<string>("FamilyName");

                    b.Property<string>("FamilyNamePronunciation");

                    b.Property<string>("GivenName");

                    b.Property<string>("GivenNamePronunciation");

                    b.Property<string>("Grade");

                    b.Property<string>("Introduction");

                    b.Property<string>("Major");

                    b.Property<string>("Remark");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
