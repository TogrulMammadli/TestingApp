﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.QuestionsRepository
{
  public  interface IQuestionRepository
    {
        IEnumerable<Question> GetAllQuestions();
        bool RemoveQuestionById(int Id);
        bool AddQuestion(Question question);
        Question GetQuestionByID(int ID);
    }
}
