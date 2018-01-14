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
        public string CoverImgUrl { get; set; }
        public string FullDescription { get; set; }
        public DateTime PostTime { get; set; }
        public bool IsDetailed { get; set; }

        public string Title { get; set; }
        public string Title_EN { get; set; }
        public string EventName { get; set; }
        public string EventPlace { get; set; }
        public string PublishTime { get; set; }
        public string BookInfo { get; set; }

        public string Editors { get; set; }

        public string Remark { get; set; }
    }
}
