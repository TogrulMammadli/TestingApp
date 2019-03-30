using MaterialDesignThemes.Wpf;
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
using TestApplicationWPF.PagesStudent;
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
        public int MyNumber=0;
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
            //a++;
            //examChooseViewModel.Like.Execute(true);
            //Application.Current.Resources["MyNumber"] = (int)MyNumber;
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            if ((((Exams)((Border)sender).DataContext).EndDate<DateTime.Now))
            {
                ((Border)sender).Opacity = 0.6;
                ((Border)sender).BorderThickness=new Thickness(2);
            }
        }

        private void ColorGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if ((((Exams)((Grid)sender).DataContext).EndDate < DateTime.Now && (((Exams)((Grid)sender).DataContext).BeginDate < DateTime.Now)))
            {
                ((Grid)sender).Background = Brushes.Red;
            }
            if ((((Exams)((Grid)sender).DataContext).BeginDate < DateTime.Now && (((Exams)((Grid)sender).DataContext).EndDate > DateTime.Now)))
            {
                ((Grid)sender).Background = Brushes.Green;
            }
        }

        private void StartButton_Loaded(object sender, RoutedEventArgs e)
        {
            if ((((Exams)((Button)sender).DataContext).EndDate < DateTime.Now && (((Exams)((Button)sender).DataContext).BeginDate < DateTime.Now)))
            {
                ((Button)sender).IsEnabled = false;
                return;
            }

            if ((((Exams)((Button)sender).DataContext).BeginDate > DateTime.Now))
            {
                ((Button)sender).IsEnabled = false;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            HeadWindow.ChangePage(new ExamStartPage(((Exams)(((Button)sender).DataContext))));  
        }
    }
}
