using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.UserServices;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for ForgotPassWindow.xaml
    /// </summary>
    public partial class ForgotPassWindow : Window
    {
        UserService userService = new UserService(new UserRepository());
        User user = new User();
        public ForgotPassWindow()
        {
            InitializeComponent();
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(EmailBox.Text))
            {
                EmailBox.BorderBrush = Brushes.Red;
                this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Hidden);
                TextBlockWarning.Text = "Please fill all fields";
                return;
            }
            if (IsValid(EmailBox.Text) == false)
            {
                EmailBox.BorderBrush = Brushes.Red;
                this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Hidden);
                TextBlockWarning.Text = "Please enter email format";
                return;
            }
            TextBlockWarning.Text = "";
           Task Log = new Task(Send);

            Log.Start();
            {
                Log.ContinueWith((x) =>
                {
                    if (Log.IsCompleted)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            if (user != null)
                            {
                                Security.Code = Generate();
                                MailMessage mailMessage = new MailMessage();
                                mailMessage.Subject = "Reset Password";
                                mailMessage.IsBodyHtml = true;
                                mailMessage.Body = $"Your reset password : <b>{Security.Code}</b><br><br>" +
                                    "Thanks";
                                userService.SendMail(mailMessage, EmailBox.Text);
                                ForgotPassword2 forgotPassword2 = new ForgotPassword2(user,Security.Code);
                                forgotPassword2.Show();
                                this.Close();
                            }
                            else
                            {
                                TextBlockWarning.Text = "Haven't user with this Email";
                                this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Hidden);
                            }
                        });
                    }
                });
            }
        }

        public void Send()
        {
            this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Visible);
            this.Dispatcher.InvokeAsync(() => this.EmailBox.BorderBrush = Brushes.Gray);

            try
            {
                user = userService.EmailValidation(this.Dispatcher.Invoke(() => EmailBox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private Random _random = new Random();
        private string Generate()
        {
            return _random.Next(0, 9999).ToString("D4");
        }


        static public class Security
        {
            static public string Code { get; set; }
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
