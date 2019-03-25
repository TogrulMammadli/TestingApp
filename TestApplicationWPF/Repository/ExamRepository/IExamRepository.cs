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
        bool AddPassedTest(Exams exam);
        IEnumerable<Exams> GetAllPassedTests();
        Exams GetPassedTestByID(int ID);
        ICollection<Exams> GetPassedTestsByUser(User user);
        bool RemoveExam(Exams exams);
        bool RemoveAccessLevelById(int Id);
    }
}
