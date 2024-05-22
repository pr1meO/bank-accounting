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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private readonly DataGrid clientDG;
        private readonly DataGrid accountDG;

        public AddClientWindow(DataGrid clientDG)
        {
            InitializeComponent();
            this.clientDG = clientDG;
            accountDG = App.HostService.Services.GetRequiredService<AccountPage>().accountDG;
        }

        private async void UseAddClientToDb(object sender, RoutedEventArgs e)
        {
            if (lastName.Text != string.Empty &&
                firstName.Text != string.Empty &&
                middleName.Text != string.Empty &&
                phoneNumber.IsMaskCompleted)
            {
                var client = new Client
                {
                    Lastname = lastName.Text,
                    Firstname = firstName.Text,
                    Middlename = middleName.Text,
                    PhoneNumber = phoneNumber.Text,
                    Gender = gender.Text
                };

                await ClientViewModel.AddClientToDbAsync(client);
                clientDG.ItemsSource = ClientViewModel.ClientToList();

                new AddAccountWindow(accountDG, client).Show();
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
        private void AllowAlphabeticCharacters(object sender, TextCompositionEventArgs e) =>
            e.Handled = !new Regex("[А-ЯA-Zа-яa-z]").IsMatch(e.Text);
    }
}
