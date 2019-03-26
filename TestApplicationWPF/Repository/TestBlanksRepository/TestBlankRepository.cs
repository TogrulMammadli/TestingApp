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
            try
            {
                TestContext.Instance.TestBlanks.Add(testBlank);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }

        public IEnumerable<TestBlank> GetAllTestBlanks()
        {
            return TestContext.Instance.TestBlanks.ToList();
        }

        public TestBlank GetTestBlankByID(int ID)
        {
            try
            {
                return TestContext.Instance.TestBlanks.Where(x => x.Id == ID).DefaultIfEmpty().Single();
            }
            catch
            {
                return null;
            }
        }

        public TestBlank GetTestBlankByName(string name)
        {
            try
            {
                return TestContext.Instance.TestBlanks.Where(x => x.Name == name).DefaultIfEmpty().Single();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool RemoveTestBlank(TestBlank testBlank)
        {
            try
            {
                TestContext.Instance.TestBlanks.Remove(testBlank);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public bool RemoveTestBlankById(int Id)
        {
            try
            {
                TestContext.Instance.TestBlanks.Remove(TestContext.Instance.TestBlanks.Where(x => x.Id == Id).First());
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
