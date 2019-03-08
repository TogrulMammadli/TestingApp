using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.UserRepository
{
    interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        bool RemoveUserById(int Id);
        bool AddUser(User user);
        bool GetUserByLogin();
    }
}
