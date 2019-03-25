using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        bool AddCategory(Category category);
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryByID(int ID);
        Category GetCategoryByName(string categoryName);
        bool RemoveCategory(Category category);
        bool RemoveCategoryById(int Id);
    }
}
