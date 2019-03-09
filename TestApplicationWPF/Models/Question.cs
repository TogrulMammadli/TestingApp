using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Models
{
    enum Complexity
    {
        Low = 1,
        Medium = 2,
        Hight = 3
    }
    public class Question
    {
        public Question(int ıd, string text, List<Answer> answers, List<Answer> correctAnswer, string ımage, Subject subject)
        {
            Id = ıd;
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Answers = answers ?? throw new ArgumentNullException(nameof(answers));
            this.correctAnswer = correctAnswer ?? throw new ArgumentNullException(nameof(correctAnswer));
            Image = ımage ?? throw new ArgumentNullException(nameof(ımage));
            this.subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Answer> correctAnswer { get; set; }
        public string Image { get; set; }
        public Subject subject { get; set; }
    }


}
