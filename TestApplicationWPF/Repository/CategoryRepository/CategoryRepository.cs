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
   public  class CategoryRepository : ICategoryRepository
    {
        public bool AddCategory(Category category)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.Categories.Add(category);
                    c.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        public Category GetCategoryGetCategoryByName(string categoryName)
        {
            using (var c = new TestContext())
            {
                foreach(var temp in c.Categories)
                {
                    if(temp.Name == categoryName)
                    {
                        return temp;
                    }
                }
                MessageBox.Show("Не было найдено данного имени!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
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
                MessageBox.Show("Не было найдено данного id!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
    }
}
