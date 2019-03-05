using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Models
{
  public  class Subject
    {
        public Subject()
        {
        }

        public Subject(int ıd, int name)
        {
            Id = ıd;
            Name = name;
        }

        public int Id { get; set; }
        public int Name { get; set; }
    }
}
