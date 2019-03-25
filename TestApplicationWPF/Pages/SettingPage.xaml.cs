using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TestApplicationWPF.Pages
{
    public partial class SettingPage : Page
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(textboxage.Text) <= 7)
                {
                    MessageBox.Show("Возраст не должен быть меньше 7");
                    textboxage.Clear();
                }

                else if (int.Parse(textboxage.Text) >= 70)
                {
                    MessageBox.Show("Возраст не должен быть старше 70");
                    textboxage.Clear();
                }
            }
            catch (System.Exception){}
        }
    }
}