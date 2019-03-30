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
        public ExamStartPage(Exams exams)
        {
            InitializeComponent();
            ViewModel = new ExamStartViewModel(new ExamService(),exams.Id);
            this.DataContext = ViewModel;

        }

     

        private void QuestionButton_Loaded(object sender, EventArgs e)
        {
            ((Button)sender).Content = index;
            ++index;
        }
    }
}
