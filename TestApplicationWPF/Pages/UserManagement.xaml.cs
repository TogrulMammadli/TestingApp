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
        UserManagementViewModel ViewModel;

        public UserManagement(User user)
        {
            InitializeComponent();
            ViewModel = new UserManagementViewModel(new UserService(new  UserRepository()));
            this.DataContext = ViewModel;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.Show();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveUser.Execute(usersListBox.SelectedItems[0]);
        }

        private void UsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
