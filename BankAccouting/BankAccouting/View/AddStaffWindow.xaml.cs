using BankAccouting.Models;
using BankAccouting.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        private readonly DataGrid staffDG;

        public AddStaffWindow(DataGrid staffDG)
        {
            InitializeComponent();
            this.staffDG = staffDG;
        }

        private async void UseAddStaffToDb(object sender, RoutedEventArgs e)
        {
            if (lastName.Text != string.Empty &&
                firstName.Text != string.Empty &&
                middleName.Text != string.Empty &&
                phoneNumber.IsMaskCompleted)
            {
                await StaffViewModel.AddStaffToDbAsync(new Staff
                {
                    Lastname = lastName.Text,
                    Firstname = firstName.Text,
                    Middlename = middleName.Text,
                    PhoneNumber = phoneNumber.Text,
                    Gender = gender.Text,
                    RoleId = ++role.SelectedIndex
                });

                staffDG.ItemsSource = StaffViewModel.StaffToList();
                Close();
            }
            else MessageBox.Show("Заполните все поля для ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
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
