using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.AccessLevelRepository
{
    public interface IAccessLevelRepository
    {
        IEnumerable<AccessLevel> GetAllAccessLevels();
        bool RemoveAccessLevelById(int Id);
        bool AddAccessLevel(AccessLevel accessLevel);
        AccessLevel GetAccessLevelByName(string accessName);
        AccessLevel GetAccessLevelByID(int ID);
        bool RemoveAccessLevel(AccessLevel accessLevel);
    }
}
