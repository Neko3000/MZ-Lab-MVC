using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MZ_Lab_MVC.Data;
using MZ_Lab_MVC.Models;
using MZ_Lab_MVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MZ_Lab_MVC.Controllers
{
    public class AcademicArticleManage : Controller
    {
        // GET: /<controller>/
        private MZLabDbContext db;

        public AcademicArticleManage(MZLabDbContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page)
        {
            var academicArticles = db.AcademicArticles.ToList();
            var pageSize = 10;
            var pageNumber = page ?? 1;
            var singlePageModels = academicArticles.ToPagedList(pageNumber, pageSize);
            var totalPageNumber = (academicArticles.Count - 1) / pageSize + 1;

            var vm = new AcademicArticleIndexViewModel()
            {
                AcademicArticles = singlePageModels
            };
            return View(vm);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            AcademicArticle academicArticle = db.AcademicArticles.Find(id);

            if (academicArticle == null)
            {
                return NotFound();
            }

            var vm = new AcademicArticleDetailViewModel
            {
                Id = academicArticle.Id,
                Title = academicArticle.Title,
                CoverImgUrl = academicArticle.CoverImgUrl,
                PostTime = academicArticle.PostTime,
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new AcademicArticleCreateViewModel
            {
                PostTime = DateTime.Now
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AcademicArticleCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var academicArticle = new AcademicArticle
                {
                    Title = model.Title,
                    CoverImgUrl = model.CoverImgUrl,
                    PostTime = model.PostTime,
                };
                db.AcademicArticles.Add(academicArticle);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            AcademicArticle academicArticle = db.AcademicArticles.Find(id);
            if (academicArticle == null)
            {
                return NotFound();
            }

            var vm = new AcademicArticleEditViewModel
            {
                Id = academicArticle.Id,
                Title = academicArticle.Title,
                CoverImgUrl = academicArticle.CoverImgUrl,
                PostTime = academicArticle.PostTime
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AcademicArticleEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var academicArticle = db.AcademicArticles.Find(model.Id);

                academicArticle.Id = model.Id;
                academicArticle.Title = model.Title;
                academicArticle.CoverImgUrl = model.CoverImgUrl;
                academicArticle.PostTime = model.PostTime;


                db.Entry(academicArticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            AcademicArticle academicArticle = db.AcademicArticles.Find(id);
            if (academicArticle == null)
            {
                return NotFound();
            }

            var vm = new AcademicArticleDeleteViewModel
            {
                Id = academicArticle.Id,
                Title = academicArticle.Title,
                PostTime = academicArticle.PostTime,
                CoverImgUrl = academicArticle.CoverImgUrl
            };
            return View(vm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicArticle academicArticle = db.AcademicArticles.Find(id);
            db.AcademicArticles.Remove(academicArticle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
