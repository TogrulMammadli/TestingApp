using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Mesages
{
    class NewUserMesenger
    {
        public User NewUser { get; set; }

        public NewUserMesenger(User newUser)
        {
            NewUser = newUser ?? throw new ArgumentNullException(nameof(newUser));
        }
    }
}
