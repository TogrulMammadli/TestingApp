using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.ViewModel.AddUser
{
    public class AccessLevelKeyValue
    {
        public AccessLevel Key { get; set; } = new AccessLevel();
        public bool Value { get; set; }

        public override string ToString()
        {
            return Key.Name.ToString();
        }
    }
}
