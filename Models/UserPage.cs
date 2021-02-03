using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace JdMvcHouTai.Models
{
    public class UserPage
    {
        public int Id { get; set; }
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入{0}")]
        public string UserName { get; set; }
        [Display(Name = "登录名")]
        public string LoginName { get; set; }
        [Display(Name = "昵称")]
        public string Name { get; set; }
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入{0}")]
        public string PassWord { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "请再次输入密码")]
        public string CpassWord { get; set; }
        [Display(Name = "用户名搜索")]
        public string SearchUserName { get; set; }
        [Display(Name = "登录名搜索")]
        public string SearchLoginName { get; set; }
        [Display(Name = "名字搜索")]
        public string SearchName { get; set; }
        [Display(Name = "id搜索")]
        public int SearchId { get; set; }
        [Display(Name = "兴趣爱好搜索")]
        public string SearchHobbyClassification { get; set; }

        public string HobbyClassification { get; set; }
        public string PrvoncesName { get; set; }
    }
}