using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AccessLevelRepository
{
    
    public class AccessLevelRepository : IAccessLevelRepository
    {
        public bool AddAccessLevel(AccessLevel accessLevel)
        {
            try
            {
                using (var c= new TestContext())
                {
                    c.AccessLevels.Add(accessLevel);
                    c.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }

        public AccessLevel GetAccessLevelByName(string accessName)
        {
            using (var c = new TestContext())
            {
                foreach(var temp in c.AccessLevels)
                {
                    if(temp.Name == accessName)
                    {
                        return temp;
                    }
                }
                MessageBox.Show("Не было найдено данного имени!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public IEnumerable<AccessLevel> GetAllAccessLevels()
        {
            using (var c = new TestContext())
            {
                return c.AccessLevels;
            }
        }

        public bool RemoveAccessLevelById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach(var test in c.AccessLevels)
                {
                    if(test.Id == Id)
                    {
                        c.AccessLevels.Remove(test);
                        return true;
                    }
                }
                MessageBox.Show("Не было найдено данного id!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
    }
}
