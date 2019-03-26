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
            try
            {
                TestContext.Instance.Subjects.Add(subject);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return TestContext.Instance.Subjects.ToList();
        }

        public Subject GetSubjectByID(int ID)
        {
            try
            {
                return TestContext.Instance.Subjects.Where(x => x.Id == ID).First();
            }
            catch
            {
                return null;
            }
        }

        public Subject GetSubjectByName(string name)
        {
            try
            {
                return TestContext.Instance.Subjects.Where(x => x.Name == name).First();
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool RemoveSubject(Subject subject)
        {
            try
            {
                TestContext.Instance.Subjects.Remove(subject);
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool RemoveSubjectById(int Id)
        {
            try
            {
                TestContext.Instance.Subjects.Remove(TestContext.Instance.Subjects.Where(x => x.Id == Id).First());
                TestContext.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
