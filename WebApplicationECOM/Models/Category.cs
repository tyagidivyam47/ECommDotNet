using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationECOM.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title can not be empty")]
        public string Title{ get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [NotMapped]
        public IFormFile? CategoryImage { get; set; }
        
        public string? CategoryImagePath { get; set; }
    }
}
