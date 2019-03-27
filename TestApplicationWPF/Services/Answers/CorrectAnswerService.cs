using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.AnswerRepository;

namespace TestApplicationWPF.Services.Answers
{
    class CorrectAnswerService : ICorrectAnswerService
    {
        public IAnswerCorrectRepository answerCorrectRepository = new CorrectAnswerRepository();

        public CorrectAnswerService(IAnswerCorrectRepository answerCorrectRepository)
        {
            this.answerCorrectRepository = answerCorrectRepository ?? throw new ArgumentNullException(nameof(answerCorrectRepository));
        }

        public IEnumerable<CorrectAnswer> GetAllAnswers()
        {
            throw new NotImplementedException();
        }
    }
}
