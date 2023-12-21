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
using TestBankAccouting.View;
using TestBankAccouting.ViewModel;

namespace TestBankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для EditAccountWindow.xaml
    /// </summary>
    public partial class EditAccountWindow : Window
    {
        public DataGrid SaveDataGridAccount { get; }

        public EditAccountWindow(DataGrid saveDataGridAccount)
        {
            InitializeComponent();
            SaveDataGridAccount = saveDataGridAccount;
        }

        private void EditAccountToDataGrid(object sender, RoutedEventArgs e)
        {
            if (textBalance.Text != string.Empty && comboBoxTypeAccount.Text != string.Empty)
            {
                DataAccount.EditAccountToApplicationContext(SaveDataGridAccount.SelectedIndex, Double.Parse(textBalance.Text), comboBoxTypeAccount.Text);
                SaveDataGridAccount.ItemsSource = DataAccount.UpdateAccountToApplicationContext();
                Close();
            }
            else MessageBox.Show("Заполните все поля для ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ValidationInputTextBoxWindow(object sender, TextCompositionEventArgs e)
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
