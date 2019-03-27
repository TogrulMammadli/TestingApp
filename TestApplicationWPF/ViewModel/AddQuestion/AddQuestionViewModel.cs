using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.Models;
using TestApplicationWPF.Services.Answers;
using TestApplicationWPF.Services.QuestionService;
using TestApplicationWPF.Services.TestServices;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.AddQuestion
{
     class AddTestViewModel : BaseViewModel
    {
        private IQuestionService questionService;
        private ITestService testService;
        private ICorrectAnswerService answerService;

        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>() ;
        public ObservableCollection<TestBlank> testBlanks { get; set; } = new ObservableCollection<TestBlank>();
        public ObservableCollection<WrongAnswer> wrongAnswers { get; set; } = new ObservableCollection<WrongAnswer>();
        public ObservableCollection<CorrectAnswer> correctAnswers { get; set; } = new ObservableCollection<CorrectAnswer>();

        public Question question { get; set; } = new Question();
        public TestBlank testBlank { get; set; } = new TestBlank();
        public WrongAnswer wrongAnswer { get; set; } = new WrongAnswer();
        public CorrectAnswer correctAnswer { get; set; } = new CorrectAnswer();

        private RelayCommand _addQuestion;
        private RelayCommand _addTestBlank;
        private RelayCommand _addWrongAnswer;
        private RelayCommand _addCorrectAnswer;

        public AddTestViewModel(IQuestionService questionService,ITestService testService,ICorrectAnswerService answerService)
        {
            this.questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
            this.testService = testService ?? throw new ArgumentNullException(nameof(testService));
            this.answerService = answerService ?? throw new ArgumentNullException(nameof(answerService));

            Questions = new ObservableCollection<Question>(questionService.GetAllQuestions());//sdelaew takoyje dla ostolnix(test,answer)
            testBlanks = new ObservableCollection<TestBlank>(testService.GetAllTestBlanks());
            wrongAnswers = new ObservableCollection<WrongAnswer>(answerService.)
        }


        public RelayCommand AddQuestion => _addQuestion ?? new RelayCommand(AddQuestionExecute, AddQuestionCanExecute);

        public RelayCommand AddTestBlank => _addTestBlank ?? new RelayCommand(AddTestBlankExecute, AddTestBlankCanExecute);


        private bool AddTestBlankCanExecute()
        {
            return this.testBlank.Name?.Count() > 5;
        }

        private void AddTestBlankExecute()
        {
            try
            {
                testService.CreateTestBlank(testBlank);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private bool AddQuestionCanExecute()
        {
            return this.question.Text?.Count() > 5;
        }

        private void AddQuestionExecute()
        {
            try
            {
                questionService.AddQuestion(question);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

    }
}
