using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Mesages
{
    class NewQuestionMessages
    {
        public Question NewQuestion { get; set; }

        public NewQuestionMessages(Question question)
        {
            NewQuestion = question ?? throw new ArgumentNullException(nameof(question));
        }
    }
}
