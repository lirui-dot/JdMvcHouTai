using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace JdMvcHouTai.Models
{
    public class UserBackgroundPage
    {
        public int Id { get; set; }
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入{0}")]
        public string Emile { get; set; }
        [Remote(action: "NameIsExists", controller: "User")]
        [Display(Name = "注册用户名")]
        [Required(ErrorMessage = "请输入{0}")]
        public string Username { get; set; }
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入{0}")]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "请再次输入密码")]
        [Display(Name = "确认密码")]
        [Compare("PassWord", ErrorMessage = "两次密码不一样")]
        public string CpassWord { get; set; }

    }
}