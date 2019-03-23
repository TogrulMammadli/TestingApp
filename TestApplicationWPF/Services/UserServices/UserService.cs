using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.PassedTestRepository;
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
        public User Login(string Login, string password)
        {
            var user = userRepository.GetUserByLogin(Login);

            if (user != null && user.Password == password)
            {
                return user;
            }
            user = userRepository.GetUserByEmail(Login);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }


        public void  SentEmail (List<User> toUsers, string Message )//type1=invitation,type2=deleted event
        {
            try
            {
                PassedTestRepository passedTestRepository = new PassedTestRepository();
                foreach (var item in toUsers)
                {
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient();
                message.From = new MailAddress("app.test.mail@mail.ru");
                message.To.Add(new MailAddress(item.Email.ToString()));
                message.Subject = "TestingNotifications";
                message.Body = "Dear " + item.Name.ToString() + "You Have Exam tomorrow at" + passedTestRepository.GetPassedTestsByUser(item).ElementAt(0).BeginDate.Value.ToString()
                        +"\nPlease dont late!";
                client.Host = "smtp.mail.ru";
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("app.test.mail@mail.ru", "21101999toga");
                client.Send(message);
                }
            }
            catch
            {
            }
        }

      
        public void SentNotfications()
        {                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangeEmail(string email)                             //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangeImage(byte[] image)                             //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangeLogin(string Login)                             //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangeName(string name)                               //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangePassword(string password)                       //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangePatronomyic(string patronomyic)                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangePhoneNumber(string phonenumber)                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangeSurname(string surname)                         //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                          //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit

        public bool RemoveAccessLevelfromUser(AccessLevel accessLevel)
        {
            throw new NotImplementedException();
        }

        public bool AddNewAccessLevelTouser(AccessLevel accessLevel)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }

        public List<string> GetUserAccessLevels(User user)
        {
            List<string> names = new List<string>();
            foreach (var temp in user.AccessLevels)
            {

                names.Add(temp.Name);

            }
            return names;
        }
    }
}
