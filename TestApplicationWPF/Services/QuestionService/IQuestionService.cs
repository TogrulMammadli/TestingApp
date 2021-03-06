﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Services.QuestionService
{
   public interface IQuestionService
    {
        bool AddQuestion(Question question);
        string OpenFileGetPath();
        byte[] ConvertImageToByte(string path);
        IEnumerable<Question> GetAllQuestions();
        bool RemoveQuestion(Question question);
    }
}
