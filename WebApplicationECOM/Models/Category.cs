using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationECOM.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title{ get; set; }

        public int DisplayOrder { get; set; }

        [NotMapped]
        public IFormFile CategoryImage { get; set; }
    }
}
