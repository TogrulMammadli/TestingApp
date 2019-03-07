using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.QuestionsRepository
{
    class QuestionRepository : IQuestionRepository
    {
        public bool AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            throw new NotImplementedException();
        }

        public Question RemoveQuestionById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
