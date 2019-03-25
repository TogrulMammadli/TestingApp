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
        public bool AddPassedTest(Exams question)
        {
            //using (var c = new TestContext())
            //{
            //    try
            //    {
            //        c.PassedTests.Add(question);
            //        c.SaveChanges();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return false;
            //    }
            //}
            return true;
        }

        public IEnumerable<Exams> GetAllPassedTests()
        {
            //using (var c = new TestContext())
            //{
            //    return c.PassedTests;
            //}
            return new List<Exams>();
        }

        public Exams GetPassedTestByID(int ID)
        {
            //using (var c = new TestContext())
            //{
            //    foreach(var temp in c.PassedTests)
            //    {
            //        if(temp.Id == ID)
            //        {
            //            return temp;
            //        }
            //    }
            //    MessageBox.Show("Не было найдено сданного экзамена с данным ID!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return null;
            //}
            return new Exams();
        }

        public ICollection<Exams> GetPassedTestsByUser(User user)
        {
            //using (var c = new TestContext())
            //{
            //    List<Exams> passedTests = new List<Exams>();
            //    foreach(var temp in c.PassedTests)
            //    {
            //        if(temp.User == user)
            //        {
            //            passedTests.Add(temp);
            //        }
            //    }
            //    if(passedTests.Count != 0)
            //    {
            //        return passedTests;
            //    }
            //    MessageBox.Show("Не было найдено сданных экзаменов с данным пользователем!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return null;
            //}
            return new List<Exams>();
        }

        public bool RemovePassedTestById(int Id)
        {
            //using (var c = new TestContext())
            //{
            //    foreach (var test in c.PassedTests)
            //    {
            //        if (test.Id == Id)
            //        {
            //            c.PassedTests.Remove(test);
            //        c.SaveChanges();
            //            return true;
            //        }
            //    }
            //    MessageBox.Show("Не было найдено сданного экзамена с данным ID!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return false;
            //}
            return true;
        }
    }
}
