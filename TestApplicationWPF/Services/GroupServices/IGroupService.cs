using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Services.GroupServices
{
    public interface IGroupService
    {
        List<Group> CreateGroupConfigureGroup(DateTime starttime, DateTime dateTime, Cource cource);
    }
}
