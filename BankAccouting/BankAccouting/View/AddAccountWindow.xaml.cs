using BankAccouting.Models;
using BankAccouting.Pages;
using BankAccouting.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для AddAccountWindow.xaml
    /// </summary>
    public partial class AddAccountWindow : Window
    {
        private readonly DataGrid accountDG;
        private readonly DataGrid contractDG;

        public Client? Client { get; private set; }

        public AddAccountWindow(DataGrid accountDG)
        {
            InitializeComponent();
            this.accountDG = accountDG;
            contractDG = App.HostService.Services.GetRequiredService<ContractPage>().contractDG;
        }

        public AddAccountWindow(DataGrid accountDG, Client client) : this(accountDG)
        {
            Client = client;
        }

        private async void UseAddAccountAndContractToDb(object sender, RoutedEventArgs e)
        {
            if (balance.Text != string.Empty && accountNumber.Text != string.Empty)
            {
                await AccountViewModel.AddAccountToAndContractDbAsync(new Account
                {
                    Balance = Decimal.Parse(balance.Text),
                    TypeAccount = cbTypeAccount.Text
                }, Int32.Parse(accountNumber.Text));

                accountDG.ItemsSource = AccountViewModel.AccountToList();
                contractDG.ItemsSource = ContractViewModel.ContractToList();
                Close();
            }
            else MessageBox.Show("Заполните все поля для ввода", 
                "Ошибка", 
                MessageBoxButton.OK, 
                MessageBoxImage.Warning);
        }

        private void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void Close(object sender, RoutedEventArgs e) => Close();
        private void InvisibleText(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Tag is TextBlock textBlock)
                textBlock.Visibility = !string.IsNullOrEmpty(textBox.Text) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void NoSpacesAllowed(object sender, KeyEventArgs e) =>
            e.Handled = e.Key == Key.Space ? true : false;
        private void AllowNumericCharacters(object sender, TextCompositionEventArgs e) => 
            e.Handled = !(new Regex("[0-9]").IsMatch(e.Text));
    }
}
