using GalaSoft.MvvmLight.Messaging;
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
using System.Windows.Shapes;
using TestApplicationWPF.Mesages;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.QuestionsRepository;
using TestApplicationWPF.Services.QuestionService;
using TestApplicationWPF.ViewModel.AddQuestion;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for AddNewQuestion.xaml
    /// </summary>
    public partial class AddNewQuestion : Window
    {
        AddQuestionViewModel ViewModel;

        public AddNewQuestion()
        {
            InitializeComponent();
            ViewModel = new AddQuestionViewModel(new QuestionService(new QuestionRepository()));
            DataContext = ViewModel;
            Messenger.Default.Register<WindowMessages>(this, "AddQuestion", WindwowMessagesAction);

            try
            {
                SubjectsBox.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        private void WindwowMessagesAction(WindowMessages obj)
        {
            if (obj.MessageText.ToLower() == "close")
            {
                this.Close();
            }
        }
        private void Low_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.ComplexityCheck.Execute(Complexity.Low);
        }

        private void Normal_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.ComplexityCheck.Execute(Complexity.Medium);

        }

        private void Hight_Checked(object sender, RoutedEventArgs e)
        {
            ViewModel.ComplexityCheck.Execute(Complexity.Hight);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SubjectsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.ChooseSubject.Execute(SubjectsBox.SelectedItem.ToString());
        }
    }
}
