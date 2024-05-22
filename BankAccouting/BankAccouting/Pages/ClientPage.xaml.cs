using BankAccouting.View;
using BankAccouting.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace BankAccouting.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private readonly DataGrid contractDG;
        private readonly DataGrid accountDG;

        public ClientPage()
        {
            InitializeComponent();
            clientDG.ItemsSource = ClientViewModel.ClientToList();
            accountDG = App.HostService.Services.GetRequiredService<AccountPage>().accountDG;
            contractDG = App.HostService.Services.GetRequiredService<ContractPage>().contractDG;
        }

        private void OpenAddClientWindow(object sender, RoutedEventArgs e) => new AddClientWindow(clientDG).Show();

        private void OpenEditClientWindow(object sender, RoutedEventArgs e)
        {
            if (clientDG.SelectedIndex != -1)
                new EditClientWindow(clientDG).Show();
        }
       
        private async void UseDeleteClientToDb(object sender, RoutedEventArgs e)
        {
            if (clientDG.SelectedIndex != -1)
            {
                await ClientViewModel.DeleteClientToDbAsync(clientDG.SelectedIndex);
                accountDG.ItemsSource = AccountViewModel.AccountToList();
                clientDG.ItemsSource = ClientViewModel.ClientToList();
                contractDG.ItemsSource = ContractViewModel.ContractToList();
            }
        }
    }
}
