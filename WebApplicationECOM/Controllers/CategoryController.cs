using Microsoft.AspNetCore.Mvc;
using WebApplicationECOM.Models;

namespace WebApplicationECOM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static List<Category> listofCategories = new List<Category>

        {

            new Category {Id = 1, Title = "Samsung", DisplayOrder = 1 },

            new Category {Id = 2, Title = "Vivo", DisplayOrder = 2 },

            new Category {Id = 3, Title = "Apple", DisplayOrder = 3 },

            new Category {Id = 4, Title = "Oppo", DisplayOrder = 4 },

            new Category {Id = 5, Title = "Realme", DisplayOrder = 5 }


        };
        //private readonly CategoryRepository _categoryRepository = null;

        //public CategoryController()
        //{
        //    _categoryRepository = new CategoryRepository();
        //}
        [HttpGet]

        public IEnumerable<Category> Get()

        {

            return listofCategories;

        }

        [HttpPost]

        public void post([FromBody] Category category)

        {

            listofCategories.Add(category);

        }

        [HttpPut("{id}")]

        public void put(int id, [FromBody] Category category)

        {

            listofCategories[id] = category;

        }

        [HttpDelete("{id}")]

        public void Delete(int id)

        {

            listofCategories.RemoveAt(id);


        }
    }
}
