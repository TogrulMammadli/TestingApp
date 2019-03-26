using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class UserRepository : IUserRepository
    {
        public bool AddUser(User user)
        {
            try
            {
                TestContext.Instance.Users.Add(user);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return TestContext.Instance.Users.Include("AccessLevels").ToList();
        }

        public User GetUserByID(int ID)
        {
            return TestContext.Instance.Users.Include("AccessLevels").Where(x => x.Id == ID).DefaultIfEmpty().Single();
        }

        public User GetUserByEmail(string email)
        {
            return TestContext.Instance.Users.Include("AccessLevels").Where(x => x.Email == email).DefaultIfEmpty().Single();
        }

        public User GetUserByLogin(string login)
        {
            var user= TestContext.Instance.Users.Include("AccessLevels").Where(x => x.Login == login).DefaultIfEmpty().Single();
            return user;
        }

        public bool RemoveUser(User user)
        {
            try
            {
                TestContext.Instance.Users.Remove(user);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveUserById(int Id)
        {
            try
            {
                TestContext.Instance.Users.Remove(TestContext.Instance.Users.Where(x => x.Id == Id).First());
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
