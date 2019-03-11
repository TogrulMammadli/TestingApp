using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public List<User> students;
        public Cource cource;

        public Group(int ıd, string name, List<User> students, Cource cource)
        {
            Id = ıd;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            this.students = students ?? throw new ArgumentNullException(nameof(students));
            this.cource = cource ?? throw new ArgumentNullException(nameof(cource));
        }

        public Group()
        {
        }
    }
}
