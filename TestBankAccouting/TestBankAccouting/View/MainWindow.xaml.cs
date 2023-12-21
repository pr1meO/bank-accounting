using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestBankAccouting.Data;
using TestBankAccouting.Model;
using TestBankAccouting.View;
using TestBankAccouting.ViewModel;

namespace TestBankAccouting.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (ApplicationContext appContext = new ApplicationContext())
            {
                dataGridStaff.ItemsSource = appContext.Staffs.ToList();
                dataGridClient.ItemsSource = appContext.Clients.ToList();
                dataGridAccount.ItemsSource = appContext.Accounts.ToList();
                dataGridContract.ItemsSource = DataContract.ContractObservableCollection;
            }
        }

        //--------------------------------STAFF--------------------------------
        private void OpenAddNewStaffWindow(object sender, RoutedEventArgs e)
        {
            AddNewStaffWindow newStaffWindow = new AddNewStaffWindow(dataGridStaff);
            newStaffWindow.Show();
        }
        private void DeleteStaffToDataGrid(object sender, RoutedEventArgs e)
        {
            DataStaff.DeleteStaffToApplicationContext(dataGridStaff.SelectedIndex);
            dataGridStaff.ItemsSource = DataStaff.UpdateStaffToApplicationContext();
        }
        private void OpenEditStaffWindow(object sender, RoutedEventArgs e)
        {
            if (dataGridStaff.SelectedIndex != -1)
            {
                EditStaffWindow editStaffWindow = new EditStaffWindow(dataGridStaff);
                editStaffWindow.Show();
            }
        }
        //--------------------------------STAFF--------------------------------

        //--------------------------------CLIENT--------------------------------
        private void OpenAddNewClientWindow(object sender, RoutedEventArgs e)
        {
            AddNewClientWindow newClientWindow = new AddNewClientWindow(dataGridAccount, dataGridClient);
            newClientWindow.Show();
        }
        private void DeleteClientToDataGrid(object sender, RoutedEventArgs e)
        {
            DataClient.DeleteClientToApplicationContext(dataGridClient.SelectedIndex);
            dataGridClient.ItemsSource = DataClient.UpdateClientToApplicationContext();
        }
        private void OpenEditClientWindow(object sender, RoutedEventArgs e)
        {
            if (dataGridClient.SelectedIndex != -1) 
            {
                EditClientWindow editClientWindow = new EditClientWindow(dataGridClient);
                editClientWindow.Show();
            }
        }
        //--------------------------------CLIENT--------------------------------

        //--------------------------------ACCOUNT--------------------------------
        private void DeleteAccountToDataGrid(object sender, RoutedEventArgs e)
        {
            DataAccount.DeleteAccountToApplicationContext(dataGridAccount.SelectedIndex);
            dataGridAccount.ItemsSource = DataAccount.UpdateAccountToApplicationContext();
        }
        private void OpenEditAccountWindow(object sender, RoutedEventArgs e)
        {
            if (dataGridAccount.SelectedIndex != -1)
            {
                EditAccountWindow editAccountWindow = new EditAccountWindow(dataGridAccount);
                editAccountWindow.Show();
            }
        }
        //--------------------------------ACCOUNT--------------------------------

        //--------------------------------CONTRACT--------------------------------
        private void OpenAddNewContractWindow(object sender, RoutedEventArgs e)
        {
            AddNewContractWindow newContractWindow = new AddNewContractWindow();
            newContractWindow.Show();
        }
        private void DeleteContractToDataGrid(object sender, RoutedEventArgs e)
        {
            DataContract.DeleteContractToObservableCollection(dataGridContract.SelectedIndex);
        }
        private void OpenEditContractWindow(object sender, RoutedEventArgs e)
        {
            if (dataGridContract.SelectedIndex != -1)
            {
                EditContractWindow editContractWindow = new EditContractWindow(dataGridContract);
                editContractWindow.Show();
            }
        }
        //--------------------------------CONTRACT--------------------------------
    }
}