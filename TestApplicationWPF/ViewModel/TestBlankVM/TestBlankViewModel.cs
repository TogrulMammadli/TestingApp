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
using TestApplicationWPF.Repository.SubjectRepository;
using TestApplicationWPF.Services.QuestionService;
using TestApplicationWPF.Services.TestServices;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.TestBlankVM
{
   public class TestBlankViewModel:BaseViewModel
    {
        private ITestService Testservice;
        private IQuestionService Questionservice;

        public ObservableCollection<Question> AllQuestions { get; set; }
        public TestBlank TestBlank { get; set; }=new TestBlank();
        public ObservableCollection<Question> TestBlankQuestion { get; set; } = new ObservableCollection<Question>();

        public Question Question { get; set; } = new Question();
        public ObservableCollection<CorrectAnswer> CorrectAnswers { get; set; } = new ObservableCollection<CorrectAnswer>();
        public ObservableCollection<WrongAnswer> WrongAnswers { get; set; } = new ObservableCollection<WrongAnswer>();
        public ObservableCollection<Subject> Subjects { get; set; }

        public TestBlankViewModel(ITestService Testblankservice,IQuestionService questionService)
        {
            this.Questionservice = questionService ?? throw new ArgumentNullException(nameof(Questionservice));
            this.Testservice = Testblankservice ?? throw new ArgumentNullException(nameof(Testservice));
            this.AllQuestions =new ObservableCollection<Question>(questionService.GetAllQuestions());
            this.Subjects = new ObservableCollection<Subject>(TestContext.Instance.Subjects.ToList());
        }

        private RelayCommand<Question> _addQuestionToTestBlank;
        public RelayCommand<Question> AddQuestionToTestBlank => _addQuestionToTestBlank ?? new RelayCommand<Question>(AddQuestionToTestBlankExexute, AddQuestionToTestBlankCanExecute);

        private bool AddQuestionToTestBlankCanExecute(Question question)
        {
            return true;
        }

        private void AddQuestionToTestBlankExexute(Question question)
        {
            try
            {
                TestBlankQuestion.Add(question);
                AllQuestions.Remove(question);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private RelayCommand<Question> _removeQuestionFromTestBlank;
        public RelayCommand<Question> RemoveQuestionFromTestBlank => _removeQuestionFromTestBlank ?? new RelayCommand<Question>(RemoveQuestionFromTestBlankExexute, RemoveQuestionFromTestBlankCanExecute);

        private bool RemoveQuestionFromTestBlankCanExecute(Question question)
        {
            return true;
        }

        private void RemoveQuestionFromTestBlankExexute(Question question)
        {
            try
            {
                TestBlankQuestion.Remove(question);
                AllQuestions.Add(question);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
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
                Question.CorrectAnswers = CorrectAnswers;
                Question.WrongAnswers = WrongAnswers;
                Questionservice.AddQuestion(Question);
                AllQuestions.Add(Question);
                TestBlankQuestion.Add(Question);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private RelayCommand _addImage;
        public RelayCommand AddImage => _addImage ?? new RelayCommand(AddImageExecute, AddImageCanExecute);

        private bool AddImageCanExecute()
        {
            return true;
        }

        private void AddImageExecute()
        {
            string path = Questionservice.OpenFileGetPath();
            if (path != "Error")
            {
                try
                {
                    Task.Factory.StartNew(() => { Question.Image = Questionservice.ConvertImageToByte(path); });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

        }

        private RelayCommand<Complexity> _complexityCheck;
        public RelayCommand<Complexity> ComplexityCheck => _complexityCheck ?? new RelayCommand<Complexity>(CheckComplexity, CheckComplexityCanExecute);

        private bool CheckComplexityCanExecute(Complexity complexity)
        {
            return true;
        }

        private void CheckComplexity(Complexity complexity)
        {
            Question.Complexity = complexity;

        }

        private RelayCommand<string> _addCorrectAnswer;
        public RelayCommand<string> AddCorrectAnswer => _addCorrectAnswer ?? new RelayCommand<string>(AddCorrectAnswerExecute, AddCorrectAnswerCanExecute);

        private bool AddCorrectAnswerCanExecute(string text)
        {
            return true;
        }

        private void AddCorrectAnswerExecute(string text)
        {
            CorrectAnswer answer = new CorrectAnswer() { Text = text };
            CorrectAnswers.Add(answer);
        }

        private RelayCommand<string> _addWrongAnswer;
        public RelayCommand<string> AddWrongAnswer => _addWrongAnswer ?? new RelayCommand<string>(AddWrongAnswerExecute, AddWrongAnswerCanExecute);

        private bool AddWrongAnswerCanExecute(string text)
        {
            return true;
        }

        private void AddWrongAnswerExecute(string text)
        {
            WrongAnswer answer = new WrongAnswer() { Text = text };
            WrongAnswers.Add(answer);
        }
        private RelayCommand<string> _addSubject;
        public RelayCommand<string> AddSubject => _addSubject ?? new RelayCommand<string>(AddSubjectExecute, AddSubjectCanExecute);

        private bool AddSubjectCanExecute(string sub)
        {
            return sub.Length > 0;
        }

        private void AddSubjectExecute(string sub)
        {
            Subject subject = new Subject() { Name = sub };
            SubjectRepository SUBRepos = new SubjectRepository();
            try
            {
                SUBRepos.AddSubject(subject);
            }
            catch (Exception)
            {
                MessageBox.Show("Error of subjectAdd");
                return;
            }
            Subjects.Add(subject);
        }

        private RelayCommand<string> _chooseSubject;
        public RelayCommand<string> ChooseSubject => _chooseSubject ?? new RelayCommand<string>(ChooseSubjectExecute, ChooseSubjectCanExecute);

        private bool ChooseSubjectCanExecute(string sub)
        {
            return sub.Length > 0;
        }

        private void ChooseSubjectExecute(string sub)
        {
            SubjectRepository SUBRepos = new SubjectRepository();
            try
            {
                Question.subject = SUBRepos.GetSubjectByName(sub);
            }
            catch (Exception)
            {
                MessageBox.Show("Error of subjectAdd");
                return;
            }

        }


        private RelayCommand _addTestBlank;
        public RelayCommand AddTestBlank => _addTestBlank ?? new RelayCommand(AddTestBlankExecute, AddTestBlankCanExecute);

        private bool AddTestBlankCanExecute()
        {
            return true;
        }

        private void AddTestBlankExecute()
        {
         
            TestBlank.Questions = TestBlankQuestion;

            try
            {
                Testservice.CreateTestBlank(TestBlank);
            }
            catch (Exception)
            {
                MessageBox.Show("Error of subjectAdd");
                return;
            }
        }


    }
}
