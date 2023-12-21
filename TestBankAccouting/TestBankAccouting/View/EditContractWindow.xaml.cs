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
using TestBankAccouting.Struct;
using TestBankAccouting.ViewModel;

namespace TestBankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для EditContractWindow.xaml
    /// </summary>
    public partial class EditContractWindow : Window
    {
        public DataGrid SaveDataGridContract { get; }

        public EditContractWindow(DataGrid saveDataGridContract)
        {
            InitializeComponent();
            SaveDataGridContract = saveDataGridContract;
        }

        private void EditContractToDataGrid(object sender, RoutedEventArgs e)
        {
            if (textClientID.Text != string.Empty && textStaffID.Text != string.Empty && textYearСonclusion.Text != string.Empty && textMonthСonclusion.Text != string.Empty && textDayСonclusion.Text != string.Empty && textHourСonclusion.Text != string.Empty && textMinuteСonclusion.Text != string.Empty && textSecondСonclusion.Text != string.Empty)
            {
                if(textYearСonclusion.Text.Length == 4)
                {
                    DataContract.EditContractToObservableCollection(SaveDataGridContract.SelectedIndex,
                                                    Int32.Parse(textClientID.Text),
                                                    Int32.Parse(textStaffID.Text),
                                                    new Date(Int32.Parse(textDayСonclusion.Text),
                                                             Int32.Parse(textMonthСonclusion.Text),
                                                             Int32.Parse(textYearСonclusion.Text)),
                                                    new Time(Int32.Parse(textHourСonclusion.Text),
                                                             Int32.Parse(textMinuteСonclusion.Text),
                                                             Int32.Parse(textSecondСonclusion.Text)));
                    SaveDataGridContract.Items.Refresh();
                    Close();
                }
                else MessageBox.Show("Год должен состоять из четырех цифр", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else MessageBox.Show("Заполните все поля для ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ValidationInputTextBox(object sender, TextCompositionEventArgs e)
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
