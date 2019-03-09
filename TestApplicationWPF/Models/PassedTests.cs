using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Models
{
  public  class PassedTests
    {
        public PassedTests()
        {
        }

        public PassedTests(User user, TestBlank blank)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Blank = blank ?? throw new ArgumentNullException(nameof(blank));
        }
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public TestBlank Blank { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
