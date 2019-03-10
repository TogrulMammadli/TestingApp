using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public Subject(int ıd, string name)
        {
            Id = ıd;
            Name = name;
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
