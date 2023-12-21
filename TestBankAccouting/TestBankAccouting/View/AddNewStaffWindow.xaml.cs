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
    /// Логика взаимодействия для AddNewStaffWindow.xaml
    /// </summary>
    public partial class AddNewStaffWindow : Window
    {
        public DataGrid SaveDataGridStaff { get; }

        public AddNewStaffWindow(DataGrid saveDataGridStaff)
        {
            InitializeComponent();
            SaveDataGridStaff = saveDataGridStaff;
        }

        private void AddStaffToDataGrid(object sender, RoutedEventArgs e)
        {
            if (textLastName.Text != string.Empty && 
                textFirstName.Text != string.Empty && 
                textMiddleName.Text != string.Empty && 
                comboBoxGender.Text != string.Empty && 
                textNumberPhone.Text != string.Empty && 
                comboBoxPost.Text != string.Empty)
            {
                if(textNumberPhone.Text.Length == 11)
                {
                    DataStaff.AddStaffToApplicationContext(new Staff(textLastName.Text,
                                                   textFirstName.Text,
                                                   textMiddleName.Text,
                                                   comboBoxGender.Text,
                                                   textNumberPhone.Text,
                                                   comboBoxPost.Text));
                    SaveDataGridStaff.ItemsSource = DataStaff.UpdateStaffToApplicationContext();
                    Close();
                }
                else MessageBox.Show("Введите корректный номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else MessageBox.Show("Заполните все поля для ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ValidationInputTextBoxStaffWindow(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(new Regex("[А-ЯA-Zа-яa-z]").IsMatch(e.Text)); //разрешение ввода только русских и латинских букв
        }

        private void ValidationInputTextBoxNumberPhone(object sender, TextCompositionEventArgs e)
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
