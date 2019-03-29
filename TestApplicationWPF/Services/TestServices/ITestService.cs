using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Services.TestServices
{
  public  interface ITestService
    {
        IEnumerable<TestBlank> GetAllTestBlanks();
        IEnumerable<TestBlank> GetAllOriginalBlanks();
        IEnumerable<TestBlank> GetAllUsedBlanks();
        bool CreateTestBlank(TestBlank testBlank);

    }
}
