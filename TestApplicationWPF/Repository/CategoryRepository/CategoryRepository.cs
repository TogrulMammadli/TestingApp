using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.CategoryRepository
{
    class CategoryRepository : ICategoryRepository
    {
        public bool AddCategory(Category category)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.Categories.Add(category);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            using (var c = new TestContext())
            {
                return c.Categories;
            }
        }

        public bool RemoveCategoryById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.Categories)
                {
                    if (test.Id == Id)
                    {
                        c.Categories.Remove(test);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
