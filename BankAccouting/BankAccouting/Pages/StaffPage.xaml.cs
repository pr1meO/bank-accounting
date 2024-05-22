using BankAccouting.View;
using BankAccouting.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace BankAccouting.Pages
{
    /// <summary>
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        public StaffPage()
        {
            InitializeComponent();
            staffDG.ItemsSource = StaffViewModel.StaffToList();
        }

        private void OpenAddStaffWindow(object sender, RoutedEventArgs e) => new AddStaffWindow(staffDG).Show();

        private void OpenEditStaffWindow(object sender, RoutedEventArgs e)
        {
            if (staffDG.SelectedIndex != -1)
                new EditStaffWindow(staffDG).Show();
        }

        private async void UseDeleteSatffToDb(object sender, RoutedEventArgs e)
        {
            if (staffDG.SelectedIndex != -1)
            {
                await StaffViewModel.DeleteStaffToDbAsync(staffDG.SelectedIndex);
                staffDG.ItemsSource = StaffViewModel.StaffToList();
            }
        }
    }
}
