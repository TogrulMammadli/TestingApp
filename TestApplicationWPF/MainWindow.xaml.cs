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
            using (var ctx = new TestContext())
            {
                var stud = new User()
                {
                    Name = "Murad",
                    Surname = "Gehbedi",
                    DateOfBirth = DateTime.Now,
                    Email = "petux@hotmail.com",
                    PhoneNumber = "99999999",
                    Gender = Gender.Male,
                    AccessLevels = new List<AccessLevel>()
                        { new AccessLevel() {Id=1,Name="Mentor"} },
                    Login = "muradsoset",
                    Password = "12345"
                };
                ctx.Users.Add(stud);
                ctx.SaveChanges();
                Console.WriteLine("vse");
            }

        }
    }
}
