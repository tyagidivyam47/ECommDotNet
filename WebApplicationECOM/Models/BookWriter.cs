using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationECOM.Models
{
    public class BookWriter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string? ImageUrl {  get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public ICollection<Book>? Books { get; set;}

        public ICollection<BookCover>? BookCovers { get; set; }
    }
}
