using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AnswerRepository
{
    interface IAnswerRepository
    {
        IEnumerable<Answer> GetAllAnswers();
        bool RemoveAnsweryById(int Id);
        bool AddAnswer(Answer answer);
        Answer GetAccessLevelByID(int ID);
    }
}
