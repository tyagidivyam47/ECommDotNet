
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationECOM.Data;
using WebApplicationECOM.Helper;
using WebApplicationECOM.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationECOM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WritersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<WritersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var writers = await (from writer in _context.BookWriters
                                 select new
                                 {
                                     Id = writer.Id,
                                     Name = writer.Name,
                                     ImageUrl = writer.ImageUrl,
                                 }
                                ).ToListAsync();
            return Ok(writers);
        }

        // GET api/<WritersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var writer = await (_context.BookWriters.Where(x => x.Id == id)).Include(x => x.Books).FirstOrDefaultAsync();
            return Ok(writer);
        }

        // POST api/<WritersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BookWriter writer)
        {
            writer.ImageUrl = await FileHelper.UploadImage(writer.ImageFile);
            await _context.BookWriters.AddAsync(writer);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<WritersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WritersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
