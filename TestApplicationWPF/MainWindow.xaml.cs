using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;
using System.Threading;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.UserServices;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserService userService = new UserService(new UserRepository());
        public MainWindow()
        {
                InitializeComponent();
                using (var ctx = new TestContext())
                {
                var user = new User()
                {
                    Name = "Togrul",
                    Surname = "Mamadli",
                    DateOfBirth = DateTime.Now,
                    Email = "mamedlitogrul99@gmail.com",
                    PhoneNumber = "0503907667",
                    Gender = Gender.Male,
                    //AccessLevels = new List<AccessLevel> { new AccessLevel() {Name="Admin" } },
                        Login = "TogrulLogin",
                        Password = "12345"
                    };
                try
                {
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
                ////  Console.WriteLine("vse");

                //userService.AddUser(user);

            }

        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            HeadWindow headWindow = new HeadWindow();
            headWindow.Show();
            this.Close();
        }

        private void ButtonForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassWindow forgotPassWindow = new ForgotPassWindow();
            forgotPassWindow.ShowDialog();
        }
    }
}
