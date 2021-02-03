using System.ComponentModel.DataAnnotations.Schema;

namespace JdMvcHouTai.Models
{

    public class Image
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FileUrl { get; set; }
        public string Img { get; set; }

    }
}