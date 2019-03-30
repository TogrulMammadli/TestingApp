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
using TestApplicationWPF.Services.ExamService;

namespace TestApplicationWPF.Pages
{
    /// <summary>
    /// Interaction logic for TestResult.xaml
    /// </summary>
    public partial class TestResult : Page
    {
        ExamService examService = new ExamService();
        public TestResult(Exams exams)
        {
            InitializeComponent();
            Result result = examService.CheckExam(exams);
            Correct.Text = result.CorrectsNumber.ToString();
            NotAnswer.Text = result.UnAnswered.ToString();
            Wrong.Text = result.WrongsNumber.ToString();
        }
    }
}
