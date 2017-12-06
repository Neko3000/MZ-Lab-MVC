using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MZ_Lab_MVC.Models
{
    public class AcademicArticle
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImgUrl { get; set; }
        public DateTime PostTime { get; set; }
    }
}
