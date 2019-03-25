using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AccessLevelRepository
{
    public class AccessLevelRepository : IAccessLevelRepository
    {
        public bool AddAccessLevel(AccessLevel accessLevel)
        {
            try
            {
                TestContext.Instance.AccessLevels.Add(accessLevel);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<AccessLevel> GetAllAccessLevels()
        {
            return TestContext.Instance.AccessLevels.Include("Users").ToList();
        }

        public AccessLevel GetAccessLevelByID(int ID)
        {
            try
            {
                return TestContext.Instance.AccessLevels.Where(x=>x.Id==ID).First();
            }
            catch
            {
                return null;
            }
        }

        public AccessLevel GetAccessLevelByName(string accessName)
        {
            try
            {
                return TestContext.Instance.AccessLevels.Where(x => x.Name == accessName).First();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool RemoveAccessLevel(AccessLevel accessLevel)
        {
            try
            {
                TestContext.Instance.AccessLevels.Remove(accessLevel);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool RemoveAccessLevelById(int Id)
        {
            try
            {
                TestContext.Instance.AccessLevels.Remove(TestContext.Instance.AccessLevels.First(x=>x.Id==Id));
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}

