using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationECOM.Models
{
    public class BookCover
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? ImageUrl{ get; set; }

        public int BookWriterId { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public ICollection<Book>? Books{ get; set; }
    }
}
