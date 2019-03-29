using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
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
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.QuestionsRepository;
using TestApplicationWPF.Services.QuestionService;

namespace TestApplicationWPF.Pages
{
    /// <summary>
    /// Interaction logic for ViewQuestionInfo.xaml
    /// </summary>
    public partial class ViewQuestionInfo : Window
    {
        public Question Question { get; set; }
        ObservableCollection<CorrectAnswer> CorrectAnswers { get; set; }
        ObservableCollection<WrongAnswer> WrongAnswers { get; set; }
        string Imagepath;
        QuestionService service = new QuestionService(new QuestionRepository()); 
        public ViewQuestionInfo(Question question)
        {
            InitializeComponent();
            Question = question;
            CorrectAnswers = new ObservableCollection<CorrectAnswer>(question.CorrectAnswers);
            WrongAnswers = new ObservableCollection<WrongAnswer>(question.WrongAnswers);
            DataContext = this;
            if (Question.Image != null)
            {
                Task task = new Task(CC);
                task.Start();
                {
                    task.ContinueWith((x) =>
                    {
                        if (task.IsCompleted)
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                               // this.Dispatcher.InvokeAsync(() => this.ImageBox.Source = new BitmapImage(new Uri(Imagepath)));
                            });
                        }
                    });
                }
            }
        }
        public void CC()
        {
            Imagepath = service.GetAvatarImageFromDb(Question.Id);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
