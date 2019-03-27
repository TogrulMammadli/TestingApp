using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Mesages
{
    class WindowMessages
    {
        public string MessageText { get; set; }

        public WindowMessages(string messageText)
        {
            MessageText = messageText ?? throw new ArgumentNullException(nameof(messageText));
        }
    }
}
