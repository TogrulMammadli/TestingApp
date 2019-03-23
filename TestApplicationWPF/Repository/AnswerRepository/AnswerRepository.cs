using System;
using System.Collections.Generic;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AnswerRepository
{
    public class CorrectAnswerRepository : IAnswerCorrectRepository
    {
        public bool AddAnswer(CorrectAnswer answer)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.correctAnswers.Add(answer);
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

        public CorrectAnswer GetAccessLevelByID(int ID)
        {
            using (var c = new TestContext())
            {
                foreach(var temp in c.correctAnswers)
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

        public IEnumerable<CorrectAnswer> GetAllAnswers()
        {
            using (var c = new TestContext())
            {
                return c.correctAnswers;
            }
        }

        public bool RemoveAnsweryById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach(var test in c.correctAnswers)
                {
                    if(test.Id == Id)
                    {
                        c.correctAnswers.Remove(test);
                        c.SaveChanges();

                        return true;
                    }
                }
                MessageBox.Show("Ответа с данным ID не было найдено!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
    }



    public class WrongAnswerRepository : IWrongAnswerRepository
    {
        public bool AddAnswer(WrongAnswer answer)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.wrongAnswers.Add(answer);
                    c.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }

        public WrongAnswer GetAccessLevelByID(int ID)
        {
            using (var c = new TestContext())
            {
                foreach (var temp in c.wrongAnswers)
                {
                    if (temp.Id == ID)
                    {
                        return temp;
                    }
                }
                MessageBox.Show("Ответа с данным ID не было найдено!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public IEnumerable<WrongAnswer> GetAllAnswers()
        {
            using (var c = new TestContext())
            {
                return c.wrongAnswers;
            }
        }

        public bool RemoveAnsweryById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.wrongAnswers)
                {
                    if (test.Id == Id)
                    {
                        c.wrongAnswers.Remove(test);
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
