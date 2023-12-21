using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestBankAccouting.Model;
using TestBankAccouting.ViewModel;

namespace TestBankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : Window
    {
        public AddNewAccountWindow? NewAccountWindow { get; set; }
        public DataGrid SaveDataGridClient { get; }
        public DataGrid SaveDataGridAccount { get; }

        public AddNewClientWindow(DataGrid saveDataGridAccount, DataGrid saveDataGridClient)
        {
            InitializeComponent();
            SaveDataGridClient = saveDataGridClient;
            SaveDataGridAccount = saveDataGridAccount;
        }

        private void AddClientToDataGrid(object sender, RoutedEventArgs e)
        {
            if (textLastName.Text != string.Empty && textFirstName.Text != string.Empty && textMiddleName.Text != string.Empty && comboBoxGender.Text != string.Empty && textNumberPhone.Text != string.Empty)
            {
                if(textNumberPhone.Text.Length == 11)
                {
                    Client newClient = new Client(textLastName.Text, textFirstName.Text, textMiddleName.Text, comboBoxGender.Text, textNumberPhone.Text);
                    DataClient.AddClientToApplicationContext(newClient);
                    SaveDataGridClient.ItemsSource = DataClient.UpdateClientToApplicationContext();
                    Close();
                    //--------------------------------ACCOUNT--------------------------------
                    NewAccountWindow = new AddNewAccountWindow(SaveDataGridAccount, newClient);
                    NewAccountWindow.Show();
                    //--------------------------------ACCOUNT--------------------------------
                }
                else MessageBox.Show("Введите корректный номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else MessageBox.Show("Заполните все поля для ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ValidationInputTextBoxClientWindow(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(new Regex("[А-ЯA-Zа-яa-z]").IsMatch(e.Text)); //разрешение ввода только русских и латинских букв
        }

        private void ValidationInputTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(new Regex("[0-9]").IsMatch(e.Text)); //разрешение ввода только цифр
        }

        private void ProhibitingSpaceTextBox(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
    }
}
