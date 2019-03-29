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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.TestBlanksRepository;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.TestServices;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.ViewModel.ExamSheduleVM;

namespace TestApplicationWPF.Pages
{
    /// <summary>
    /// Interaction logic for ExamShedule.xaml
    /// </summary>
    public partial class ExamShedule : Page
    {
        ExamSheduleViewModel ViewModel;

        public ExamShedule()
        {
            InitializeComponent();
            ViewModel = new ExamSheduleViewModel(new UserService(new UserRepository()),new TestService(new TestBlankRepository()));
            this.DataContext = ViewModel;
           
        }

        private void AddStudentToExam_Click(object sender, RoutedEventArgs e)
        {
            
            ViewModel.AddUserToExamUser.Execute((User)(((Button)sender).DataContext));
        }


        private void Date_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Month_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Year_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));

        }

        private void Hour_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Minute_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void AddBttn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChooseTestBlank_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddTestBlankToExam.Execute((TestBlank)(((Button)sender).DataContext));
        }
    }
}
