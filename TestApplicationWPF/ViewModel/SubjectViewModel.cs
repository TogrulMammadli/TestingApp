using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.SubjectRepository;
using TestApplicationWPF.Services.SubjectService;
using TestApplicationWPF.Services.UserServices;

namespace TestApplicationWPF.ViewModels
{
    public  class SubjectViewModel : BaseViewModel
    {
        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects { get => subjects; set => this.OnPropertyChanged(); }
        private readonly ISubjectService subjectService;

        public SubjectViewModel(ISubjectService subjectService)
        {
            this.subjectService = subjectService ?? throw new ArgumentNullException(nameof(subjectService));
            this.subjects = new ObservableCollection<Subject>(this.subjectService.GetAllSubjects());
            this.OnPropertyChanged(nameof(Subjects));
        }
    }
}   
