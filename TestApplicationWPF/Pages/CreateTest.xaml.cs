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
using TestApplicationWPF.Pages;
using TestApplicationWPF.Repository.AnswerRepository;
using TestApplicationWPF.Repository.QuestionsRepository;
using TestApplicationWPF.Repository.TestBlanksRepository;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.AnswerService;
using TestApplicationWPF.Services.QuestionService;
using TestApplicationWPF.Services.TestServices;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.ViewModel.AddQuestion;
using TestApplicationWPF.ViewModel.TestBlankVM;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for PageCreateTest.xaml
    /// </summary>
    public partial class PageCreateTest : Page
    {
        TestBlankViewModel testBlankViewModel;
        TestBlank TestBlk = new TestBlank();
        public PageCreateTest()
        {
            InitializeComponent();
            AllQuestionsRadioButton.IsChecked = true;
            MediumRadioButton.IsChecked = true;
            UnlimitedTimeRadioButton.IsChecked = true;

            testBlankViewModel = new TestBlankViewModel(new TestService(new TestBlankRepository()), new QuestionService(new QuestionRepository()));
            this.DataContext = testBlankViewModel;
        }

    
        private void TestBlankQuestioRemove_Click(object sender, RoutedEventArgs e)
        {
            testBlankViewModel.RemoveQuestionFromTestBlank.Execute((Question)(((Button)sender).DataContext));
        }

        private void TestBlankQuestioView_Click(object sender, RoutedEventArgs e)
        {
            ViewQuestionInfo viewQuestionInfo = new ViewQuestionInfo((Question)(((Button)sender).DataContext));
            viewQuestionInfo.ShowDialog();
        }
      
        private void Low_Checked(object sender, RoutedEventArgs e)
        {
            testBlankViewModel.ComplexityCheck.Execute(Complexity.Low);
        }

        private void Normal_Checked(object sender, RoutedEventArgs e)
        {
            testBlankViewModel.ComplexityCheck.Execute(Complexity.Medium);

        }

        private void Hight_Checked(object sender, RoutedEventArgs e)
        {
            testBlankViewModel.ComplexityCheck.Execute(Complexity.Hight);
        }

        private void SubjectsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            testBlankViewModel.ChooseSubject.Execute(SubjectsBox.SelectedItem.ToString());
        }

        private void MinutesForExamTimeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
             e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void AllQuestioView_Click(object sender, RoutedEventArgs e)
        {
            ViewQuestionInfo viewQuestionInfo = new ViewQuestionInfo((Question)(((Button)sender).DataContext));
            viewQuestionInfo.ShowDialog();
        }

        private void AllQuestioAdd_Click(object sender, RoutedEventArgs e)
        {
            testBlankViewModel.AddQuestionToTestBlank.Execute((Question)(((Button)sender).DataContext));
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            TestBlk.About = TestBlk.About;
            TestBlk.Name = TestBlk.Name;
            TestBlk.DurationMin = TestBlk.DurationMin;
            TestBlk.Autor = TestBlk.Autor;
            testBlankViewModel.AddTestBlank.Execute(true);
            MessageBox.Show("Natig sdelay cto nibud pole najatiya cnopki ctobi bilo ponatno sozdalsa ili net" ,"Congratulations",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TestBlk.Name= NameTextBox.Text;
        }

        private void AboutTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TestBlk.About = AboutTextBox.Text;
        }

        private void AuthorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

            TestBlk.Autor = AuthorTextBox.Text;

        }

        private void MinutesForExamTimeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TestBlk.DurationMin = new TimeSpan(0, Convert.ToInt32(MinutesForExamTimeTextBox.Text), 0);

        }
    }
}
