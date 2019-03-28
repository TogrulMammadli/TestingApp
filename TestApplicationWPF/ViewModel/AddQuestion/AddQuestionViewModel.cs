using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TestApplicationWPF.Mesages;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.QuestionsRepository;
using TestApplicationWPF.Services.AnswerService;
using TestApplicationWPF.Services.QuestionService;
using TestApplicationWPF.Services.TestServices;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.AddQuestion
{
    public class AddQuestionViewModel : BaseViewModel
    {
        private IQuestionRepository repository;
        private IQuestionService service;

        public Question Question { get; set; } = new Question();


        public AddQuestionViewModel(IQuestionService Service)
        {
            this.service = Service ?? throw new ArgumentNullException(nameof(service));
        }
        private RelayCommand _addQuestion;
        public RelayCommand AddQuestion => _addQuestion ?? new RelayCommand(AddQuestionExexute, AddQuestionCanExecute);

        private bool AddQuestionCanExecute()
        {
            return Question.Text?.Count() > 0;
        }

        private void AddQuestionExexute()
        {
            try
            {
                service.AddQuestion(Question);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Messenger.Default.Send(new NewQuestionMessages(Question));
            Messenger.Default.Send<WindowMessages>(new WindowMessages("close"), "AddQuestion");
        }


    }
}
