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
using TestApplicationWPF.Services.AnswerService;
using TestApplicationWPF.Services.QuestionService;
using TestApplicationWPF.Services.TestServices;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.AddQuestion
{
    class AddTestViewModel : BaseViewModel
    {
        private IQuestionService questionService;
        private ITestService testService;
        private IWrongAnswerService wrongAnswerService;
        private ICorrectAnswerService correctAnswerService;

        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();
        public ObservableCollection<TestBlank> testBlanks { get; set; } = new ObservableCollection<TestBlank>();
        public ObservableCollection<WrongAnswer> wrongAnswers { get; set; } = new ObservableCollection<WrongAnswer>();
        public ObservableCollection<CorrectAnswer> correctAnswers { get; set; } = new ObservableCollection<CorrectAnswer>();
        public ObservableCollection<Answer> answers { get; set; } = new ObservableCollection<Answer>();

        public Question question { get; set; } = new Question();
        public TestBlank testBlank { get; set; } = new TestBlank();
        public WrongAnswer wrongAnswer { get; set; } = new WrongAnswer();
        public CorrectAnswer correctAnswer { get; set; } = new CorrectAnswer();

        private RelayCommand _addQuestion;
        private RelayCommand _addTestBlank;
        private RelayCommand _addWrongAnswer;
        private RelayCommand _addCorrectAnswer;

        public AddTestViewModel(IQuestionService questionService, ITestService testService, IWrongAnswerService wrongAnswerService, ICorrectAnswerService correctAnswerService)
        {
            this.questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
            this.testService = testService ?? throw new ArgumentNullException(nameof(testService));
            this.wrongAnswerService = wrongAnswerService ?? throw new ArgumentNullException(nameof(wrongAnswerService));
            this.correctAnswerService = correctAnswerService ?? throw new ArgumentNullException(nameof(correctAnswerService));

            Questions = new ObservableCollection<Question>(questionService.GetAllQuestions());//sdelaew takoyje dla ostolnix(test,answer)
            testBlanks = new ObservableCollection<TestBlank>(testService.GetAllTestBlanks());
            wrongAnswers = new ObservableCollection<WrongAnswer>(wrongAnswerService.GetAllAnswers());
            correctAnswers = new ObservableCollection<CorrectAnswer>(correctAnswerService.GetAllAnswers());

            foreach(var item in correctAnswerService.GetAllAnswers())
            {
                answers.Add(item);
            }

            foreach(var item in wrongAnswerService.GetAllAnswers())
            {
                answers.Add(item);
            }
        }


        public RelayCommand AddQuestion => _addQuestion ?? new RelayCommand(AddQuestionExecute, AddQuestionCanExecute);

        public RelayCommand AddTestBlank => _addTestBlank ?? new RelayCommand(AddTestBlankExecute, AddTestBlankCanExecute);

        public RelayCommand AddWrongAnswer => _addTestBlank ?? new RelayCommand(AddWrongAnswerExecute, AddWrongAnswerCanExecute);

        public RelayCommand AddCorrectAnswer => _addTestBlank ?? new RelayCommand(AddCorrectAnswerExecute, AddCorrectAnswerCanExecute);

        private bool AddWrongAnswerCanExecute()
        {
            return this.wrongAnswer.Text.Length > 5;
        }

        private void AddWrongAnswerExecute()
        {
            try
            {
                wrongAnswerService.AddWrongAnswer(wrongAnswer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void AddCorrectAnswerExecute()
        {
            try
            {
                correctAnswerService.AddCorrectAnswer(correctAnswer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private bool AddCorrectAnswerCanExecute()
        {
            return this.correctAnswer.Text.Length > 5;
        }

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
