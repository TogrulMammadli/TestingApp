//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using TestApplicationWPF.DataModel;
//using TestApplicationWPF.Models;

//namespace TestApplicationWPF.Repository.QuestionsRepository
//{
//    class QuestionRepository : IQuestionRepository
//    {
//        public bool AddQuestion(Question question)
//        {
//            using (var c = new TestContext())
//            {
//                try
//                {
//                    c.Questions.Add(question);
//                    c.SaveChanges();
//                    return true;
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
//                    return false;
//                }
//            }
//        }

//        public IEnumerable<Question> GetAllQuestions()
//        {
//            using (var c = new TestContext())
//            {
//                return c.Questions;
//            }
//        }

//        public Question GetQuestionByID(int ID)
//        {
//            using (var c = new TestContext())
//            {
//                foreach(var temp in c.Questions)
//                {
//                    if(temp.Id == ID)
//                    {
//                        return temp;
//                    }
//                }
//                MessageBox.Show("Не было найдено вопроса с данным ID!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
//                return null;
//            }
//        }

//        public bool RemoveQuestionById(int Id)
//        {
//            using (var c = new TestContext())
//            {
//                foreach (var test in c.Questions)
//                {
//                    if (test.Id == Id)
//                    {
//                        c.Questions.Remove(test);
//                    c.SaveChanges();
//                        return true;
//                    }
//                }
//                MessageBox.Show("Не было найдено вопроса с данным ID!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
//                return false;
//            }
//        }
//    }
//}
