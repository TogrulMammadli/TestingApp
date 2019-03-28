using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Mesages;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.AccessLevelRepository;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.ViewModel.AddUser
{
    public class AddUserViewModel : BaseViewModel
    {
        private IAccessLevelRepository accessrepo;
        private IUserService userService;
        public User User { get; set; } = new User();
        public ObservableCollection<AccessLevelKeyValue> AccessKeyValues { get; set; } = new ObservableCollection<AccessLevelKeyValue>();


        public AddUserViewModel(IUserService userService)
        {

            List<AccessLevel> accessLevels =new List<AccessLevel>(TestContext.Instance.AccessLevels.ToList());
            this.AccessKeyValues.Add(new AccessLevelKeyValue() {Key= accessLevels.Where(x => x.Name == "Admin").DefaultIfEmpty().Single()});
            this.AccessKeyValues.Add(new AccessLevelKeyValue() { Key = accessLevels.Where(x => x.Name == "Mentor").DefaultIfEmpty().Single() });
            this.AccessKeyValues.Add(new AccessLevelKeyValue() { Key = accessLevels.Where(x => x.Name == "Student").DefaultIfEmpty().Single() });

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
                foreach (var item in AccessKeyValues)
                {
                    if (item.Value == true)
                    {
                        User.AccessLevels.Add(item.Key);
                    }
                }
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

        private RelayCommand<DateTime> _addDate;
        public RelayCommand<DateTime> AddDate => _addDate ?? new RelayCommand<DateTime>(AddDateExecute, AddDateCanExecute);

        private bool AddDateCanExecute(DateTime dateTime)
        {
            return true;
        }

        private void AddDateExecute(DateTime dateTime)
        {
            User.DateOfBirth = dateTime;
        }

        private RelayCommand<string> _addPhone;
        public RelayCommand<string> AddPhone => _addPhone ?? new RelayCommand<string>(AddPhoneExecute, AddPhoneCanExecute);

        private bool AddPhoneCanExecute(string Phone)
        {
            return true;
        }

        private void AddPhoneExecute(string Phone)
        {
            User.PhoneNumber = Phone;
        }

    }
}
