using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.Data;
using TestingApp.Models;

namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new TestingAppContext())
            {
                var stud = new User()
                {
                    Name = "Togrul",
                    Surname = "Mammadli",
                    DateOfBirth = DateTime.Now,
                    Email = "Mame_fy31@gmail.com",
                    PhoneNumber = "0503907667",
                    Gender = Gender.Male,
                    AccessLevels = new List<АccessLevel>()
                    { new АccessLevel() {Id=1,Name="Admin"} },
                    Login="TogrulMammadli",
                    Password="12345"
                };
                ctx.Users.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}
