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
using System.Windows.Shapes;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.UserServices;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for ForgotPasswordWindow3.xaml
    /// </summary>
    public partial class ForgotPasswordWindow3 : Window
    {
        User User = new User();
        UserService userService = new UserService(new UserRepository());
        int Num = 1;
        public ForgotPasswordWindow3(User user,int num)
        {
            InitializeComponent();
            this.User = user;
             Num = num;
            if (num==2)
            {
                PassRecov.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Pass1Box.Password.ToString()) || string.IsNullOrWhiteSpace(Pass2Box.Password.ToString()))
            {
                this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Hidden);
                TextBlockWarning.Text = "Please fill all the fields";
                return;
            }
            if (Pass1Box.Password.ToString() != Pass2Box.Password.ToString())
            {
                this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Hidden);
                TextBlockWarning.Text = "Passwords don't match";
                return;
            }
            if (Pass1Box.Password.ToString() == Pass2Box.Password.ToString())
            {
                Task change = new Task(Change);
                change.Start();
                {
                    change.ContinueWith((x) =>
                    {
                        if (change.IsCompleted)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                if (User != null)
                                {
                                    if (Num==1)
                                    {
                                    HeadWindow HeadWindow = new HeadWindow(User);
                                    HeadWindow.Show();
                                    Application.Current.MainWindow.Close();
                                    this.Close();
                                    }
                                    if (Num==2)
                                    {
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    TextBlockWarning.Text = "Connection  error.Check you internet connection";
                                    this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Hidden);
                                }
                            });
                        }
                    });
                }
            }
        }
        public void Change()
        {
            this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Visible);
            this.Dispatcher.InvokeAsync(() => this.Pass1Box.BorderBrush = Brushes.Gray);
            this.Dispatcher.InvokeAsync(() => this.Pass2Box.BorderBrush = Brushes.Gray);


            try
            {
                userService.UpdatePassword(User.Id, Pass1Box.Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (Num==1)
            {
                MainWindow MainWindow = new MainWindow();
                MainWindow.Show();
                this.Close();
            }
            else
            {
                this.Close();

            }

        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
