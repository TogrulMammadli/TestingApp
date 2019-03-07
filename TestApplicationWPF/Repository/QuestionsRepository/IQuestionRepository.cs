using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.QuestionsRepository
{
    interface IQuestionRepository
    {
        IEnumerable<Question> GetAllQuestions();
        Question RemoveQuestionById(int Id);
        bool AddQuestion(Question question);
    }
}
