using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.Mesages;
using TestApplicationWPF.Models;
using TestApplicationWPF.Services.QuestionService;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel
{
    public class QuestionManagementViewModel : BaseViewModel
    {
        IQuestionService questionService;
        public ObservableCollection<Question> Questions{get;set;}

        public QuestionManagementViewModel(IQuestionService questionService)
        {
            this.questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
            Messenger.Default.Register<NewQuestionMessages>(this, AddQuestionsExexute);
            Questions = new ObservableCollection<Question>(questionService.GetAllQuestions());
        }

        private void AddQuestionsExexute(NewQuestionMessages message)
        {
            this.Questions.Add(message.NewQuestion);
        }

        private RelayCommand<Question> _removeUser;
        public RelayCommand<Question> RemoveUser => _removeUser ?? new RelayCommand<Question>(RemoveUserExexute, RemoveCanExecute);

        private bool RemoveCanExecute(Question user)
        {
            return true;
        }

        private void RemoveUserExexute(Question question)
        {
            try
            {
                questionService.RemoveQuestion(question);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Questions.Remove(question);
        }

    }
}
