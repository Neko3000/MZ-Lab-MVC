using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MZ_Lab_MVC.Models;

namespace MZ_Lab_MVC.ViewModels
{
    public class AcademicArticleCreateViewModel
    {
        [Display(Name = "画像/Url")]
        public string CoverImgUrl { get; set; }
        public IFormFile CoverImg { get; set; }
        [Display(Name = "内容")]
        public string FullDescription { get; set; }
        [Display(Name = "公開時間")]
        public DateTime PostTime { get; set; }
        [Display(Name = "備考")]
        public string Remark { get; set; }
        [Display(Name = "この記事は詳細なデータを含める")]
        public bool IsDetailed { get; set; }

        [Display(Name = "タイトル")]
        public string Title { get; set; }
        [Display(Name = "タイトル/英語")]
        public string Title_EN { get; set; }
        [Display(Name = "会議の名前")]
        public string EventName { get; set; }
        [Display(Name = "会議の場所")]
        public string EventPlace { get; set; }
        [Display(Name = "会議（発表）の時間")]
        public string PublishTime { get; set; }
        [Display(Name = "本（雑誌、論文）の情報")]
        public string BookInfo { get; set; }

        [Display(Name ="作者")]
        public string Editors { get; set; }
    }

    public class AcademicArticleDetailViewModel
    {
        [Display(Name ="ID")]
        public int Id { get; set; }
        [Display(Name = "画像/Url")]
        public string CoverImgUrl { get; set; }
        [Display(Name = "内容")]
        public string FullDescription { get; set; }
        [Display(Name = "公開時間")]
        public DateTime PostTime { get; set; }
        [Display(Name = "この記事は詳細なデータを含める")]
        public bool IsDetailed { get; set; }

        [Display(Name = "タイトル")]
        public string Title { get; set; }
        [Display(Name = "タイトル/英語")]
        public string Title_EN { get; set; }
        [Display(Name = "会議の名前")]
        public string EventName { get; set; }
        [Display(Name = "会議の場所")]
        public string EventPlace { get; set; }
        [Display(Name = "会議（発表）の時間")]
        public string PublishTime { get; set; }
        [Display(Name = "備考")]
        public string Remark { get; set; }
        [Display(Name = "本（雑誌、論文）の情報")]
        public string BookInfo { get; set; }

        [Display(Name = "作者")]
        public string Editors { get; set; }
    }

    public class AcademicArticleEditViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "画像/Url")]
        public string CoverImgUrl { get; set; }
        public IFormFile CoverImg { get; set; }
        [Display(Name = "内容")]
        public string FullDescription { get; set; }
        [Display(Name = "公開時間")]
        public DateTime PostTime { get; set; }
        [Display(Name = "備考")]
        public string Remark { get; set; }
        [Display(Name = "この記事は詳細なデータを含める")]
        public bool IsDetailed { get; set; }

        [Display(Name = "タイトル")]
        public string Title { get; set; }
        [Display(Name = "タイトル/英語")]
        public string Title_EN { get; set; }
        [Display(Name = "会議の名前")]
        public string EventName { get; set; }
        [Display(Name = "会議の場所")]
        public string EventPlace { get; set; }
        [Display(Name = "会議（発表）の時間")]
        public string PublishTime { get; set; }
        [Display(Name = "本（雑誌、論文）の情報")]
        public string BookInfo { get; set; }

        [Display(Name = "作者")]
        public string Editors { get; set; }
    }

    public class AcademicArticleDeleteViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "画像/Url")]
        public string CoverImgUrl { get; set; }
        [Display(Name = "内容")]
        public string FullDescription { get; set; }
        [Display(Name = "公開時間")]
        public DateTime PostTime { get; set; }
        [Display(Name = "備考")]
        public string Remark { get; set; }
        [Display(Name = "この記事は詳細なデータを含める")]
        public bool IsDetailed { get; set; }

        [Display(Name = "タイトル")]
        public string Title { get; set; }
        [Display(Name = "タイトル/英語")]
        public string Title_EN { get; set; }
        [Display(Name = "会議の名前")]
        public string EventName { get; set; }
        [Display(Name = "会議の場所")]
        public string EventPlace { get; set; }
        [Display(Name = "会議（発表）の時間")]
        public string PublishTime { get; set; }
        [Display(Name = "本（雑誌、論文）の情報")]
        public string BookInfo { get; set; }

        [Display(Name = "作者")]
        public string Editors { get; set; }

    }

    public class AcademicArticleIndexViewModel
    {
        public IEnumerable<AcademicArticle> AcademicArticles { get; set; }
    }
}
