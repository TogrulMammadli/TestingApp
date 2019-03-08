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

namespace TestApplicationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //using (var ctx = new TestContext())
            //{
            //    var stud = new User()
            //    {
            //        Name = "proverka",
            //        Surname = "2",
            //        DateOfBirth = DateTime.Now,
            //        Email = "",
            //        PhoneNumber = "5",
            //        Gender = Gender.Female,
            //        AccessLevels = new List<AccessLevel>()
            //            { new AccessLevel() {Id=1,Name="Soset"} },
            //        Login = "TogrulLogin",
            //        Password = "12345"
            //    };
            //    // ctx.Users.Add(stud);
            //    //ctx.SaveChanges();
            //    //  Console.WriteLine("vse");
               
            //// userRepository.AddUser(stud);

            //}

        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
