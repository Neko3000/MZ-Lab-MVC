using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MZ_Lab_MVC.Models;
using MZ_Lab_MVC.Data;
using MZ_Lab_MVC.ViewModels;
using X.PagedList;

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
            var vm = new MemberViewModel
            {
                Members = db.Members.ToList()
            };

            return View(vm);
        }

        public IActionResult Academics(int? page)
        {
            var academicArticles = db.AcademicArticles.OrderByDescending(a => a.Id).ToList();
            var pageSize = 10;
            var pageNumber = page ?? 1;
            var singlePageModels = academicArticles.ToPagedList(pageNumber, pageSize);
            var totalPageNumber = (academicArticles.Count - 1) / pageSize + 1;

            IList<string> yearOfAcademicArticle = new List<string>();

            foreach (var academicArticle in singlePageModels)
            {
                if(!yearOfAcademicArticle.Contains(academicArticle.PostTime.Year.ToString()))
                {
                    yearOfAcademicArticle.Add(academicArticle.PostTime.Year.ToString());
                }
            }

            var academicsVM = new AcademicsViewModel
            {
                AcademicArticles = singlePageModels,
                YearOfAcademicArticles = yearOfAcademicArticle,
                Pager = new PagePartialViewModel
                {
                    CurrentPage = pageNumber,
                    TotalPage = totalPageNumber
                }
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