using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.QuestionsRepository
{
    class QuestionRepository : IQuestionRepository
    {
        public bool AddQuestion(Question question)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.Questions.Add(question);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            using (var c = new TestContext())
            {
                return c.Questions;
            }
        }

        public bool RemoveQuestionById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.Questions)
                {
                    if (test.Id == Id)
                    {
                        c.Questions.Remove(test);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
