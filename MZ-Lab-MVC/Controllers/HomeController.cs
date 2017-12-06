using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MZ_Lab_MVC.Models;
using MZ_Lab_MVC.Data;
using MZ_Lab_MVC.ViewModels;

namespace MZ_Lab_MVC.Controllers
{
    public class HomeController : Controller
    {
        private MZLabDbContext db;

        public HomeController(MZLabDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Member()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Academics()
        {
            var academicArticles = db.AcademicArticles.ToList();
            IList<string> yearOfAcademicArticle = new List<string>();

            foreach (var academicArticle in academicArticles)
            {
                if(!yearOfAcademicArticle.Contains(academicArticle.PostTime.Year.ToString()))
                {
                    yearOfAcademicArticle.Add(academicArticle.PostTime.Year.ToString());
                }
            }
            var academicsVM = new AcademicsViewModel()
            {
                AcademicArticles = db.AcademicArticles.ToList(),
                YearOfAcademicArticles = yearOfAcademicArticle
            };
            return View(academicsVM);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
