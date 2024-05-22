using BankAccouting.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginWindow(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            _loginViewModel = loginViewModel;
        }

        private async void UseSearchCredentialToDbAsync(object sender, RoutedEventArgs e)
        {
            if (login.Text != string.Empty && password.Password != string.Empty)
            {
                await _loginViewModel.SearchCredentialToDbAsync(login.Text, password.Password, this);
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
        private void InvisibleLogin(object sender, TextChangedEventArgs e) =>
            txtLogin.Visibility = !string.IsNullOrEmpty(login.Text) ? Visibility.Collapsed : Visibility.Visible;
        private void InvisiblePassword(object sender, RoutedEventArgs e) =>
            txtPassword.Visibility = !string.IsNullOrEmpty(password.Password) ? Visibility.Collapsed : Visibility.Visible;
        private void NoSpacesAllowed(object sender, KeyEventArgs e) =>
            e.Handled = e.Key == Key.Space ? true : false;
    }
}
