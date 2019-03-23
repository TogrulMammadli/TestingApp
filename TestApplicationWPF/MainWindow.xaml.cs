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
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;
using System.Threading;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.Repository.GroupsRepository;
using TestApplicationWPF.Repository.CategoryRepository;
using TestApplicationWPF.Repository.QuestionsRepository;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserService userService = new UserService(new UserRepository());
        public MainWindow()
        {
            InitializeComponent();
            //var category = new Category() { Name = "TogrulCategory" };
            //CategoryRepository categoryRepository = new CategoryRepository();
            //categoryRepository.AddCategory(category);

            //var question = new Question(){Text="somethekst",subject=new Subject() {Name="testSubject" },Answers=new List<Answer>() { new   Answer() { Text = "dawwag" }, new Answer() { Text = "memew" } } };
            //QuestionRepository questionsss= new QuestionRepository();
            //questionsss.AddQuestion(question);

            //var user = new User() { Name = "Togrul", Surname="Mammadli",Patronymic="Vuqar",PhoneNumber="0503907667",Login="TogrulLogin",AccessLevels=new List<AccessLevel> { new AccessLevel() {Name="Admin"} },DateOfBirth=DateTime.Now,Email="mamedlitogrul99@gmail.com",Password="a",Gender=Gender.Male };
            //UserRepository userRepository = new UserRepository();
            //userRepository.AddUser(user);
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = userService.Login(TextBoxUserName.Text, PassBoxPassword.Password.ToString());


            if ((TextBoxUserName.Text == user.Login || TextBoxUserName.Text == user.Email) && PassBoxPassword.Password.ToString() == user.Password && userService.GetUserAccessLevels(user).Contains("Admin") == true)
            {
                HeadWindow headWindow = new HeadWindow();
                headWindow.Show();
                this.Close();
            }
            else if ((TextBoxUserName.Text == user.Login || TextBoxUserName.Text == user.Email) && PassBoxPassword.Password.ToString() == user.Password && userService.GetUserAccessLevels(user).Contains("Student") == true)
            {
                StudentWindow studentWindow = new StudentWindow();
                studentWindow.Show();
                this.Close();
            }
            else if (TextBoxUserName.Text == string.Empty && PassBoxPassword.Password.ToString() == string.Empty)
            {
                TextBlockWarning.Text = "You have put wrong password or user name!";
            }
            else
            {
                TextBlockWarning.Text = "You have put wrong password or user name!";
            }
            
        }

        private void ButtonForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassWindow forgotPassWindow = new ForgotPassWindow();
            forgotPassWindow.ShowDialog();
        }
    }
}
