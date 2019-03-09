using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.PassedTestRepository
{
    interface IPassedTestRepository
    {
        IEnumerable<PassedTests> GetAllPassedTests();
        bool RemovePassedTestById(int Id);
        bool AddPassedTest(PassedTests passedTests);
    }
}
