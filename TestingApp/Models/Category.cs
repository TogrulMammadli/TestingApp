using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp.Models
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

        public int Id { get; set; }
        public int Name { get; set; }

    }
}
