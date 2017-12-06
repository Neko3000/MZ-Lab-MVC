﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MZ_Lab_MVC.Data;
using System;

namespace MZ_Lab_MVC.Migrations
{
    [DbContext(typeof(MZLabDbContext))]
    partial class MZLabDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MZ_Lab_MVC.Models.AcademicArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CoverImgUrl");

                    b.Property<DateTime>("PostTime");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("AcademicArticles");
                });
#pragma warning restore 612, 618
        }
    }
}
