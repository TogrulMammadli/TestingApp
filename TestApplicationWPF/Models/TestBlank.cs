using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.Models
{
    public class TestBlank
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string About { get; set; }
        public string Autor { get; set; }
        public TimeSpan DurationMin  { get; set; }
        public Boolean Used { get; set; } = false;
        public Boolean original { get; set; } = false;
        public virtual ICollection<Question> Questions { get; set; }

        public TestBlank()
        {
            this.Questions = new HashSet<Question>();
        }

        public TestBlank(int id, string name, string about, string autor, TimeSpan durationMin, bool used, bool original)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            About = about ?? throw new ArgumentNullException(nameof(about));
            Autor = autor ?? throw new ArgumentNullException(nameof(autor));
            DurationMin = durationMin;
            Used = used;
            this.original = original;
        }
    }

}
