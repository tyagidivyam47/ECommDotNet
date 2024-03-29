﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationECOM.Data;
using WebApplicationECOM.Helper;
using WebApplicationECOM.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationECOM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoversController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CoversController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CoversController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var covers = await (from cover in _context.BookCovers
                                select new
                                {
                                    Id = cover.Id,
                                    Title = cover.Title,
                                    ImageUrl = cover.ImageUrl,
                                    WriterId = cover.Id
                                }
                                ).ToListAsync();
            return Ok(covers);
        }

        // GET api/<CoversController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cover = await _context.BookCovers.Where(x => x.Id == id).Include(x => x.Books).FirstOrDefaultAsync();
            return Ok(cover);
        }

        // POST api/<CoversController>
        // POST api/<WritersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BookCover cover)
        {
            cover.ImageUrl = await FileHelper.UploadImage(cover.ImageFile);
            await _context.BookCovers.AddAsync(cover);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CoversController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoversController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
