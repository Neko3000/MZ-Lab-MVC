using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MZ_Lab_MVC.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string FamilyNamePronunciation { get; set; }
        public string GivenNamePronunciation { get; set; }
        public string AvatarUrl { get; set; }
        public string Major { get; set; }
        public string Grade { get; set; }
        public string Introduction { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
    }
}
