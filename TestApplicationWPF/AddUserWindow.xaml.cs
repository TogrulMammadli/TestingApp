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
using System.Text.RegularExpressions;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Models;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        UserService userService = new UserService(new UserRepository());
        User user = new User();
        public AddUserWindow()
        {
            InitializeComponent();
            dataPicker.SelectedDate=DateTime.Now.Date;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ImageBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = userService.OpenFileGetPath();
                if (path != "Error")
                {
                    Task.Factory.StartNew(() => { user.İmage = userService.ConvertImageToByte(path); });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Gender gender = Gender.Male;
            List<AccessLevel> accessLevels = new List<AccessLevel>();
            if (admin.IsChecked==true)
            {
                accessLevels.Add(new AccessLevel() { Id=1,Name="Admin"});
            }
            if (mentor.IsChecked == true)
            {
                accessLevels.Add(new AccessLevel() { Id = 2, Name = "Mentor" });
            }
            if (student.IsChecked == true)
            {
                accessLevels.Add(new AccessLevel() { Id = 3, Name = "Student" });
            }
            if (Female.IsChecked==true)
            {
                gender = Gender.Female;
            }
            var user = new User() { Name = Name.Text, Surname = Surname.Text, Patronymic = Patronymic.Text, PhoneNumber = Operator.Text+NumberTextBox.Text, Login = Login.Text, AccessLevels = new List<AccessLevel> { new AccessLevel() { Name = "Admin" } }, DateOfBirth =dataPicker.SelectedDate.Value, Email = "mamedlitogrul99@gmail.com", Password = Password.Text, Gender = Gender.Male };
            UserRepository userRepository = new UserRepository();
            userRepository.AddUser(user);

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            user = new User();
            this.Close();
        }
    }
}
