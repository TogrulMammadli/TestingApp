using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AnswerRepository
{
    interface IAnswerCorrectRepository
    {
        IEnumerable<CorrectAnswer> GetAllAnswers();
        bool RemoveAnsweryById(int Id);
        bool AddAnswer(CorrectAnswer answer);
        CorrectAnswer GetAccessLevelByID(int ID);
    }
}
