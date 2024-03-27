using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationECOM.Data;
using WebApplicationECOM.Filters;
using WebApplicationECOM.Helper;
using WebApplicationECOM.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationECOM.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> Get(int? pageNum, int? pageSize, string? sortPrice)
    {
        int currPageNum = pageNum ?? 0;
        int currPageSize = pageSize ?? 5;
        var books = await (from book in _context.Books
                           select new
        
                           {
                               book.Id,
                               book.Title,
                               book.ImageUrl,
                               book.BookUrl,
                               book.Description
                           }
                          ).ToListAsync();
        return Ok(books.Skip((currPageNum - 1) * currPageSize).Take(currPageSize));
    }

    // GET api/<BooksController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var book = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        return Ok(book);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetTrending(int? pageNum, int? pageSize)
    {
        int currPageNum = pageNum ?? 0;
        int currPageSize = pageSize ?? 5;
        var books = await (from book in _context.Books
                           where book.Trending == true
                           select new
                           {
                               book.Id,
                               book.Title,
                               book.ImageUrl,
                               book.BookUrl,
                               book.Description
                           }
                           ).ToListAsync();
        return Ok(books.Skip((currPageNum - 1) * currPageSize).Take(currPageSize));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> NewBooks()
    {
        var books = await (from book in _context.Books
                           orderby book.CreatedDate descending
                           select new
                           {
                               book.Id,
                               book.Title,
                               book.ImageUrl,
                               book.BookUrl,
                               book.Description
                           }
                           ).Take(5).ToListAsync();
        return Ok(books);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> SearchBook(string query)
    {
        var books = await (from book in _context.Books
                           where book.Title.Contains(query)
                           select new
                           {
                               book.Id,
                               book.Title,
                               book.ImageUrl,
                               book.BookUrl,
                               book.Description
                           }
                           ).ToListAsync();
        return Ok(books);
    }

    // POST api/<BooksController>
    [HttpPost]
    public async Task<IActionResult> Post([FromForm] Book book)
    {
        book.ImageUrl = await FileHelper.UploadImage(book.ImageFile);
        book.BookUrl = await FileHelper.UploadUrl(book.BookFile);
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<BooksController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<BooksController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
}
