using System.ComponentModel.DataAnnotations;

namespace JdMvcHouTai.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Display(Name = "用户Id")]
        public int UserId { get; set; }
        [Display(Name = "收货人")]
        public string Consignee { get; set; }
        [Display(Name = "所在地区")]
        public string Area { get; set; }
        [Display(Name = "详细地址")]
        public string DetailedAddress { get; set; }
        [Display(Name = "手机")]
        public string Phone { get; set; }
        [Display(Name = "固定电话")]
        public string FixedPhone { get; set; }
        [Display(Name = "电子邮箱")]
        public string EmailAddress { get; set; }
        [Display(Name = "地址别名")]
        public string AddressAlias { get; set; }


    }
}