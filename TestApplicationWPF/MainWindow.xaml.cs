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
using System.IO;
using TestApplicationWPF.Repository.AccessLevelRepository;

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserService userService = new UserService(new UserRepository());
        User user = new User();
        public MainWindow()
        {
            InitializeComponent();
            //var category = new Category() { Name = "TogrulCategory" };
            //CategoryRepository categoryRepository = new CategoryRepository();
            //categoryRepository.AddCategory(category);

            //var question = new Question() { Text = "ParvizPidor", subject = new Subject() { Name = "MuradTojepidor" } ,CorrectAnswers=new List<CorrectAnswer>() { new CorrectAnswer() { Text="correct"}},WrongAnswers=new List<WrongAnswer> { new WrongAnswer() {Text="asd"} },TestBlanks=new List<TestBlank>() { new TestBlank() { Name = "asd" } } };
            //QuestionRepository questionsss = new QuestionRepository();
            //questionsss.AddQuestion(question);

            //AccessLevelRepository accessLevelRepository = new AccessLevelRepository();
            //var user = new User() { Name = "Murad", Surname = "Mammadov", Patronymic = "Gabil", PhoneNumber = "", Login = "admin", AccessLevels = new List<AccessLevel> { accessLevelRepository.GetAccessLevelByName("Admin") }, DateOfBirth = DateTime.Now, Email = "@gmail.com", Password = "admin", Gender = Gender.Male };
            //UserRepository userRepository = new UserRepository();
            //userRepository.AddUser(user);
            //#region UpdateImageInDbTesting

            ////try
            ////{
            ////    string path = userService.OpenFileGetPath();
            ////    if (path != "Error")
            ////    {
            ////        userService.UpdateAvatarImage(1, path);
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    MessageBox.Show(ex.Message);
            ////    throw;
            ////}
            ////MessageBox.Show("Good Job");
            //#endregion
            //var b = userRepository.GetUserByID(1);
            //var a = 5;
            //StudentAnwser studentAnwser = new StudentAnwser();
            //studentAnwser.Answer = "otvet1|7767|otvet2";



        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxUserName.Text == string.Empty || PassBoxPassword.Password.ToString() == string.Empty)
            {
                if (string.IsNullOrWhiteSpace(TextBoxUserName.Text))
                {
                    TextBoxUserName.BorderBrush = Brushes.Red;
                }
                if (string.IsNullOrWhiteSpace(PassBoxPassword.Password))
                {
                    PassBoxPassword.BorderBrush = Brushes.Red;
                }
                this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Hidden);
                TextBlockWarning.Text = "Please fill all fields";
                return;
            }
            Task Log = new Task(Login);
            Log.Start();
            {
                Log.ContinueWith((x) =>
                {
                    if (Log.IsCompleted)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            if (user != null)
                            {
                                HeadWindow headWindow = new HeadWindow(user);
                                headWindow.Show();
                                this.Close();
                            }
                            else
                            {
                                TextBlockWarning.Text = "Wrong login or password";
                                this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Hidden);
                            }
                        });
                    }
                });
            }
        }

        private void ButtonForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassWindow forgotPassWindow = new ForgotPassWindow();
            forgotPassWindow.ShowDialog();
        }

        public void Login()
        {
            this.Dispatcher.InvokeAsync(() => this.PrgrssBar.Visibility = Visibility.Visible);
            this.Dispatcher.InvokeAsync(() => this.TextBoxUserName.BorderBrush = Brushes.Gray);
            this.Dispatcher.InvokeAsync(() => this.PassBoxPassword.BorderBrush = Brushes.Gray);

            try
            {
                user = userService.Login(this.Dispatcher.Invoke(() => TextBoxUserName.Text), this.Dispatcher.Invoke(() => PassBoxPassword.Password.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}