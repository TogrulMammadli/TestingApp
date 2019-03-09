﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Services.UserServices
{
   public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
    }
}
