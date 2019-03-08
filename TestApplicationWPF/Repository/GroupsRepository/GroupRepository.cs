using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.GroupsRepository
{
    class GroupRepository : IGroupRepository
    {
        public bool AddGroup(Group group)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.Groups.Add(group);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool AddGroup(System.Text.RegularExpressions.Group group)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAllGroups()
        {
            using (var c = new TestContext())
            {
                return c.Groups;
            }
        }

        public bool RemoveGroupById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.Groups)
                {
                    if (test.Id == Id)
                    {
                        c.Groups.Remove(test);
                        return true;
                    }
                }
                return false;
            }
        }

       
    }
}
