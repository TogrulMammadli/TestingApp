using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestApplicationWPF.Repository.GroupsRepository
{
    interface IGroupRepository
    {
        IEnumerable<Group> GetAllGroups();
        Group RemoveGroupById(int Id);
        bool AddGroup(Group group);
    }
}
