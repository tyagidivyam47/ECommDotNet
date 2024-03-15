using WebApplicationECOM.Models;

namespace WebApplicationECOM.Repository
{
    public class CategoryRepository
    {

        public List<Category> getCategories()
        {
            return categoriesData;
        }

        public List<Category> addCategory(Category category)
        {
            var newCategory = new Category()
            {
                Id = category.Id,
                Title = category.Title,
                DisplayOrder = category.DisplayOrder,
            };
            categoriesData.Add(newCategory);
            Console.WriteLine(newCategory.Title);
            foreach (Category category1 in categoriesData)
            {
                Console.WriteLine(category1.Title);
            }
            return categoriesData;
        }

        public static List<Category> categoriesData => new List<Category>
            {
            new Category { Id = 1, DisplayOrder = 1, Title = "Samsung"},
            new Category { Id = 2, DisplayOrder = 2, Title = "LG"},
            new Category { Id = 3, DisplayOrder = 3, Title = "MI"},
            new Category { Id = 4, DisplayOrder = 4, Title = "Oppo"},
            new Category { Id = 5, DisplayOrder = 5, Title = "Nokia"},
            };
    }
}
