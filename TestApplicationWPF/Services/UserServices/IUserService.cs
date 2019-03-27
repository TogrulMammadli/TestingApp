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
        void SentEmailToUsers(List<User> toUsers, string Message);
        void AddUser(User user);
        List<string> GetUserAccessLevels(User user);
        bool ChangeName(string name);
        bool ChangeSurname(string surname);
        bool ChangePatronomyic(string patronomyic);
        bool ChangePhoneNumber(string phonenumber);
        bool ChangeEmail(string email);
        bool ChangePassword(string password);
        bool ChangeLogin(string Login);
        bool ChangeImage(byte[] İmage);
        bool AddNewAccessLevelTouser(AccessLevel accessLevel);
        bool RemoveAccessLevelfromUser(AccessLevel accessLevel);
        void RemoveUser(User user);
        string OpenFileGetPath();
        byte[] ConvertImageToByte(string path);
    }
}
