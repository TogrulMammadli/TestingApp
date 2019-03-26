using System;
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

        private void numbervalit(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textboxname.Text.Length <= 2 && textboxname.Text != "")
                {
                    MessageBox.Show("Имя не может быть меньше 3 букв");
                    textboxname.Clear();
                }
                else if (textboxage.Text != "" && int.Parse(textboxage.Text) < 7)
                {
                    MessageBox.Show("Возраст не должен быть меньше 7");
                    textboxage.Clear();
                }
                else if (textboxage.Text != "" && int.Parse(textboxage.Text) > 70)
                {
                    MessageBox.Show("Возраст не должен быть старше 70");
                    textboxage.Clear();
                }
                else if (textboxphone.Text != "" && textboxphone.Text.Length < 10)
                {
                    MessageBox.Show("Минимальная длина номера 10 цифр");
                    textboxphone.Clear();
                }
                else if (textboxpswd.Text != textboxconfpswd.Text)
                {
                    MessageBox.Show("Пароли не совпадают");
                    textboxpswd.Clear();
                    textboxconfpswd.Clear();
                }
                else if (!Regex.IsMatch(textboxemail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Не правильный формат E-mail");
                    textboxemail.Clear();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Textboxname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                Regex regex = new Regex("[^a-z]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else
            {
                e.Handled = false;
            }
        }

    }
}
