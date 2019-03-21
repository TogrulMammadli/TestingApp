using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Models
{
  public  class WantedCourceToStudy // class soderjawiy studenta i kurs na kotorom on xocet ucitsa(stacionar zad) 
    {
        public WantedCourceToStudy()
        {
        }

        public WantedCourceToStudy(int studetnId, User user)
        {
            StudetnId = studetnId;
            this.user = user ?? throw new ArgumentNullException(nameof(user));
        }

        public int StudetnId { get; set; }
        public User user { get; set; }
    }
}
