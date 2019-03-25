using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.PassedTestRepository
{
    class PassedTestRepository : IPassedTestRepository
    {
        public bool AddPassedTest(Exams exam)
        {
            try
            {
                TestContext.Instance.PassedTests.Add(exam);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Exams> GetAllPassedTests()
        {

            return TestContext.Instance.PassedTests.ToList() ;
        }

        public Exams GetPassedTestByID(int ID)
        {
            try
            {
                return TestContext.Instance.PassedTests.Where(x => x.Id == ID).First();
            }
            catch
            {
                return null;
            }
        }

        public ICollection<Exams> GetPassedTestsByUser(User user)
        {
            try
            {
                return TestContext.Instance.PassedTests.Where(x => x.User == user).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool RemoveExam(Exams exams)
        {
            try
            {
                TestContext.Instance.PassedTests.Remove(exams);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool RemoveAccessLevelById(int Id)
        {
            try
            {
                TestContext.Instance.PassedTests.Remove(TestContext.Instance.PassedTests.First(x => x.Id == Id));
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
