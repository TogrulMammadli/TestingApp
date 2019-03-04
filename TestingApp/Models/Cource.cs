using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp.Models
{
    public class Cource// web stacionar polustac zirt pirt ....
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan duration  { get; set; }
        List<Subject> subjects;

        public Cource(int id, string name, TimeSpan duration, List<Subject> subjects)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            this.duration = duration;
            this.subjects = subjects ?? throw new ArgumentNullException(nameof(subjects));
        }

        public Cource()
        {
        }
    }
}
