using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.ViewModels
{
    public class LoginViewModel :BaseViewModel
    {
        private bool _isAuthenticated;
        public bool isAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                if (value != _isAuthenticated)
                {
                    _isAuthenticated = value;
                    OnPropertyChanged("isAuthenticated");
                }
            }
        }
    }
}
