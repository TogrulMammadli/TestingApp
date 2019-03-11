using System;
using System.Collections.Generic;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AnswerRepository
{
    public class AnswerRepository : IAnswerRepository
    {
        public bool AddAnswer(Answer answer)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.Answers.Add(answer);
                    c.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }

        public Answer GetAccessLevelByID(int ID)
        {
            using (var c = new TestContext())
            {
                foreach(var temp in c.Answers)
                {
                    if(temp.Id == ID)
                    {
                        return temp;
                    }
                }
                MessageBox.Show("Ответа с данным ID не было найдено!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public IEnumerable<Answer> GetAllAnswers()
        {
            using (var c = new TestContext())
            {
                return c.Answers;
            }
        }

        public bool RemoveAnsweryById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach(var test in c.Answers)
                {
                    if(test.Id == Id)
                    {
                        c.Answers.Remove(test);
                        c.SaveChanges();

                        return true;
                    }
                }
                MessageBox.Show("Ответа с данным ID не было найдено!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
    }
}
