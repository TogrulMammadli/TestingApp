using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.Mesages;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.UserServices;

namespace TestApplicationWPF.ViewModels
{
    public class UserManagementViewModel : BaseViewModel
    {
        private IUserService service;
        public ObservableCollection<User> Users { get; set; } 
        User user  = new User();

        public UserManagementViewModel(IUserService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            Messenger.Default.Register<NewUserMesenger>(this, AddUserExexute);
            Users = new ObservableCollection<User>(service.GetAllUsers());
        }

        private RelayCommand<User> _removeUser;

        public RelayCommand<User> RemoveUser => _removeUser ?? new RelayCommand<User>(RemoveUserExexute, RemoveCanExecute);

        private bool RemoveCanExecute(User user)
        {
            return true;
        }

        private void RemoveUserExexute( User user)
        {
            try
            {
                service.RemoveUser(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Users.Remove(user);
        }


        private void AddUserExexute(NewUserMesenger message)
        {
            this.Users.Add(message.NewUser);
        }
    }
}

