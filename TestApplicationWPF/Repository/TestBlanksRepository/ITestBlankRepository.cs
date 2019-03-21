using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.TestBlanksRepository
{
   public interface ITestBlankRepository
    {
        IEnumerable<TestBlank> GetAllTestBlanks();
        bool RemoveTestBlankById(int Id);
        bool AddTestBlank(TestBlank testBlank);
        TestBlank GetTestBlankByID(int ID);
        TestBlank GetTestBlankByName(string name);
    }
}
