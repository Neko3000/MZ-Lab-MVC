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
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MZ_Lab_MVC.Controllers
{
    //[Authorize]
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
                CoverImgUrl = academicArticle.CoverImgUrl,
                FullDescription = academicArticle.FullDescription,
                PostTime = academicArticle.PostTime,
                Remark = academicArticle.Remark,
                IsDetailed = academicArticle.IsDetailed,

                Title = academicArticle.Title,
                Title_EN = academicArticle.Title_EN,
                EventName = academicArticle.EventName,
                EventPlace = academicArticle.EventPlace,
                PublishTime = academicArticle.PublishTime,
                BookInfo = academicArticle.BookInfo,

                Editors = academicArticle.Editors
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
                    CoverImgUrl = model.CoverImgUrl,
                    FullDescription = model.FullDescription,
                    PostTime = model.PostTime,
                    Remark = model.Remark,
                    IsDetailed = model.IsDetailed,

                    Title = model.Title,
                    Title_EN = model.Title_EN,
                    EventName = model.EventName,
                    EventPlace = model.EventPlace,
                    PublishTime = model.PublishTime,
                    BookInfo = model.BookInfo,

                    Editors = model.Editors
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
                CoverImgUrl = academicArticle.CoverImgUrl,
                FullDescription = academicArticle.FullDescription,
                PostTime = academicArticle.PostTime,
                Remark = academicArticle.Remark,
                IsDetailed = academicArticle.IsDetailed,

                Title = academicArticle.Title,
                Title_EN = academicArticle.Title_EN,
                EventName = academicArticle.EventName,
                EventPlace = academicArticle.EventPlace,
                PublishTime = academicArticle.PublishTime,
                BookInfo = academicArticle.BookInfo,

                Editors = academicArticle.Editors
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
                academicArticle.CoverImgUrl = model.CoverImgUrl;
                academicArticle.FullDescription = model.FullDescription;
                academicArticle.PostTime = model.PostTime;
                academicArticle.Remark = model.Remark;
                academicArticle.IsDetailed = model.IsDetailed;

                academicArticle.Title = model.Title;
                academicArticle.Title_EN = model.Title_EN;
                academicArticle.EventName = model.EventName;
                academicArticle.EventPlace = model.EventPlace;
                academicArticle.PublishTime = model.PublishTime;
                academicArticle.BookInfo = model.BookInfo;

                academicArticle.Editors = model.Editors;

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
                CoverImgUrl = academicArticle.CoverImgUrl,
                FullDescription = academicArticle.FullDescription,
                PostTime = academicArticle.PostTime,
                Remark = academicArticle.Remark,
                IsDetailed = academicArticle.IsDetailed,

                Title = academicArticle.Title,
                Title_EN = academicArticle.Title_EN,
                EventName = academicArticle.EventName,
                EventPlace = academicArticle.EventPlace,
                PublishTime = academicArticle.PublishTime,
                BookInfo = academicArticle.BookInfo,

                Editors = academicArticle.Editors
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
