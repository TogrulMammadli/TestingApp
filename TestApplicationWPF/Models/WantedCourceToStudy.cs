using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public WantedCourceToStudy(int studetnId, Cource cource)
        {
            StudetnId = studetnId;
            Cource = cource ?? throw new ArgumentNullException(nameof(cource));
        }

        [Key]
        public int StudetnId { get; set; }
        public Cource Cource { get; set; }
    }
}
