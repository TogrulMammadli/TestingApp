using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.SubjectRepository;

namespace TestApplicationWPF.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository SubjectRepository = new SubjectRepository();

        public SubjectService(ISubjectRepository subjectRepository)
        {
            SubjectRepository = subjectRepository ?? throw new ArgumentNullException(nameof(subjectRepository));
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return SubjectRepository.GetAllSubjects();
        }
    }
}
