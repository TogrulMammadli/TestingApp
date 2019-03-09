using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Models
{
    public class Category//kategoriya voprosa aciq, test fromasinda, i druqie,sootvetstvie 
    {
        public Category()
        {
        }

        public Category(int id, int name)
        {
            Id = id;
            Name = name;
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public int Name { get; set; }

    }
}
