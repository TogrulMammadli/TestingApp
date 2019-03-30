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
            int valid = 0;
            var i = 0;
            foreach (var question in exams.Blank.Questions)
            {
                valid = 0;
                if (exams.studentanswer.ElementAt(i).Answers.Count>0)
                {
                    if (question.CorrectAnswers.Count == exams.studentanswer.ElementAt(i).Answers.Count)
                    {
                        foreach (var item in exams.studentanswer.ElementAt(i).Answers)
                        {
                            if (question.CorrectAnswers.Where(x => x.Text == item.An).Count() > 0)
                            {
                                valid = 1;
                            }
                        }
                    }
                }
                else
                {
                    valid = 3;
                }
                ++i;
                if (valid==1)
                {
                    ++result.CorrectsNumber;
                }
                else if(valid==2)
                {
                    ++result.WrongsNumber;
                }
                else if (valid==3)
                {
                    ++result.UnAnswered;
                }
            }
            return result;
        }

        public IEnumerable<Exams> GetUserExams(User user)
        {
            return TestContext.Instance.PassedTests.Include("Blank").Where(x => x.User.Id == user.Id).ToList();
        }
    }


}

