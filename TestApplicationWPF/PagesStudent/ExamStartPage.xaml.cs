using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestApplicationWPF.Models;
using TestApplicationWPF.Pages;
using TestApplicationWPF.Services.ExamService;
using TestApplicationWPF.ViewModel.ExamSheduleVM;

namespace TestApplicationWPF.PagesStudent
{
    /// <summary>
    /// Interaction logic for ExamStartPage.xaml
    /// </summary>
    public partial class ExamStartPage : Page
    {
        ExamStartViewModel ViewModel;
        int index = 1;
        int questionNumber = 0;
        List<StudentAnwsers> studentAnwsers = new List<StudentAnwsers>();
        Result result = new Result();
        public ExamStartPage(Exams exams)
        {
            InitializeComponent();
            ViewModel = new ExamStartViewModel(new ExamService(), exams.Id);
            QuestionText.Text = ViewModel.Questions[0].Text;
            foreach (var correct in ViewModel.Questions[0].CorrectAnswers)
            {
                ViewModel.Answers.Add(correct);
            }
            foreach (var wrong in ViewModel.Questions[0].WrongAnswers)
            {
                ViewModel.Answers.Add(wrong);
            }
            ViewModel.Answers.OrderBy(a => Guid.NewGuid()).ToList();

            this.DataContext = ViewModel;
            foreach (var item in ViewModel.Questions)
            {
                studentAnwsers.Add(new StudentAnwsers() { Answers = new List<Ans>() { } });
            }

        }



        private void QuestionButton_Loaded(object sender, EventArgs e)
        {
            ((Button)sender).Content = index;
            ++index;
        }

        private void QuestionButton_Click(object sender, RoutedEventArgs e)
        {

            ViewModel.Answers.Clear();
            int a = Convert.ToInt32(((Button)(sender)).Content) - 1;
            QuestionText.Text = ViewModel.Questions[a].Text;

            foreach (var correct in ViewModel.Questions[a].CorrectAnswers)
            {
                ViewModel.Answers.Add(correct);
            }
            foreach (var wrong in ViewModel.Questions[a].WrongAnswers)
            {
                ViewModel.Answers.Add(wrong);
            }

         
            ObservableCollection<Answer> b = new ObservableCollection<Answer>();

            foreach (var item in ViewModel.Answers)
            {
                b.Add(item);
            }

            ViewModel.Answers.Clear();
            foreach (var item in b.OrderBy(j => Guid.NewGuid()).ToList())
            {
                ViewModel.Answers.Add(item);
            }
            questionNumber = a;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Exam.studentanswer = studentAnwsers;
            TestResult testResult = new TestResult(result,ViewModel.Exam);
            HeadWindow.ChangePage(testResult);
        }

        private void AnswerCheck_Checked(object sender, RoutedEventArgs e)
        {
            studentAnwsers.ElementAt(questionNumber).Answers.Add(new Ans() { An = ((CheckBox)(sender)).Content.ToString() });


        }

        private void AnswerCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox ck = sender as CheckBox;
            var a = studentAnwsers[questionNumber].Answers.Where(x => x.An == ck.Content).DefaultIfEmpty().Single();
            studentAnwsers[questionNumber].Answers.Remove(a);

        }

     

       
            

        private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Pressed)
            {
                ++result.CorrectsNumber;
            }
            if (e.ChangedButton == MouseButton.Right && e.ButtonState == MouseButtonState.Pressed)
            {
                ++result.WrongsNumber;
            }

        }
    }

}
