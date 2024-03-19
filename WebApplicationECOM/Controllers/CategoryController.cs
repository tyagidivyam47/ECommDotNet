using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationECOM.Data;
using WebApplicationECOM.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationECOM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.categories.ToListAsync());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var existingCategory = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCategory == null)
            {
                return NotFound("Category Not Found");
            }
            return Ok(existingCategory);
        }

        // POST api/<CategoryController>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Category category)
        //{
        //    //if (category == null || category.Title == null || category.DisplayOrder == null)
        //    //{
        //    //    return BadRequest("Bad Request!");
        //    //}
        //    await _context.categories.AddAsync(category);
        //    await _context.SaveChangesAsync();
        //    return StatusCode(StatusCodes.Status201Created);
        //}

        [HttpPost]
        public async Task Post([FromForm] Category category)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=shoppingcartaccount;AccountKey=g0Tjm+xJyUtex/Bbj6dQfq7SbHt4f+mMR03hlPjfi7agrvUUMB6fm/Fmyb+bxNlBcVlOXz5iHM2c+AStkvpw/Q==;EndpointSuffix=core.windows.net";
            string containerName = "shoppingcartimages";
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = containerClient.GetBlobClient(category.CategoryImage.FileName);
            MemoryStream ms = new MemoryStream();
            await category.CategoryImage.CopyToAsync(ms);
            ms.Position = 0;
            await blobClient.UploadAsync(ms);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var categoryFromDb = _context.categories.FirstOrDefault(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound("Category not found");
            }
            categoryFromDb.Title = category.Title;
            categoryFromDb.DisplayOrder = category.DisplayOrder;
            _context.categories.Update(categoryFromDb);
            await _context.SaveChangesAsync();
            return Ok("Category Updated");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryFromDb = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound("category not found");
            }
            _context.categories.Remove(categoryFromDb);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
