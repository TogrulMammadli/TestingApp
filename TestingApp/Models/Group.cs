using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.Models;

namespace TestingApp.Models
{
   public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }//dobavit class mentor vmesto teacher ili sozdat otdelno teacher
        public string Room { get; set; }
        public List<User> students;
        public Cource cource;

        public Group(int ıd, string name, string teacher, string room, List<User> students, Cource cource)
        {
            Id = ıd;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Teacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
            Room = room ?? throw new ArgumentNullException(nameof(room));
            this.students = students ?? throw new ArgumentNullException(nameof(students));
            this.cource = cource ?? throw new ArgumentNullException(nameof(cource));
        }

        public Group()
        {
        }
    }
}
