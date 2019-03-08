using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AccessLevelRepository
{
    
    public class AccessLevelRepository : IAccessLevelRepository
    {
        int a = 5;
        public bool AddAccessLevel(AccessLevel accessLevel)
        {
            try
            {
                using (var c= new TestContext())
                {
                    c.AccessLevels.Add(accessLevel);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<AccessLevel> GetAllAccessLevels()
        {
            using (var c = new TestContext())
            {
                return c.AccessLevels;
            }
        }

        public bool RemoveAccessLevelById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach(var test in c.AccessLevels)
                {
                    if(test.Id == Id)
                    {
                        c.AccessLevels.Remove(test);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
