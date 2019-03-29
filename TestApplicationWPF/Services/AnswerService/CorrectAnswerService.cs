using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.AnswerRepository;

namespace TestApplicationWPF.Services.AnswerService
{
    class CorrectAnswerService : ICorrectAnswerService
    {
        private IAnswerCorrectRepository correctRepository = new CorrectAnswerRepository();

        public CorrectAnswerService(IAnswerCorrectRepository correctRepository)
        {
            this.correctRepository = correctRepository ?? throw new ArgumentNullException(nameof(correctRepository));
        }

        public bool AddCorrectAnswer(CorrectAnswer correctAnswer)
        {
            return correctRepository.AddAnswer(correctAnswer);
        }

        public IEnumerable<CorrectAnswer> GetAllAnswers()
        {
            return correctRepository.GetAllAnswers();
        }
    }
}
