using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.CourceRepository
{
    class CourceRepository : ICourceRepository
    {
        public bool AddCource(Cource cource)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.Cources.Add(cource);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public IEnumerable<Cource> GetAllCources()
        {
            using (var c = new TestContext())
            {
                return c.Cources;
            }
        }

        public bool RemoveCourceById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.Cources)
                {
                    if (test.Id == Id)
                    {
                        c.Cources.Remove(test);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
