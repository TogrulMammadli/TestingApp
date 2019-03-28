using System;
using System.Collections.Generic;
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
using TestApplicationWPF.Repository.AnswerRepository;
using TestApplicationWPF.Repository.QuestionsRepository;
using TestApplicationWPF.Repository.TestBlanksRepository;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.AnswerService;
using TestApplicationWPF.Services.QuestionService;
using TestApplicationWPF.Services.TestServices;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.ViewModel.AddQuestion;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for PageCreateTest.xaml
    /// </summary>
    public partial class PageCreateTest : Page
    {
        public TestService testService = new TestService(new TestBlankRepository());
        public QuestionService questionService = new QuestionService(new QuestionRepository());
        public List<Question> questions = new List<Question>();
     static   Subject Subject = new Subject();
        Question question = new Question();
        public PageCreateTest()
        {
            InitializeComponent();
          //  var viewM = new AddTestViewModel(new QuestionService(new QuestionRepository()), new TestService(new TestBlankRepository()), new WrongAnswerService(new WrongAnswerRepository()), new CorrectAnswerService(new CorrectAnswerRepository()));
           // DataContext = viewM;
            TypeComboBox.Items.Add("Один ответ");
            TypeComboBox.Items.Add("Несколько ответов");
            TypeComboBox.SelectedIndex = 0;
            AllQuestionsRadioButton.IsChecked = true;
            MediumRadioButton.IsChecked = true;
            UnlimitedTimeRadioButton.IsChecked = true;

          
        }
       public  static void GetSubject(Subject subject)
        {
            Subject = subject;

        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Subject.Name);
            List<string> Emptys = new List<string>();
            if(String.IsNullOrEmpty(NameTextBox.Text) == true || String.IsNullOrWhiteSpace(NameTextBox.Text) == true)
            {
                Emptys.Add("имя теста");
            }
            if(String.IsNullOrEmpty(AboutTextBox.Text) == true || String.IsNullOrWhiteSpace(AboutTextBox.Text) == true)
            {
                Emptys.Add("описание теста");
            }
            if (String.IsNullOrEmpty(AuthorTextBox.Text) == true || String.IsNullOrWhiteSpace(AuthorTextBox.Text) == true)
            {
                Emptys.Add("имя автора");
            }

            if (Emptys.Count != 0)
            {
                for (int i = 0; i < Emptys.Count; i++)
                {
                    MessageBox.Show("У вас не описано следующее поле:" + Emptys[i], "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                if (UnlimitedTimeRadioButton.IsChecked == true)
                {
                    TestBlank testBlank = new TestBlank();
                    testBlank.About = AboutTextBox.Text;
                    testBlank.Autor = AuthorTextBox.Text;
                    testBlank.Id = -1;
                    testBlank.Name = NameTextBox.Text;
                    testService.CreateTestBlank(testBlank);

                }
                else
                {
                    int temp = Int32.Parse(MinutesForExamTimeTextBox.Text);
                    if (temp > 0 && temp <= 1440)
                    {
                        TestBlank testBlank = new TestBlank();
                        testBlank.About = AboutTextBox.Text;
                        testBlank.Autor = AuthorTextBox.Text;
                        testBlank.Id = -1;
                        testBlank.DurationMin = new TimeSpan(0, temp, 0);
                        testBlank.Name = NameTextBox.Text;
                        //testBlank.Questions = 
                        testService.CreateTestBlank(testBlank);
                    }
                    else
                    {
                        MessageBox.Show("Или много или мало времени","Information",MessageBoxButton.OK,MessageBoxImage.Information);
                    }
                }
            }
        }

        private void AddAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(QuestionAddTextBox.Text) == true || String.IsNullOrWhiteSpace(QuestionAddTextBox.Text) == true)
            {
                MessageBox.Show("Вы не описали свой вопрос!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (String.IsNullOrEmpty(AnswerAddTextBox.Text) == true || String.IsNullOrWhiteSpace(AnswerAddTextBox.Text) == true)
            {
                MessageBox.Show("Вы не описали свой ответ!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (AnswersListBox.Items.Count >= 6)
            {
                MessageBox.Show("У вас слишком много ответов!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                AnswersListBox.Items.Add(AnswerAddTextBox.Text);
            }
        }

        private void DeleteAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            AnswersListBox.Items.Remove(AnswersListBox.SelectedItem);
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnswersListBox.Items.Count >= 2 && AnswersListBox.Items.Count <= 6)
            {
                question.Id = -1;
                //question.subject
                //questions.Add();
                QuestionListBox.Items.Add(QuestionAddTextBox.Text);
                
                QuestionAddTextBox.Text = "";
                AnswersListBox.Items.Clear();
                question = new Question();
            }
            else
            {
                MessageBox.Show("У вас слишком мало ответов!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            QuestionListBox.Items.Remove(QuestionListBox.SelectedItem);
        }

        private void MinutesForExamTimeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = questionService.OpenFileGetPath();
                if (path != "Error")
                {
                    Task.Factory.StartNew(() => { question.Image = questionService.ConvertImageToByte(path); });
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void CountOfRandomQuestionsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

     

       
    }
}
