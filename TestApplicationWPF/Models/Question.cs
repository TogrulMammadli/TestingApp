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

        public Question()
        {
        }

        public Question(int ıd, string text, List<WrongAnswer> wrongAnswers, List<CorrectAnswer> correctAnswers, Complexity complexity, byte[] ımage, Subject subject)
        {
            Id = ıd;
            Text = text ?? throw new ArgumentNullException(nameof(text));
            WrongAnswers = wrongAnswers ?? throw new ArgumentNullException(nameof(wrongAnswers));
            CorrectAnswers = correctAnswers ?? throw new ArgumentNullException(nameof(correctAnswers));
            Complexity = complexity;
            Image = ımage ?? throw new ArgumentNullException(nameof(ımage));
            this.subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual List<WrongAnswer> WrongAnswers { get; set; }
        public virtual List<CorrectAnswer> CorrectAnswers { get; set; }
        Complexity Complexity { get; set; }
        [MaxLength]
        public byte[] Image { get; set; }
        public Subject subject { get; set; }
    }


}
