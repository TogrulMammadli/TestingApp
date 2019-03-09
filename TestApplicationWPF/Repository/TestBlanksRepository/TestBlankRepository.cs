using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool RemoveTestBlankById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.TestBlanks)
                {
                    if (test.Id == Id)
                    {
                        c.TestBlanks.Remove(test);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
