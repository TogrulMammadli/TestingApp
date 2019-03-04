using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.DataModel;
using TestingApp.Models;

namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
                using (var ctx = new TestContext())
                {
                    var stud = new User()
                    {
                        Name = "Natig",
                        Surname = "Aliyev",
                        DateOfBirth = DateTime.Now,
                        Email = "sosamba@hotmail.com",
                        PhoneNumber = "99999999",
                        Gender = Gender.Male,
                        AccessLevels = new List<AccessLevel>()
                        { new AccessLevel() {Id=1,Name="Mentor"} },
                        Login = "natigaliyev",
                        Password = "12345"
                    };
                    ctx.Users.Add(stud);
                    ctx.SaveChanges();
                    Console.WriteLine("vse");
                }
        }
    }
}
