using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
