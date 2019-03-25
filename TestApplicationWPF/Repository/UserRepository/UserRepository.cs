using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.UserRepository
{
    class UserRepository : IUserRepository
    {
        public bool AddUser(User user)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.Users.Add(user);
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

        public  IEnumerable<User> GetAllUsers()
        {
            //IEnumerable<User> users;
            //using (var c = new TestContext())
            //{
            //    users = c.Users.Include("AccessLevels");
            //}
            //return users;
            IEnumerable<User> users;
            users = new List<User> { GetUserByID(1) };
            return users;
        }

        public User GetUserByEmail(string email)
        {
            using (var c = new TestContext())
            {
                foreach (var temp in c.Users.Include("AccessLevels"))
                {
                    if (temp.Email == email)
                    {
                        return temp;
                    }
                }
                return null;
            }
        }

        public User GetUserByID(int ID)
        {
            using (var c = new TestContext())
            {
                foreach (var temp in c.Users.Include("AccessLevels"))
                {
                    if (temp.Id == ID)
                    {
                        return temp;
                    }
                }
                MessageBox.Show("Не было найдено пользователя с данным ID!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public User GetUserByLogin(string login)
        {
            using (var c = new TestContext())
            {
                foreach (var temp in c.Users.Include("AccessLevels"))
                {
                    if (temp.Login == login)
                    {
                        return temp;
                    }
                }
                return null;
            }
        }

        public bool RemoveUserById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.Users.Include("AccessLevels"))
                {
                    if (test.Id == Id)
                    {
                        c.Users.Remove(test);
                        c.SaveChanges();
                        return true;
                    }
                }
                MessageBox.Show("Не было пользователя с данным ID!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
       
    }
}
