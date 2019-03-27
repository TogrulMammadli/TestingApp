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
            this.users = new HashSet<User>();
        }

        public AccessLevel(int ıd, string name, ICollection<User> users)
        {
            Id = ıd;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            this.users = users ?? throw new ArgumentNullException(nameof(users));
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<User> users { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
