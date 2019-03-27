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
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.AddUser
{
    public class AddUserViewModel : BaseViewModel
    {
        private IUserService userService;
        public User User { get; set; } = new User();
        public ObservableCollection<AccessLevelKeyValue> AccessKeyValues { get; set; } = new ObservableCollection<AccessLevelKeyValue>();


        public AddUserViewModel(IUserService userService)
        {
           // this.AccessKeyValues.Add(new AccessLevelKeyValue { Key = new AccessLevel() { Id = -99, Name = "Admin" } });
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));

        }

        private RelayCommand _addUser;
        public RelayCommand AddUser => _addUser ?? new RelayCommand(AddUserExexute, AddUserCanExecute);


        private bool AddUserCanExecute()
        {
            return this.User.Name?.Count() > 0;
        }

        private void AddUserExexute()
        {
            try
            {
                string str = "";
                foreach (var item in AccessKeyValues)
                {
                    if (item.Value == true)
                    {
                        str += item.ToString() + "\n";
                    }
                }
                MessageBox.Show(str);
                MessageBox.Show(User.DateOfBirth.ToString());
                userService.AddUser(User);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Messenger.Default.Send(new NewUserMesenger(User));
            Messenger.Default.Send<WindowMessages>(new WindowMessages("close"), "AddUser");
        }


        private RelayCommand _addImage;
        public RelayCommand AddImage => _addImage ?? new RelayCommand(AddImageExecute, AddImageCanExecute);

        private bool AddImageCanExecute()
        {
            return true;
        }

        private void AddImageExecute()
        {
            string path = userService.OpenFileGetPath();
            if (path != "Error")
            {
                try
                {
                    Task.Factory.StartNew(() => { User.İmage = userService.ConvertImageToByte(path); });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

        }

        private RelayCommand<Gender> _genderCheck;
        public RelayCommand<Gender> GenderCheck => _genderCheck ?? new RelayCommand<Gender>(CheckGender, CheckGenderCanExecute);

        private bool CheckGenderCanExecute(Gender gender)
        {
            return true;
        }

        private void CheckGender(Gender gender)
        {
            User.Gender = gender;

        }

    }
}
