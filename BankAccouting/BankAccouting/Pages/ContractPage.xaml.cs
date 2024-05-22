using BankAccouting.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace BankAccouting.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Page
    {
        public ContractPage()
        {
            InitializeComponent();
            contractDG.ItemsSource = ContractViewModel.ContractToList();
        }

        private async void UseDeleteContractToDbAsync(object sender, RoutedEventArgs e)
        {
            if (contractDG.SelectedIndex != -1)
            {
                await ContractViewModel.DeleteContractToDbAsync(contractDG.SelectedIndex);
                contractDG.ItemsSource = ContractViewModel.ContractToList();
            }
        }
    }
}
