using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace JdMvcHouTai.Models
{
    public class UserBackground
    {
        public int Id { get; set; }
        
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Display(Name = "密码")]
        public string PassWord { get; set; }
        [NotMapped]
        public string CpassWord { get; set; }
    }
}