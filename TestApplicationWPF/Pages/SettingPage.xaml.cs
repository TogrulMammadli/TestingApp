

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
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Pages
{
    public partial class SettingPage : Page
    {
        User User = new User();
        public SettingPage(User user)
        {
            InitializeComponent();
            textboxname.Text = user.Name;
           surnameboxage.Text= user.Surname;
           
            sss.Text = user.Email;
            sss2.Text = user.PhoneNumber;
            textboxfather.Text = user.Patronymic;
            DateOfBirthBox.Text = user.DateOfBirth.ToString();
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
                if (textboxname.Text.Length < 2 && textboxname.Text != "") { TextBlockNameWarning.Text = "Name must be more letters!"; }
                else { TextBlockNameWarning.Text = ""; }

                //if (int.Parse(textboxage.Text) < 7 && textboxage.Text != "") { TextBlockAgeWarning.Text = "User must be older than 7 years!"; }
                //else if (int.Parse(textboxage.Text) > 70 && textboxage.Text != "") { TextBlockAgeWarning.Text = "User must not be older than 70 years!"; }
                //else { TextBlockAgeWarning.Text = ""; }
            }
            catch (Exception) { }

            //if (textboxphone.Text != "" && textboxphone.Text.Length < 10) { Textboxphonewarning.Text = "Length must not be than 10 digits!"; }

            if (!Regex.IsMatch(sss.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase) && sss.Text != "")
            {
                TextBlockEmailWarning.Text = "Wrong e-mail format!";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ForgotPasswordWindow3 forgotPasswordWindow3 = new ForgotPasswordWindow3(User,2);
            forgotPasswordWindow3.Show();
        }
    }
}
