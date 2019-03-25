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
        [Index(IsUnique =true)]
        public string Name { get; set; }
        public string About { get; set; }
        public string Autor { get; set; }
        public TimeSpan DurationMin  { get; set; }
        bool Used=false;
        public virtual ICollection<Question> Questions { get; set; }

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
            this.Questions = new HashSet<Question>();
        }
    }

}
