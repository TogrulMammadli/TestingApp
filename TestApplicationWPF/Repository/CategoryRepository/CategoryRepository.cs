using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public bool AddCategory(Category category)
        {
            try
            {
                TestContext.Instance.Categories.Add(category);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return TestContext.Instance.Categories.ToList();

        }

        public Category GetCategoryByID(int ID)
        {
            return TestContext.Instance.Categories.First(x => x.Id == ID);
        }

        public Category GetCategoryByName(string categoryName)
        {
            return TestContext.Instance.Categories.First(x => x.Name == categoryName);
        }

        public bool RemoveCategory(Category category)
        {
            try
            {
                TestContext.Instance.Categories.Remove(category);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveCategoryById(int Id)
        {
            try
            {
                TestContext.Instance.Categories.Remove(TestContext.Instance.Categories.Where(x => x.Id == Id).First());
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
