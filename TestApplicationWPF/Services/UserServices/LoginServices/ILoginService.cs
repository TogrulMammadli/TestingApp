using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Services.UserServices.LoginServices
{
    public interface ILoginService
    {
        bool Login(string Login,string password);

    }
}
