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
                    //-InnerException  { "The conversion of a datetime2 data type to a datetime data type resulted in an out-of-range value.\r\nThe statement has been terminated."}
                    //System.Exception { System.Data.SqlClient.SqlException}

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
