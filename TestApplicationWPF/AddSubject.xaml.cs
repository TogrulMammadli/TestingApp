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
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.SubjectRepository;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.SubjectService;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for AddSubject.xaml
    /// </summary>
    public partial class AddSubject : Window
    {
        static SubjectRepository repository = new SubjectRepository();
         SubjectService subjectService = new SubjectService(repository);
        Subject subject = new Subject();
        public AddSubject()
        {
            InitializeComponent();
            var viewModel = new SubjectViewModel(subjectService);
            this.DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
                subject = ((Subject)SubjectListBox.SelectedItems[0]);

            PageCreateTest.GetSubject(subject);
            this.Close();
        }
        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            SubjectListBox.SelectedItem = border.DataContext;
        }
    }
}
