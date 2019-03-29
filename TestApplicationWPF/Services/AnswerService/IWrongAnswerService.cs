using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Services.AnswerService
{
    interface IWrongAnswerService
    {
        IEnumerable<WrongAnswer> GetAllAnswers();
        bool AddWrongAnswer(WrongAnswer wrongAnswer);
    } 
}
