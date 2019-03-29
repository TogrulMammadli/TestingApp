using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Models
{
  public  class Exams//soderjit blank vremanacala vrema konce
    {
        public Exams()
        {
        }

        public Exams(User user, TestBlank blank)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Blank = blank ?? throw new ArgumentNullException(nameof(blank));
        }
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public TestBlank Blank { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<StudentAnwsers> studentanswer { get; set; }  
        
    }
}
