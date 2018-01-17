using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MZ_Lab_MVC.Models;

namespace MZ_Lab_MVC.ViewModels
{
    public class MemberCreateViewModel
    {
        [Display(Name = "姓")]
        public string FamilyName { get; set; }
        [Display(Name = "名")]
        public string GivenName { get; set; }
        [Display(Name = "姓/フリガナ")]
        public string FamilyNamePronunciation { get; set; }
        [Display(Name = "名/フリガナ")]
        public string GivenNamePronunciation { get; set; }
        [Display(Name = "画像/Url")]
        public string AvatarUrl { get; set; }
        public IFormFile AvatarImg { get; set; }
        [Display(Name = "専門")]
        public string Major { get; set; }
        [Display(Name = "学年")]
        public string Grade { get; set; }
        [Display(Name = "自己紹介")]
        public string Introduction { get; set; }
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }
        [Display(Name = "備考")]
        public string Remark { get; set; }
    }

    public class MemberDetailViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "姓")]
        public string FamilyName { get; set; }
        [Display(Name = "名")]
        public string GivenName { get; set; }
        [Display(Name = "姓/フリガナ")]
        public string FamilyNamePronunciation { get; set; }
        [Display(Name = "名/フリガナ")]
        public string GivenNamePronunciation { get; set; }
        [Display(Name = "画像/Url")]
        public string AvatarUrl { get; set; }
        public IFormFile AvatarImg { get; set; }
        [Display(Name = "専門")]
        public string Major { get; set; }
        [Display(Name = "学年")]
        public string Grade { get; set; }
        [Display(Name = "自己紹介")]
        public string Introduction { get; set; }
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }
        [Display(Name = "備考")]
        public string Remark { get; set; }
    }

    public class MemberEditViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "姓")]
        public string FamilyName { get; set; }
        [Display(Name = "名")]
        public string GivenName { get; set; }
        [Display(Name = "姓/フリガナ")]
        public string FamilyNamePronunciation { get; set; }
        [Display(Name = "名/フリガナ")]
        public string GivenNamePronunciation { get; set; }
        [Display(Name = "画像/Url")]
        public string AvatarUrl { get; set; }
        public IFormFile AvatarImg { get; set; }
        [Display(Name = "専門")]
        public string Major { get; set; }
        [Display(Name = "学年")]
        public string Grade { get; set; }
        [Display(Name = "自己紹介")]
        public string Introduction { get; set; }
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }
        [Display(Name = "備考")]
        public string Remark { get; set; }
    }

    public class MemberDeleteViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "姓")]
        public string FamilyName { get; set; }
        [Display(Name = "名")]
        public string GivenName { get; set; }
        [Display(Name = "姓/フリガナ")]
        public string FamilyNamePronunciation { get; set; }
        [Display(Name = "名/フリガナ")]
        public string GivenNamePronunciation { get; set; }
        [Display(Name = "画像/Url")]
        public string AvatarUrl { get; set; }
        public IFormFile AvatarImg { get; set; }
        [Display(Name = "専門")]
        public string Major { get; set; }
        [Display(Name = "学年")]
        public string Grade { get; set; }
        [Display(Name = "自己紹介")]
        public string Introduction { get; set; }
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }
        [Display(Name = "備考")]
        public string Remark { get; set; }
    }

    public class MemberIndexViewModel
    {
        public IEnumerable<Member> Members { get; set; }
    }
}
