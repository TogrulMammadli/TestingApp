﻿

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
                if (textboxname.Text.Length < 2 && textboxname.Text != "") { TextBlockNameWarning.Text = "Name must be more letters!"; }
                else { TextBlockNameWarning.Text = ""; }

                if (int.Parse(textboxage.Text) < 7 && textboxage.Text != "") { TextBlockAgeWarning.Text = "User must be older than 7 years!"; }
                else if (int.Parse(textboxage.Text) > 70 && textboxage.Text != "") { TextBlockAgeWarning.Text = "User must not be older than 70 years!"; }
                else { TextBlockAgeWarning.Text = ""; }
            }
            catch (Exception) { }

            if (textboxphone.Text != "" && textboxphone.Text.Length < 10) { Textboxphonewarning.Text = "Length must not be than 10 digits!"; }
            else { Textboxphonewarning.Text = ""; }

            if (!Regex.IsMatch(textboxemail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase) && textboxemail.Text != "")
            {
                TextBlockEmailWarning.Text = "Wrong e-mail format!";
            }

            else { TextBlockEmailWarning.Text = ""; }
            if (textboxpswd.Text != "" && textboxconfpswd.Text != "" && textboxpswd.Text != textboxconfpswd.Text) { TextBlockPswdWarning.Text = "Passwords do not match!"; }
            else { TextBlockPswdWarning.Text = ""; }

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
