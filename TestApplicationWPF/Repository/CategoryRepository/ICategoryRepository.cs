using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.CategoryRepository
{
    interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        bool RemoveCategoryById(int Id);
        bool AddCategory(Category category);
        Category GetCategoryByName(string categoryName);
        Category GetCategoryByID(int ID);
    }
}
