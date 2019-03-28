using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Mesages;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.QuestionsRepository;
using TestApplicationWPF.Repository.SubjectRepository;
using TestApplicationWPF.Services.AnswerService;
using TestApplicationWPF.Services.QuestionService;
using TestApplicationWPF.Services.SubjectService;
using TestApplicationWPF.Services.TestServices;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.AddQuestion
{
    public class AddQuestionViewModel : BaseViewModel
    {
        private IQuestionService service;
      
        public Question Question { get; set; } = new Question();
        public ObservableCollection<CorrectAnswer> CorrectAnswers { get; set; }= new ObservableCollection<CorrectAnswer>();
        public ObservableCollection<WrongAnswer> WrongAnswers { get; set; } = new ObservableCollection<WrongAnswer>();
        public ObservableCollection<Subject> Subjects { get; set; } 

        public AddQuestionViewModel(IQuestionService Service)
        {
            this.service = Service ?? throw new ArgumentNullException(nameof(service));

            Subjects = new ObservableCollection<Subject>(TestContext.Instance.Subjects.ToList());

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

        private RelayCommand _addImage;
        public RelayCommand AddImage => _addImage ?? new RelayCommand(AddImageExecute, AddImageCanExecute);

        private bool AddImageCanExecute()
        {
            return true;
        }

        private void AddImageExecute()
        {
            string path = service.OpenFileGetPath();
            if (path != "Error")
            {
                try
                {
                    Task.Factory.StartNew(() => { Question.Image = service.ConvertImageToByte(path); });
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
            CorrectAnswer answer = new CorrectAnswer() { Text=text};
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
            return sub.Length>0;
        }

        private void AddSubjectExecute(string sub)
        {
            Subject subject = new Subject() { Name=sub};
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
               Question.subject= SUBRepos.GetSubjectByName(sub);
            }
            catch (Exception)
            {
                MessageBox.Show("Error of subjectAdd");
                return;
            }

        }

    }
}
