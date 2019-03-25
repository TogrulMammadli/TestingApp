using System.Collections.Generic;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AnswerRepository
{
    public interface IWrongAnswerRepository
    {
        IEnumerable<WrongAnswer> GetAllAnswers();
        bool RemoveAnsweryById(int Id);
        bool AddAnswer(WrongAnswer answer);
        WrongAnswer GeWrongAnswerByID(int ID);
    }
}