using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.UserServices;

namespace TestApplicationWPF.ViewModels
{
    public class UserManagementViewModel : BaseViewModel
    {
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users { get => users; set => this.OnPropertyChanged(); }
        private readonly IUserService userService;

        public UserManagementViewModel(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            Task.Factory.StartNew(()=> {
                this.users = new ObservableCollection<User>(this.userService.GetAllUsers());
            this.OnPropertyChanged(nameof(Users));
            });
        }
    }
}

