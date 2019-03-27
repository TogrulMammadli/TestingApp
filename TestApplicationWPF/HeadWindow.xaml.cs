﻿using System;
using System.Collections.Generic;
using System.IO;
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
using TestApplicationWPF.Pages;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.UserServices;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for HeadWindow.xaml
    /// </summary>
    public partial class HeadWindow : Window
    {
        User User = new User();
        string Imagepath = "";
        UserService userService = new UserService(new UserRepository());
        public HeadWindow(User user)
        {
            InitializeComponent();
            User=user;
            //frame.NavigationService.Navigate(new PageCreateTest());
            if (user.İmage!=null)
            {
                Task task = new Task(CC);
                task.Start();
                {
                    task.ContinueWith((x) =>
                    {
                        if (task.IsCompleted)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                this.Dispatcher.InvokeAsync(() => this.AvatarImage.Source = new BitmapImage(new Uri(Imagepath)));
                            });
                        }
                    });
                }
            }
            UserNameSurnameTextBox.Text = user.Name + "  " + user.Surname;
            UserEmailTextBox.Text = user.Email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new PageCreateTest();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frame.Content = new ChooseTestBlankPage();

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void HeadWndButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frame.Content = new SettingPage();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            frame.Content = new UserManagement(User);
        }

        public void CC()
        {
            Imagepath = userService.GetAvatarImageFromDb(User.Id);
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            BurgerMenu.Visibility = Visibility.Hidden;
            HamburgerMenuGrid.Width = 0;

            UserinfoStackpanel.Visibility = Visibility.Visible;
            

        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            BurgerMenu.Visibility = Visibility.Visible;
            HamburgerMenuGrid.Width = 30;
            UserinfoStackpanel.Visibility = Visibility.Hidden;
        }

        public bool IsFullscreen = false;
        public WindowState lastWindowState;
        private void HeadWndButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (IsFullscreen)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Normal;
                IsFullscreen = false;

            }
            else 
            {
                this.WindowState = WindowState.Maximized;
                IsFullscreen = true;
                WindowStyle = WindowStyle.None;
            }
        }

        private void HeadWndButtonDropdown_Click(object sender, RoutedEventArgs e)
        {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Minimized;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            frame.Content = new TestResult();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            frame.Content = new StatisticaPage();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            frame.Content = new StatisticaPage();
        }
    }
}
