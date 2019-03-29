using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Services.ExamService;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.ExamSheduleVM
{
   public  class ExamChooseViewModel :BaseViewModel 
    {
        ExamService examService;
        ObservableCollection<Exams> Exams { get; set; }
        public ExamChooseViewModel(ExamService examService,User user)
        {
            this.examService = examService ?? throw new ArgumentNullException(nameof(examService));
            Exams = new ObservableCollection<Exams>(examService.GetUserExams(user));
        }

    }
}
