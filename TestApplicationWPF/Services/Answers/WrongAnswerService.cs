using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.AnswerRepository;

namespace TestApplicationWPF.Services.Answers
{
    class WrongAnswerService : ICorrectAnswerService
    {
        public IWrongAnswerRepository wrongAnswerRepository = new WrongAnswerRepository();

        public WrongAnswerService(IWrongAnswerRepository wrongAnswerRepository)
        {
            this.wrongAnswerRepository = wrongAnswerRepository ?? throw new ArgumentNullException(nameof(wrongAnswerRepository));
        }

        public IEnumerable<WrongAnswer> GetAllAnswers()
        {
            throw new NotImplementedException();
        }

        IEnumerable<CorrectAnswer> ICorrectAnswerService.GetAllAnswers()
        {
            throw new NotImplementedException();
        }
    }
}
