using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.Models;
using TestApplicationWPF.Services.ExamService;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.ExamSheduleVM
{
   public  class ExamChooseViewModel :BaseViewModel 
    {
     public   ExamService examService=new ExamService();
        public ObservableCollection<Exams> Exams { get; set; }
        public int number = 0;


        public ExamChooseViewModel(ExamService examService,User user)
        {
            this.examService = examService ?? throw new ArgumentNullException(nameof(examService));
            Exams = new ObservableCollection<Exams>(examService.GetUserExams(user));
        }
        private RelayCommand _like;

        public RelayCommand Like => _like ?? new RelayCommand(LikeExexute, LikeCanExecute);

        private bool LikeCanExecute()
        {
            return true;
        }

        private void LikeExexute()
        {
            try
            {
                ++number;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

    }
}
