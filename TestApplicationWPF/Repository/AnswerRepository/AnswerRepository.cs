using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AnswerRepository
{
    public class AnswerRepository : IAnswerRepository
    {
        public bool AddAnswer(Answer answer)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.Answers.Add(answer);
                    c.SaveChanges();

                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public IEnumerable<Answer> GetAllAnswers()
        {
            using (var c = new TestContext())
            {
                return c.Answers;
            }
        }

        public bool RemoveAnsweryById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach(var test in c.Answers)
                {
                    if(test.Id == Id)
                    {
                        c.Answers.Remove(test);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
