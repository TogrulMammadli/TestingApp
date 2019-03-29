using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Services.SubjectService
{
 public   interface ISubjectService
    {
        IEnumerable<Subject> GetAllSubjects();
    }
}
