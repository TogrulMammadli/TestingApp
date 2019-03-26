using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.SubjectRepository
{
  public  interface ISubjectRepository
    {
        bool AddSubject(Subject subject);
        IEnumerable<Subject> GetAllSubjects();
        Subject GetSubjectByID(int ID);
        Subject GetSubjectByName(string name);
        bool RemoveSubject(Subject subject);
        bool RemoveSubjectById(int Id);
    }
}
