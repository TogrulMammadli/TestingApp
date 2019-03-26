using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.GroupsRepository
{
    public class GroupRepository : IGroupRepository
    {
        public bool AddGroup(Group group)
        {
            try
            {
            TestContext.Instance.Groups.Add(group);
            TestContext.Instance.SaveChanges();
            return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Group> GetAllGroups()
        {
           
            return TestContext.Instance.Groups.ToList();
        }

        public Group GetGroupByID(int ID)
        {
            try
            {
                return TestContext.Instance.Groups.Where(x => x.Id == ID).DefaultIfEmpty().Single();
            }
            catch
            {
                return null;
            }
        }

        public ICollection<Group> GetGroupsByCource(Cource cource)
        {
            return TestContext.Instance.Groups.Where(x=>x.cource==cource).ToList();
        }

        public Group GetGroupsByName(string name)
        {
            return TestContext.Instance.Groups.Where(x => x.Name == name).DefaultIfEmpty().Single(); 
        }
        public bool RemoveGroup(Group group)
        {
            try
            {
                TestContext.Instance.Groups.Remove(group);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public bool RemoveGroupById(int Id)
        {
            try
            {
                TestContext.Instance.Groups.Remove(TestContext.Instance.Groups.Where(x => x.Id == Id).First());
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
