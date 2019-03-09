using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                    MessageBox.Show(ex.Message);

                    return false;
                }
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var c = new TestContext())
            {
                return c.Users;
            }
        }

        public bool GetUserByLogin()
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.Users)
                {
                    if (test.Id == Id)
                    {
                        c.Users.Remove(test);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
