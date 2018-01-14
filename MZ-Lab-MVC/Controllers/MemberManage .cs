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
    public class MemberManage : Controller
    {
        // GET: /<controller>/
        private MZLabDbContext db;

        public MemberManage(MZLabDbContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page)
        {
            var members = db.Members.ToList();
            var pageSize = 10;
            var pageNumber = page ?? 1;
            var singlePageModels = members.ToPagedList(pageNumber, pageSize);
            var totalPageNumber = (members.Count - 1) / pageSize + 1;

            var vm = new MemberIndexViewModel()
            {
                Members = singlePageModels
            };
            return View(vm);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Member member = db.Members.Find(id);

            if (member == null)
            {
                return NotFound();
            }

            var vm = new MemberDetailViewModel
            {
                Id = member.Id,
                FamilyName = member.FamilyName,
                GivenName = member.GivenName,
                FamilyNamePronunciation = member.FamilyNamePronunciation,
                GivenNamePronunciation = member.GivenNamePronunciation,
                AvatarUrl = member.AvatarUrl,
                Major = member.Major,
                Grade = member.Grade,
                Introduction = member.Introduction,
                Email = member.Email,
                Remark = member.Remark,
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new MemberCreateViewModel
            {
                
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MemberCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var member = new Member
                {
                    FamilyName = model.FamilyName,
                    GivenName = model.GivenName,
                    FamilyNamePronunciation = model.FamilyNamePronunciation,
                    GivenNamePronunciation = model.GivenNamePronunciation,
                    AvatarUrl = model.AvatarUrl,
                    Major = model.Major,
                    Grade = model.Grade,
                    Introduction = model.Introduction,
                    Email = model.Email,
                    Remark = model.Remark,
                };
                db.Members.Add(member);
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
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            var vm = new MemberEditViewModel
            {
                Id = member.Id,
                FamilyName = member.FamilyName,
                GivenName = member.GivenName,
                FamilyNamePronunciation = member.FamilyNamePronunciation,
                GivenNamePronunciation = member.GivenNamePronunciation,
                AvatarUrl = member.AvatarUrl,
                Major = member.Major,
                Grade = member.Grade,
                Introduction = member.Introduction,
                Email = member.Email,
                Remark = member.Remark,
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var member = db.Members.Find(model.Id);

                member.FamilyName = model.FamilyName;
                member.GivenName = model.GivenName;
                member.FamilyNamePronunciation = model.FamilyNamePronunciation;
                member.GivenNamePronunciation = model.GivenNamePronunciation;
                member.AvatarUrl = model.AvatarUrl;
                member.Major = model.Major;
                member.Grade = model.Grade;
                member.Introduction = model.Introduction;
                member.Email = model.Email;
                member.Remark = model.Remark;

                db.Entry(member).State = EntityState.Modified;
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
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            var vm = new MemberDeleteViewModel
            {
                Id = member.Id,
                FamilyName = member.FamilyName,
                GivenName = member.GivenName,
                FamilyNamePronunciation = member.FamilyNamePronunciation,
                GivenNamePronunciation = member.GivenNamePronunciation,
                AvatarUrl = member.AvatarUrl,
                Major = member.Major,
                Grade = member.Grade,
                Introduction = member.Introduction,
                Email = member.Email,
                Remark = member.Remark,
            };
            return View(vm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
