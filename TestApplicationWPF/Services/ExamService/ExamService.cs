using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Services.ExamService
{
    public class Result
    {
        public int CorrectsNumber { get; set; }
        public int WrongsNumber { get; set; }
        public int UnAnswered { get; set; }
    };

    public class ExamService : IExamService
    {
        public Result CheckExam(Exams exams)
        {
            Result result = new Result();

            foreach (var question in exams.Blank.Questions)
            {
                var i = 0;
                bool validation = false;
                if (question.CorrectAnswers.Count == exams.studentanswer.Count)
                {
                    foreach (var item in exams.studentanswer)
                    {
                        //if (question.CorrectAnswers.Contains(item.Answers))
                        //{

                        //}
                    }

                }
                else
                {

                }
                ++i;
            }
            return result;

        }

        public IEnumerable<Exams> GetUserExams(User user)
        {
            return TestContext.Instance.PassedTests.Include("Blank").Where(x => x.User.Id == user.Id).ToList();
        }
    }


}

