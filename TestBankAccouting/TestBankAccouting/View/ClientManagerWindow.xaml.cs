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
using System.Windows.Shapes;
using TestBankAccouting.Data;
using TestBankAccouting.ViewModel;

namespace TestBankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для ClientManagerWindow.xaml
    /// </summary>
    public partial class ClientManagerWindow : Window
    {
        public ClientManagerWindow()
        {
            InitializeComponent();
            using (ApplicationContext appContext = new ApplicationContext())
            {
                dataGridClient.ItemsSource = appContext.Clients.ToList();
                dataGridAccount.ItemsSource = appContext.Accounts.ToList();
            }
        }

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
    }
}
