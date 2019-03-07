using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.PassedTestRepository
{
    class PassedTestRepository : IPassedTestRepository
    {
        public bool AddPassedTest(PassedTests question)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PassedTests> GetAllPassedTests()
        {
            throw new NotImplementedException();
        }

        public PassedTests RemovePassedTestById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
