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
using TestApplicationWPF.Repository.QuestionsRepository;
using TestApplicationWPF.Services.QuestionService;
using TestApplicationWPF.ViewModel;

namespace TestApplicationWPF.Pages
{
    /// <summary>
    /// Interaction logic for QuestionManagement.xaml
    /// </summary>
    public partial class QuestionManagement : Page
    {
     public   QuestionManagementViewModel viewModel;
        public QuestionManagement()
        {
            InitializeComponent();
            viewModel = new QuestionManagementViewModel(new QuestionService(new QuestionRepository()));
            this.DataContext = viewModel;
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            QuestionsListBox.SelectedItem = border.DataContext;
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.QuestionsListBox != null)
            {
                this.QuestionsListBox.Items.Filter = new Predicate<object>((x) =>
                {
                    var temp = x as Question;
                    string fullname =temp.Text;
                    string searchText = this.SearchTxtBox.Text.ToUpper().Replace(" ", "");
                    return fullname.Contains(searchText);
                });
            }
        }

       

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("EditPage");
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            ViewQuestionInfo viewQuestionInfo = new ViewQuestionInfo(((Question)QuestionsListBox.SelectedItems[0]));
            viewQuestionInfo.Show();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveUser.Execute(((Question)QuestionsListBox.SelectedItems[0]));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewQuestion addNewQuestion = new AddNewQuestion();
            addNewQuestion.Show();

        }
    }
}
