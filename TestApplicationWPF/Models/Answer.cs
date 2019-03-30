using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Models
{
    abstract public class Answer
    {
        public Answer()
        {
        }

        public Answer(int id, string text, byte[] image)
        {
            Id = id;
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Image = image ?? throw new ArgumentNullException(nameof(image));
        }
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        [MaxLength]
        public byte[] Image { get; set; }
    }

    public class CorrectAnswer : Answer
    {
        public CorrectAnswer()
        {
        }

        public CorrectAnswer(int id, string text, byte[] image) : base(id, text, image)
        {
            this.Questions = new HashSet<Question>();
        }
        public virtual ICollection<Question> Questions { get; set; }

    }

    public class WrongAnswer : Answer
    {
        public WrongAnswer()
        {
        }

        public WrongAnswer(int id, string text, byte[] image) : base(id, text, image)
        {
            this.Questions = new HashSet<Question>();
        }
        public virtual ICollection<Question> Questions { get; set; }

    }

    public class StudentAnwsers
    {
        public StudentAnwsers()
        {
        }
        [Key]
        public int Id { get; set; }
        public List<Ans> Answers { get; set; }

    }
    public class Ans{

        public int Id { get; set; }
        public string An { get; set; }
        public Ans()
        {
        }

        public override string ToString()
        {
            return An;
        }
    }
}
