using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MZ_Lab_MVC.Models;
using MZ_Lab_MVC.ViewModels;

namespace MZ_Lab_MVC.ViewModels
{
    public class PagePartialViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
    }


    public class AcademicsViewModel
    {
        public IEnumerable<AcademicArticle> AcademicArticles { get; set; }
        public IEnumerable<string> YearOfAcademicArticles { get; set; }

        public PagePartialViewModel Pager { get; set; }
    }
}
