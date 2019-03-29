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

namespace TestApplicationWPF.Pages
{
    /// <summary>
    /// Interaction logic for ChooseTestBlankPage.xaml
    /// </summary>
    public partial class ChooseTestBlankPage : Page
    {
        ExamChooseViewModel examChooseViewModel;
        User User = new User();
        public ChooseTestBlankPage(User user)
        {
            InitializeComponent();
            User = user;
            examChooseViewModel = new ExamChooseViewModel(new ExamService(),User);
            this.DataContext = examChooseViewModel;
        }
    
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //if (CountingBadge5.Badge == null || Equals(CountingBadge5.Badge, ""))
            //    CountingBadge5.Badge = 0;

            //var next = int.Parse(CountingBadge5.Badge.ToString()) + 1;

            //CountingBadge5.Badge = next < 99 ? (object)next : null;
        }
    }
}
