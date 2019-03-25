using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.QuestionsRepository
{
    public interface IQuestionRepository
    {
        bool AddQuestion(Question question);
        IEnumerable<Question> GetAllQuestions();
        Question GetQuestionByID(int ID);
        bool RemoveQuestionById(int Id);
        bool RemoveQuestion(Question question);
    }
}
