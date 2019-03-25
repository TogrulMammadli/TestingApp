using System;
using System.Collections.Generic;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AnswerRepository
{
    public class CorrectAnswerRepository : IAnswerCorrectRepository
    {
        public bool AddAnswer(CorrectAnswer answer)
        {
            try
            {
                TestContext.Instance.correctAnswers.Add(answer);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CorrectAnswer GetAnswerByID(int ID)
        {
            try
            {
                return TestContext.Instance.correctAnswers.Find(ID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<CorrectAnswer> GetAllAnswers()
        {
            return TestContext.Instance.correctAnswers.Include("Questions");
        }

        public bool RemoveAnsweryById(int Id)
        {
            try
            {
                TestContext.Instance.correctAnswers.Remove(TestContext.Instance.correctAnswers.Find(Id));
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }


    public class WrongAnswerRepository : IWrongAnswerRepository
    {
        public bool AddAnswer(WrongAnswer answer)
        {
            try
            {
                TestContext.Instance.wrongAnswers.Add(answer);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public WrongAnswer GeWrongAnswerByID(int ID)
        {
          return  TestContext.Instance.wrongAnswers.Find(ID);
        }

        public IEnumerable<WrongAnswer> GetAllAnswers()
        {
           return TestContext.Instance.wrongAnswers;
        }

        public bool RemoveAnsweryById(int Id)
        {
            try
            {
                TestContext.Instance.wrongAnswers.Remove(TestContext.Instance.wrongAnswers.Find(Id));
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
