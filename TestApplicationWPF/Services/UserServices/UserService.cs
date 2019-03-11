using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.UserRepository;

namespace TestApplicationWPF.Services.UserServices
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
    }
}
