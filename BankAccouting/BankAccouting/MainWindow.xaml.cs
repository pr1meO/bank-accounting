using BankAccouting.Models;
using BankAccouting.Pages;
using BankAccouting.View;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankAccouting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StaffPage _staffPage;
        private readonly ClientPage _clientPage;
        private readonly AccountPage _accountPage;
        private readonly ContractPage _contractPage;
        private readonly LoginWindow _loginWindow;

        public static Staff? Staff { get; private set; }

        public MainWindow(Staff staff)
        {
            InitializeComponent();
            _staffPage = App.HostService.Services.GetRequiredService<StaffPage>();
            _clientPage = App.HostService.Services.GetRequiredService<ClientPage>();
            _accountPage = App.HostService.Services.GetRequiredService<AccountPage>();
            _contractPage = App.HostService.Services.GetRequiredService<ContractPage>();
            _loginWindow = App.HostService.Services.GetRequiredService<LoginWindow>();
            frame.Content = _staffPage;

            Staff = staff;
            staffName.Text = $"{Staff?.Lastname} {Staff?.Firstname}";
            staffRole.Text = Staff?.Role?.Name;
        }

        private void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void Close(object sender, RoutedEventArgs e) => Close();
        private void Minimize(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void OpenStaffPage(object sender, RoutedEventArgs e) => frame.Content = _staffPage; 
        private void OpenClientPage(object sender, RoutedEventArgs e) => frame.Content = _clientPage;
        private void OpenAccountPage(object sender, RoutedEventArgs e) => frame.Content = _accountPage;
        private void OpenContractPage(object sender, RoutedEventArgs e) => frame.Content = _contractPage;
        private void OpenLoginWindow(object sender, RoutedEventArgs e)
        {
            _loginWindow.Show();
            Close();
        }
    }
}