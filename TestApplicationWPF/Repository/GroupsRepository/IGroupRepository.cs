﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.GroupsRepository
{
    interface IGroupRepository
    {
        IEnumerable<Group> GetAllGroups();
        bool RemoveGroupById(int Id);
        bool AddGroup(Group group);
    }
}