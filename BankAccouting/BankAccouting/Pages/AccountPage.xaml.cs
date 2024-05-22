using BankAccouting.View;
using BankAccouting.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace BankAccouting.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
            accountDG.ItemsSource = AccountViewModel.AccountToList();
        }

        private void OpenAddAccountWindow(object sender, RoutedEventArgs e) => new AddAccountWindow(accountDG).Show();

        private void UseEditAccountWindow(object sender, RoutedEventArgs e)
        {
            if (accountDG.SelectedIndex != -1)
                new EditAccountWindow(accountDG).Show();
        }

        private async void UseDeleteToDbAsync(object sender, RoutedEventArgs e)
        {
            if (accountDG.SelectedIndex != -1)
            {
                await AccountViewModel.DeleteAccountToDbAsync(accountDG.SelectedIndex);
                accountDG.ItemsSource = AccountViewModel.AccountToList();
            }
        }
    }
}