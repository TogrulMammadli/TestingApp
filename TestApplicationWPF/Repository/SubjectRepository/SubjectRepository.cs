using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.SubjectRepository
{
    class SubjectRepository : ISubjectRepository
    {
        public bool AddSubject(Subject subject)
        {
            using (var c = new TestContext())
            {
                try
                {
                    c.Subjects.Add(subject);
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

        public IEnumerable<Subject> GetAllSubjects()
        {
            using (var c = new TestContext())
            {
                return c.Subjects;
            }
        }

        public bool RemoveSubjectById(int Id)
        {
            using (var c = new TestContext())
            {
                foreach (var test in c.Subjects)
                {
                    if (test.Id == Id)
                    {
                        c.Subjects.Remove(test);
                        return true;
                    }
                }
                MessageBox.Show("Не было найдено данного id!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
    }
}
