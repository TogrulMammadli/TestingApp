using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.CourceRepository
{
    public interface ICourceRepository
    {
        bool AddCource(Cource cource);
        IEnumerable<Cource> GetAllCources();
        Cource GetCourceByID(int ID);
        Cource GetCourcesByName(string name);
        bool RemoveCourceById(int Id);
        bool RemoveCource(Cource cource);
    }
}
