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
        private MZLabDbContext _context;

        public HomeController(MZLabDbContext context)
        {
            _context = context;
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
            var academicsVM = new AcademicsViewModel()
            {
                AcademicArticles = _context.AcademicArticles.ToList()
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
