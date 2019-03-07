using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.TestBlanksRepository
{
    interface ITestBlankRepository
    {
        IEnumerable<TestBlank> GetAllTestBlanks();
        TestBlank RemoveTestBlankById(int Id);
        bool AddTestBlank(TestBlank testBlank);
    }
}
