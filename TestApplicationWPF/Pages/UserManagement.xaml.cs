using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.UserRepository;
using TestApplicationWPF.Services.UserServices;
using TestApplicationWPF.ViewModels;

namespace TestApplicationWPF.Pages
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Page
    {
        static UserRepository repository = new UserRepository();
        UserService UserService = new UserService(repository);
        public UserManagement(User user)
        {
            InitializeComponent();
            var viewModel = new UserManagementViewModel(UserService);
            this.DataContext = viewModel;
        }


        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            usersListBox.SelectedItem = border.DataContext;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (usersListBox.SelectedItems.Count > 0)
            {
                UserEditWindow userEditWindow = new UserEditWindow(((User)usersListBox.SelectedItems[0]));
                userEditWindow.Show();
            }
        }
        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchTxtBox.Text))
            {
                if (this.usersListBox != null)
                {
                    this.usersListBox.Items.Filter = new Predicate<object>((x) =>
                    {
                        var temp = x as User;
                        string fullname = temp.Name.ToUpper() + temp.Surname.ToUpper() + temp.Email.ToUpper() + temp.Login.ToUpper();
                        string searchText = this.SearchTxtBox.Text.ToUpper().Replace(" ", "");
                        return fullname.Contains(searchText);
                    });
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.Show();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            UserService.RemoveUser(((User)usersListBox.SelectedItems[0]));
        }
    }
}
