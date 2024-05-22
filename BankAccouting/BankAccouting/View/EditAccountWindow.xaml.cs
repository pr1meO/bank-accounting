using BankAccouting.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для EditAccountWindow.xaml
    /// </summary>
    public partial class EditAccountWindow : Window
    {
        public DataGrid AccountDG { get; private set; }

        public EditAccountWindow(DataGrid accountDG)
        {
            InitializeComponent();
            AccountDG = accountDG;
        }

        private async void UseEditAccountToDbAsync(object sender, RoutedEventArgs e)
        {
            if (balance.Text != string.Empty)
            {
                await AccountViewModel.EditAccountToDbAsync(
                    AccountDG.SelectedIndex, 
                    balance.Text, 
                    cbTypeAccount.Text);

                AccountDG.ItemsSource = AccountViewModel.AccountToList();
                Close();
            }
            else MessageBox.Show("Заполните все поля для ввода", 
                "Ошибка", 
                MessageBoxButton.OK, 
                MessageBoxImage.Warning);
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
        private void AllowNumericCharacters(object sender, TextCompositionEventArgs e) =>
            e.Handled = !(new Regex("[0-9]").IsMatch(e.Text));
    }
}
