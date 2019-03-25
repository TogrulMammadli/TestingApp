using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using TestApplicationWPF.DataModel;
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

        public User EmailValidation(string email)
        {
            var user = userRepository.GetUserByEmail(email);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public void SendMail(MailMessage mail, string sendemail)
        {

            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.mail.ru");
                mail.From = new MailAddress("step.testing@mail.ru");
                mail.To.Add(sendemail);
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("step.testing@mail.ru", "app123*");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        public void SentEmailToUsers(List<User> toUsers, string Message)//type1=invitation,type2=deleted event
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
                            + "\nPlease dont late!";
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
        {                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangeEmail(string email)                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangeImage(byte[] image)                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangeLogin(string Login)                                                 //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangeName(string name)                                                   //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangePassword(string password)                                           //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {
            //est rabotayuwiy method update password,prosto vizovi ego                                                                                  //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangePatronomyic(string patronomyic)                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangePhoneNumber(string phonenumber)                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
                                                                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        public bool ChangeSurname(string surname)                                             //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        {                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
            throw new NotImplementedException();                                              //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit
        }                                                                                     //vse proverit ctobi unikalnie vewi ne zadavalis 2y raz t.e esli est login ctobi takoyje login 2y raz ne mogli dobavit

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

        public void UpdatePassword(int ID, string password)
        {
            //using (var context = new TestContext())
            //{
            //    var std = context.Users.First(x => x.Id == ID);
            //    std.Password = password;
            //    context.SaveChanges();
            //}
        }
        public byte[] ConvertImageToByte(string path)
        {
            Image image = Image.FromFile(path);
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] b = memoryStream.ToArray();
            return b;
        }
        public string GetAvatarImageFromDb(int UID)
        {
            //byte[] b;
            //using (var context = new TestContext())
            //{
            //    b = context.Users.First(x => x.Id == UID).İmage;
            //    if (b == null)
            //    {
            //        return null;
            //    }
            //}
            //Image image1;
            //using (var ms = new MemoryStream(b))
            //{
            //    image1 = Image.FromStream(ms);
            //}


            //image1.Save(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Icons\\" + "UserAva", System.Drawing.Imaging.ImageFormat.Bmp);
            return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Icons\\" + "UserAva";


        }

        public void UpdateAvatarImage(int userId, string Path)
        {
            //Image image = Image.FromFile(Path);
            //System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            //image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            //byte[] b = memoryStream.ToArray();
            //using (var context = new TestContext())
            //{
            //    var std = context.Users.First(x => x.Id == userId);
            //    std.İmage = b;
            //    context.SaveChanges();
            //}
        }

        public string OpenFileGetPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Images(*.BMP; *.JPG; *.GIF,*.PNG,*.TIFF)| *.BMP; *.JPG; *.GIF; *.PNG; *.TIFF | All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName.ToString();
            }
            else return "Error";
        }
        public void RemoveUser(User user) {
            userRepository.RemoveUser(user);
        }
        public void RemoveUserById(int Id)
        {
            userRepository.RemoveUserById(Id);
        }
    }
}
