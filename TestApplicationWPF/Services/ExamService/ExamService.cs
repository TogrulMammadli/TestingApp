using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Services.ExamService
{
    public class Result
    {
        public int CorrectsNumber { get; set; }
        public int WrongsNumber { get; set; }
        public int UnAnswered{ get; set; }
    };

    public class ExamService : IExamService
    {
        public Result CheckExam(Exams exams)
        {
            Result result = new Result();
          
            foreach (var question in exams.Blank.Questions)
            {
                var i=0;
                bool validation = false;
                if (question.CorrectAnswers.Count==exams.studentanswer.Count)
                {
                    foreach (var item in exams.studentanswer)
                    {
                    //    if (question.CorrectAnswers.Contains(item.Answers[i]))
                    //    {

                    //    }
                    }
                    
                }
                else
                {

                }
                ++i;
            }
            return result;
        }
        
    }
}
