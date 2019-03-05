using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Models
{
    public class TestBlank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan DurationMin  { get; set; }
        public List<Question> Questions { get; set; }
        bool Used=false;

        public TestBlank(int id, string name,TimeSpan durationMin, List<Question> questions, bool used)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
         
            DurationMin = durationMin;
            this.Questions = questions ?? throw new ArgumentNullException(nameof(questions));
            Used = used;
        }

        public TestBlank()
        {
        }
    }

    //metodi get different  staticstics that returns a percent of correct, false, po disciplinam, vsego itd
}
