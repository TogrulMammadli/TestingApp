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
        UserService userService = new UserService(new UserRepository());
        public HeadWindow(User user)
        {
            InitializeComponent();
            User=user;
            //frame.NavigationService.Navigate(new PageCreateTest());
         
            //AvatarImage.Source = new BitmapImage(new Uri(userService.GetAvatarImageFromDb(user.Id)));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new PageCreateTest();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void HeadWndButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
