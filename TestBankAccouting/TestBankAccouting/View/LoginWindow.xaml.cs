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
using TestBankAccouting.ViewModel;

namespace TestBankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OpenWindowToPassword(object sender, RoutedEventArgs e)
        {
            if(textUsername.Text != string.Empty && textPassword.Password != string.Empty)
            {
                DataUser.SelectWindowToOpenPassword(textUsername.Text, textPassword.Password, this);
            }
            else MessageBox.Show("Заполните поля для ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ValidationInputTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(new Regex("[A-Za-z]").IsMatch(e.Text)); //разрешение ввода только латинских букв
        }

        private void ProhibitingSpaceTextBox(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
    }
}
