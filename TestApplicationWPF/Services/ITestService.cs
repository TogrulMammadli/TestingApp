using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Services
{
    public interface ITestService
    {
        void AddTestToDB(TestBlank testBlank);
        void AddQuestiontoDB(Question question);
    }
}
