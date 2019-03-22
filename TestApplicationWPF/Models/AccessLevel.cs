using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Models
{
    public class AccessLevel //student mentor admin,
    {
        public AccessLevel()
        {
        }

        public AccessLevel(int id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<User> users { get; set; }

    }
}
