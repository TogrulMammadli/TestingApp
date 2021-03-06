﻿using System;
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
using System.Text.RegularExpressions;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.AccessLevelRepository;
using TestApplicationWPF.ViewModel.AddUser;
using TestApplicationWPF.Mesages;
using GalaSoft.MvvmLight.Messaging;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserViewModel ViewModel;
        public AddUserWindow()
        {
            InitializeComponent();
            ViewModel = new AddUserViewModel(new UserService(new UserRepository()));
            this.DataContext = ViewModel;
            Male.IsChecked = true;
            dataPicker.SelectedDate = DateTime.Now.Date;
            Messenger.Default.Register<WindowMessages>(this, "AddUser", WindwowMessagesAction);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

      
        private void WindwowMessagesAction(WindowMessages obj)
        {
            if (obj.MessageText.ToLower() == "close")
            {
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FemaleCheck(object sender, RoutedEventArgs e)
        {
           ViewModel.GenderCheck.Execute(Gender.Female);
        }

        private void MaleCheck(object sender, RoutedEventArgs e)
        {
            ViewModel.GenderCheck.Execute(Gender.Male);

        }

        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.AddDate.Execute(((DateTime)dataPicker.SelectedDate));
        }

        private void NumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.AddPhone.Execute(NumberTextBox.Text);
        }

        private void ImageBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
