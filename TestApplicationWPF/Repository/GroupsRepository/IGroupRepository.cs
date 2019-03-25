using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.GroupsRepository
{
  public  interface IGroupRepository
    {
        bool AddGroup(Group group);
        IEnumerable<Group> GetAllGroups();
        Group GetGroupByID(int ID);
        ICollection<Group> GetGroupsByCource(Cource cource);
        Group GetGroupsByName(string name);
        bool RemoveGroup(Group group);
        bool RemoveGroupById(int Id);
    }
}
