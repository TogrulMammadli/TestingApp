using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ExamSheduleViewModel(IUserService userService, ITestService testBlankService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.testBlankService = testBlankService ?? throw new ArgumentNullException(nameof(testBlankService));
            Users = new ObservableCollection<User>(userService.GetAllStudents());
            TestBlanks = new ObservableCollection<TestBlank>(testBlankService.GetAllOriginalBlanks());
        }



    }
}
