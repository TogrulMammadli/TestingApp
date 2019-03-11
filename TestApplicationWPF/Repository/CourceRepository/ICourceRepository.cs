using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.CourceRepository
{
    interface ICourceRepository
    {
        IEnumerable<Cource> GetAllCources();
        bool RemoveCourceById(int Id);
        bool AddCource(Cource cource);
        Cource GetCourceByID(int ID);
        ICollection<Cource> GetCourcesByName(string name);
    }
}
