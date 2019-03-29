using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.AnswerRepository;

namespace TestApplicationWPF.Services.AnswerService
{
    class WrongAnswerService : IWrongAnswerService
    {
        private IWrongAnswerRepository wrongRepository = new WrongAnswerRepository();

        public WrongAnswerService(IWrongAnswerRepository wrongRepository)
        {
            this.wrongRepository = wrongRepository ?? throw new ArgumentNullException(nameof(wrongRepository));
        }

        public bool AddWrongAnswer(WrongAnswer wrongAnswer)
        {
            return wrongRepository.AddAnswer(wrongAnswer);
        }

        public IEnumerable<WrongAnswer> GetAllAnswers()
        {
            return this.wrongRepository.GetAllAnswers();
        }
    }
}
