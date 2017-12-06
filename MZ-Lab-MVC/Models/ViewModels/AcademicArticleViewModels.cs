using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MZ_Lab_MVC.ViewModels
{
    public class AcademicArticleCreateViewModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Cover Url")]
        public string CoverImgUrl { get; set; }
        [Display(Name = "PostTime")]
        public DateTime PostTime { get; set; }
    }

    public class AcademicArticleDetailViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Cover Url")]
        public string CoverImgUrl { get; set; }
        [Display(Name = "PostTime")]
        public DateTime PostTime { get; set; }
    }

    public class AcademicArticleEditViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Cover Url")]
        public string CoverImgUrl { get; set; }
        [Display(Name = "PostTime")]
        public DateTime PostTime { get; set; }
    }

    public class AcademicArticleDeleteViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Cover Url")]
        public string CoverImgUrl { get; set; }
        [Display(Name = "PostTime")]
        public DateTime PostTime { get; set; }
    }
}
