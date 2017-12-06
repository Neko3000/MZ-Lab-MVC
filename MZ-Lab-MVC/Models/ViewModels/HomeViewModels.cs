using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MZ_Lab_MVC.Models;

namespace MZ_Lab_MVC.ViewModels
{
    public class AcademicsViewModel
    {
        public IEnumerable<AcademicArticle> AcademicArticles { get; set; }
        public IEnumerable<string> YearOfAcademicArticles { get; set; }
    }
}
