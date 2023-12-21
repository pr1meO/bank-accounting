using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        public DataGrid SaveDataGridStaff { get; }

        public EditStaffWindow(DataGrid saveDataGridStaff)
        {
            InitializeComponent();
            SaveDataGridStaff = saveDataGridStaff;
        }

        private void EditStaffToDataGrid(object sender, RoutedEventArgs e)
        {
            if (textLastName.Text != string.Empty && textFirstName.Text != string.Empty && textMiddleName.Text != string.Empty && comboBoxGender.Text != string.Empty && textNumberPhone.Text != string.Empty && comboBoxPost.Text != string.Empty)
            {
                if(textNumberPhone.Text.Length == 11)
                {
                    DataStaff.EditStaffToApplicationContext(SaveDataGridStaff.SelectedIndex, textLastName.Text, textFirstName.Text, textMiddleName.Text, comboBoxGender.Text, textNumberPhone.Text, comboBoxPost.Text);
                    SaveDataGridStaff.ItemsSource = DataStaff.UpdateStaffToApplicationContext();
                    Close();
                }
                else MessageBox.Show("Введите корректный номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else MessageBox.Show("Заполните все поля для ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ValidationInputTextBox(object sender, TextCompositionEventArgs e)
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
