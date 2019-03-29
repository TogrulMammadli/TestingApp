using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.Models;
using TestApplicationWPF.Services.TestServices;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.ExamSheduleVM
{
    public class ExamSheduleViewModel : BaseViewModel
    {
        private IUserService userService;
        private ITestService testBlankService;

        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<TestBlank> TestBlanks { get; set; }
        public ObservableCollection<User> ExamingUsers { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<TestBlank> ExamingTestBlanks { get; set; } = new ObservableCollection<TestBlank>();

        public ExamSheduleViewModel(IUserService userService, ITestService testBlankService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.testBlankService = testBlankService ?? throw new ArgumentNullException(nameof(testBlankService));
            Users = new ObservableCollection<User>(userService.GetAllStudents());
            TestBlanks = new ObservableCollection<TestBlank>(testBlankService.GetAllOriginalBlanks());
        }

        private RelayCommand<User> _AddUserToUserExam;
        public RelayCommand<User> AddUserToExamUser => _AddUserToUserExam ?? new RelayCommand<User>(AddUserToExamUserExexute, AddUserToExamCanExecute);

        private bool AddUserToExamCanExecute(User user)
        {
            return true;
        }

        private void AddUserToExamUserExexute(User user)
        {
            try
            {
                Users.Remove(user);
                ExamingUsers.Add(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private RelayCommand<TestBlank> _addTestBlankToExam;
        public RelayCommand<TestBlank> AddTestBlankToExam => _addTestBlankToExam ?? new RelayCommand<TestBlank>(AddTestBlanToExamExexute, AddTestBlankToExamCanExecute);

        private bool AddTestBlankToExamCanExecute(TestBlank blank)
        {
            return true;
        }

        private void AddTestBlanToExamExexute(TestBlank blank)
        {
            try
            {
                TestBlanks.Remove(blank);
                ExamingTestBlanks.Add(blank);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }



    }
}
