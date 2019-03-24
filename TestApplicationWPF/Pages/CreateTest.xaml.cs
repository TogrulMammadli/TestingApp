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
using TestApplicationWPF.Repository.TestBlanksRepository;
using TestApplicationWPF.Services.TestServices;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for PageCreateTest.xaml
    /// </summary>
    public partial class PageCreateTest : Page
    {
        public TestService testService = new TestService(new TestBlankRepository());
        public List<Question> questions = new List<Question>();
        public PageCreateTest()
        {
            InitializeComponent();
            TypeComboBox.Items.Add("Один ответ");
            TypeComboBox.Items.Add("Несколько ответов");
            TypeComboBox.SelectedIndex = 0;
            AllQuestionsRadioButton.IsChecked = true;
            MediumRadioButton.IsChecked = true;
            UnlimitedTimeRadioButton.IsChecked = true;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
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

            if(Emptys.Count != 0)
            {
                for(int i = 0;i<Emptys.Count;i++)
                {
                    MessageBox.Show("У вас не описано следующее поле:" + Emptys[i], "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                if(UnlimitedTimeRadioButton.IsChecked == true)
                {
                   // testService.TestBlankRepository.AddTestBlank(new Models.TestBlank() {Name = NameTextBox.Text,About = AboutTextBox.Text,Autor = AuthorTextBox.Text,DurationMin = null, })
                }
                //testService.CreateTest(NameTextBox.Text,AboutTextBox.Text,AuthorTextBox.Text,new TimeSpan())
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
                QuestionListBox.Items.Add(QuestionAddTextBox.Text);
                QuestionAddTextBox.Text = "";
                AnswersListBox.Items.Clear();
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
    }
}
