using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Models
{
    public class BestTimeForStudy/// tablica kotoraya budet soderjat studenta i vrema kogda on xocet ucitsa
    {
        public BestTimeForStudy(int userId, DateTime dateTime)
        {
            this.userId = userId;
            this.dateTime = dateTime;
        }
       [Key]
        public int userId { get; set; }
        public DateTime? dateTime { get; set; }

    }
}
