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

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for ForgotPassword2.xaml
    /// </summary>
    public partial class ForgotPassword2 : Window
    {
        string Code;
        User User = new User();
        public ForgotPassword2(User user, string Code)
        {
            InitializeComponent();
            this.Code = Code;
            User = user;
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CodeBox.Text))
            {
                TextBlockWarning.Text = "Please enter code";
                return;
            }
            if (CodeBox.Text.Contains(Code))
            {
                ForgotPasswordWindow3 forgotPasswordWindow3 = new ForgotPasswordWindow3(User);
                forgotPasswordWindow3.Show();
                this.Close();
            }
            else
            {
                TextBlockWarning.Text = "Wrong code";
                CodeBox.BorderBrush = Brushes.Red;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
    }
}
