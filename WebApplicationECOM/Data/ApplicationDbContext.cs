using Microsoft.EntityFrameworkCore;
using WebApplicationECOM.Models;

namespace WebApplicationECOM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        //public DbSet<Category > categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCover> BookCovers { get; set; }

        public DbSet<BookWriter> BookWriters { get; set; }

    }
}
