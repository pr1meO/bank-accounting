using BankAccouting.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        public DataGrid StaffDG { get; private set; }

        public EditStaffWindow(DataGrid staffDG)
        {
            InitializeComponent();
            StaffDG = staffDG;
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

        private async void UseEditStaffToDb(object sender, RoutedEventArgs e)
        {
            if (lastName.Text != string.Empty &&
                firstName.Text != string.Empty &&
                middleName.Text != string.Empty &&
                phoneNumber.IsMaskCompleted)
            {
                await StaffViewModel.EditStaffToDbAsync(
                    StaffDG.SelectedIndex,
                    lastName.Text,
                    firstName.Text,
                    middleName.Text,
                    phoneNumber.Text,
                    gender.Text,
                    role.SelectedIndex);

                StaffDG.ItemsSource = StaffViewModel.StaffToList();
                Close();
            }
            else MessageBox.Show("Заполните все поля для ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
