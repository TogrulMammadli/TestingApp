using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.CourceRepository
{
    public class CourceRepository : ICourceRepository
    {
        public bool AddCource(Cource cource)
        {
            try
            {
                TestContext.Instance.Cources.Add(cource);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Cource> GetAllCources()
        {
            return TestContext.Instance.Cources.ToList();
        }

        public Cource GetCourceByID(int ID)
        {
            return TestContext.Instance.Cources.Where(x => x.Id == ID).First();

        }

        public Cource GetCourcesByName(string name)
        {
            return TestContext.Instance.Cources.Where(x => x.Name == name).First();
        }

        public bool RemoveCourceById(int Id)
        {
            try
            {
                TestContext.Instance.Cources.Remove(TestContext.Instance.Cources.Where(x => x.Id == Id).First());
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveCource(Cource cource)
        {
            try
            {
                TestContext.Instance.Cources.Remove(cource);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
