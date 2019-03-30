using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;
using TestApplicationWPF.Services.ExamService;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.ExamSheduleVM
{
    public class ExamStartViewModel : BaseViewModel
    {
        private ExamService examService;
        public Exams Exam { get; set; } = new Exams();
        public ObservableCollection<Question> Questions { get; set; }
        public int Index { get; set; } = 0;
        public ExamStartViewModel(ExamService examService,int ExId)
        {
            this.examService = examService ?? throw new ArgumentNullException(nameof(examService));
            Exam = TestContext.Instance.PassedTests.Include("Blank.Questions").Where(e => e.Id == ExId).DefaultIfEmpty().Single() ;
            Questions = new ObservableCollection<Question>(Exam.Blank.Questions);
        }

        
      
    }
}
