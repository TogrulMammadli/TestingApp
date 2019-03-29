using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
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

        private RelayCommand<DateTime> _createExam;
        public RelayCommand<DateTime> CreateExam => _createExam ?? new RelayCommand<DateTime>(CreateExamExexute, CreateExamCanExecute);

        private bool CreateExamCanExecute(DateTime dateTime)
        {
            return true;
        }

        private void CreateExamExexute(DateTime dateTime)
        {
            try
            {
                foreach (var user in ExamingUsers)
                {
                    foreach (var test in ExamingTestBlanks)
                    {
                        TestContext.Instance.PassedTests.Add(new Exams()
                        {
                            BeginDate = dateTime,
                            User = user,
                            Blank = test,
                            
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("examCreated");
        }


        private RelayCommand<TestBlank> _removeTestBlank;
        public RelayCommand<TestBlank> RemoveTestBlank => _removeTestBlank ?? new RelayCommand<TestBlank>(RemoveTestBlankExexute, RemoveTestBlankCanExecute);

        private bool RemoveTestBlankCanExecute(TestBlank test)
        {
            return true;
        }

        private void RemoveTestBlankExexute(TestBlank test)
        {
            try
            {
                ExamingTestBlanks.Remove(test);
                TestBlanks.Add(test);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }


        private RelayCommand<User> _removeUser;
        public RelayCommand<User> RemoveUser => _removeUser ?? new RelayCommand<User>(RemoveUserExexute, RemoveUserCanExecute);

        private bool RemoveUserCanExecute(User user)
        {
            return true;
        }

        private void RemoveUserExexute(User user)
        {
            try
            {
                ExamingUsers.Remove(user);
                Users.Add(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
    }
}
