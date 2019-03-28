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
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Pages
{
    /// <summary>
    /// Interaction logic for ViewQuestionInfo.xaml
    /// </summary>
    public partial class ViewQuestionInfo : Window
    {
        public Question Question;
        ObservableCollection<CorrectAnswer> CorrectAnswers;
        ObservableCollection<WrongAnswer> WrongAnswers;

        public ViewQuestionInfo(Question question)
        {
            InitializeComponent();
            Question = question;
            CorrectAnswers = new ObservableCollection<CorrectAnswer>(question.CorrectAnswers);
            WrongAnswers = new ObservableCollection<WrongAnswer>(question.WrongAnswers);
            DataContext = this;
        }
    }
    
}
