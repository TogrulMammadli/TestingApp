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

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for AddNewQuestion.xaml
    /// </summary>
    public partial class AddNewQuestion : Window
    {
        public AddNewQuestion()
        {
            InitializeComponent();
        }

        private void Low_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Normal_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Hight_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
