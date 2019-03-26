using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.QuestionsRepository
{
   public class QuestionRepository : IQuestionRepository
    {
        public bool AddQuestion(Question question)
        {
            try
            {
                TestContext.Instance.Questions.Add(question);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return TestContext.Instance.Questions.Include("CorrectAnswers").Include("WrongAnswers").ToList();
        }

        public Question GetQuestionByID(int ID)
        {
            return TestContext.Instance.Questions.Include("CorrectAnswers").Include("WrongAnswers").Where(x => x.Id == ID).First();

        }

        public bool RemoveQuestionById(int Id)
        {
            try
            {
                TestContext.Instance.Questions.Remove(TestContext.Instance.Questions.Where(x => x.Id == Id).First());
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveQuestion(Question question)
        {
            try
            {
                TestContext.Instance.Questions.Remove(question);
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
