using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.TestBlanksRepository
{
    class TestBlankRepository : ITestBlankRepository
    {
        public bool AddTestBlank(TestBlank testBlank)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.TestBlanks.Add(testBlank);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public IEnumerable<TestBlank> GetAllTestBlanks()
        {
            using (var c = new TestContext())
            {
                return c.TestBlanks;
            }
        }

        public TestBlank GetTestBlankByID(int ID)
        {
            using (var c = new TestContext())
            {
                foreach(var temp in c.TestBlanks)
                {
                    if(temp.Id == ID)
                    {
                        return temp;
                    }
                }
                MessageBox.Show("Не было найдено тестового бланка с данным ID!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public TestBlank GetTestBlankByName(string name)
        {
            using (var c = new TestContext())
            {
                foreach (var temp in c.TestBlanks)
                {
                    if (temp.Name == name)
                    {
                        return temp;
                    }
                }
                MessageBox.Show("Не было найдено тестового бланка с данным именем!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public bool RemoveTestBlankById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.TestBlanks)
                {
                    if (test.Id == Id)
                    {
                        c.TestBlanks.Remove(test);
                        c.SaveChanges();
                        return true;
                    }
                }
                MessageBox.Show("Не было найдено тестового бланка с данным ID!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
    }
}
