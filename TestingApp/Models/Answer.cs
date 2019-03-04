using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp.Models
{
   public class Answer
    {
        public Answer()
        {
        }

        public Answer(int id, string text, string image)
        {
            Id = id;
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Image = image ?? throw new ArgumentNullException(nameof(image));
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
    }
}
