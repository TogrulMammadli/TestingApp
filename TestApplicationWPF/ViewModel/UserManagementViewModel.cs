using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Command;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.UserServices;

namespace TestApplicationWPF.ViewModels
{
    public class UserManagementViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public UserManagementViewModel()
        {
            //Messenger.Default.Register<NewUserMessage>(this, AddUserExexute);
        }


        //private void AddUserExexute(NewUserMessage message)
        //{
        //    this.Users.Add(message.NewUser);
        //}
    }
}

