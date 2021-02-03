using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace JdMvcHouTai.Models
{

    public class Hobby
    {

        public int Id { get; set; }

        [Display(Name = "兴趣分类")]
        public string HobbyClassification { get; set; }

    }
}