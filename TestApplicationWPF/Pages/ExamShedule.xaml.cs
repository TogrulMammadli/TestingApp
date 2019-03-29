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
using TestApplicationWPF.Repository.TestBlanksRepository;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.TestServices;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.ViewModel.ExamSheduleVM;

namespace TestApplicationWPF.Pages
{
    /// <summary>
    /// Interaction logic for ExamShedule.xaml
    /// </summary>
    public partial class ExamShedule : Page
    {
        ExamSheduleViewModel ViewModel;

        public ExamShedule()
        {
            InitializeComponent();
            ViewModel = new ExamSheduleViewModel(new UserService(new UserRepository()),new TestService(new TestBlankRepository()));
            this.DataContext = ViewModel;
           
        }

        private void AddStudentToExam_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
