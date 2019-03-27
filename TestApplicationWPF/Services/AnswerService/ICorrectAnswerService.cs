using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.AnswerRepository;

namespace TestApplicationWPF.Services.AnswerService
{
    interface ICorrectAnswerService
    {
        IEnumerable<CorrectAnswer> GetAllAnswers();
        bool AddCorrectAnswer(CorrectAnswer correctAnswer);
    }
}
