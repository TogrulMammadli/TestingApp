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

        public Group GetGroupByID(int ID)
        {
            using (var c = new TestContext())
            {
                foreach(var temp in c.Groups)
                {
                    if(temp.Id == ID)
                    {
                        return temp;
                    }
                }
                MessageBox.Show("Не было найдено групп с данным ID!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }

        public ICollection<Group> GetGroupsByCource(Cource cource)
        {
            List<Group> groups = new List<Group>();
            using (var c = new TestContext())
            {
                foreach(var temp in c.Groups)
                {
                    if(temp.cource == cource)
                    {
                        groups.Add(temp);
                    }
                }
                if(groups.Count != 0)
                {
                    return groups;
                }
                else
                {
                    MessageBox.Show("Не было найдено групп с данным курсом!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return null;
                }
            }
        }

        public ICollection<Group> GetGroupsByName(string name)
        {
            List<Group> groups = new List<Group>();
            using (var c = new TestContext())
            {
                foreach(var temp in groups)
                {
                    if(temp.Name == name)
                    {
                        groups.Add(temp);
                    }
                }
                if(groups.Count != 0)
                {
                    return groups;
                }
                else
                {
                    MessageBox.Show("Не было найдено группы с данным именем!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return null;
                }
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
                MessageBox.Show("Не было найдено группы с данным ID!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }

       
    }
}
