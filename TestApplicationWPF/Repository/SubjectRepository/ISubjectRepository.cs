using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Repository.SubjectRepository
{
    interface ISubjectRepository
    {
        IEnumerable<Subject> GetAllSubjects();
        bool RemoveSubjectById(int Id);
        bool AddSubject(Subject subject);
    }
}
