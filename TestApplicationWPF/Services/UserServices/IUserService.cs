using System;
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
        void SentNotfications();
        void SentEmail(List<User> toUsers, string Message);

        bool ChangeName(string name);
        bool ChangeSurname(string surname);
        bool ChangePatronomyic(string patronomyic);
        bool ChangePhoneNumber(string phonenumber);
        bool ChangeEmail(string email);
        bool ChangePassword(string password);
        bool ChangeLogin(string Login);
        bool ChangeImage(byte[] İmage);
        bool AddNewAccessLevelToStudent(AccessLevel accessLevel);
        bool RemoveAccessLevelfromStudent(AccessLevel accessLevel);
    }
}
