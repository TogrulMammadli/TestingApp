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
        IEnumerable<Exams> GetAllPassedTests();
        bool RemovePassedTestById(int Id);
        bool AddPassedTest(Exams passedTests);
        Exams GetPassedTestByID(int ID);
        ICollection<Exams> GetPassedTestsByUser(User user);
    }
}
