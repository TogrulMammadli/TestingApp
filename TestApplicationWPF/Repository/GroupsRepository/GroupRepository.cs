﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                    c.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
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
                    c.SaveChanges();
                        return true;
                    }
                }
                MessageBox.Show("Не было найдено данного id!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }

       
    }
}
