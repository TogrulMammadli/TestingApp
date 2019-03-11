using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Models
{
    public enum Complexity
    {
        Low = 1,
        Medium = 2,
        Hight = 3
    }
    public class Question
    {
        public Question(int ıd, string text, List<Answer> answers, List<Answer> correctAnswer, Complexity complexity, byte[] ımage, Subject subject)
        {
            Id = ıd;
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Answers = answers ?? throw new ArgumentNullException(nameof(answers));
            CorrectAnswer = correctAnswer ?? throw new ArgumentNullException(nameof(correctAnswer));
            Complexity = complexity;
            Image = ımage ?? throw new ArgumentNullException(nameof(ımage));
            this.subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Answer> CorrectAnswer { get; set; }
        Complexity Complexity { get; set; }
        [MaxLength]
        public byte[] Image { get; set; }
        public Subject subject { get; set; }
    }


}
