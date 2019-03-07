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
        AccessLevel RemoveAccessLevelById(int Id);
        bool AddAccessLevel(AccessLevel accessLevel);
    }
}
