using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace MZ_Lab_MVC.Data
{
    public class MZLabDbContext: DbContext
    {
        public MZLabDbContext(DbContextOptions<MZLabDbContext> options) : base(options)
        {

        }

        public DbSet<MZ_Lab_MVC.Models.AcademicArticle> AcademicArticles { get; set; }
        public DbSet<MZ_Lab_MVC.Models.Member> Members { get; set; }
    }
}