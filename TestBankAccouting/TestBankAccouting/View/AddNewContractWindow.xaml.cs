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
using TestBankAccouting.Struct;
using TestBankAccouting.Data;

namespace TestBankAccouting.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewContractWindow.xaml
    /// </summary>
    public partial class AddNewContractWindow : Window
    {
        public AddNewContractWindow()
        {
            InitializeComponent();
        }

        private void AddContractToDataGrid(object sender, RoutedEventArgs e)
        {
            if (textClientID.Text != string.Empty && textStaffID.Text != string.Empty && textYearСonclusion.Text != string.Empty && textMonthСonclusion.Text != string.Empty && textDayСonclusion.Text != string.Empty && textHourСonclusion.Text != string.Empty && textMinuteСonclusion.Text != string.Empty && textSecondСonclusion.Text != string.Empty)
            {
                if (textYearСonclusion.Text.Length == 4)
                {
                    using (ApplicationContext appContext = new ApplicationContext())
                    {
                        if (appContext.Clients.Any(c => c.ID == Int32.Parse(textClientID.Text)) && appContext.Staffs.Any(s => s.ID == Int32.Parse(textStaffID.Text)))
                        {
                            DataContract.AddContractToObservableCollection(new Contract(Int32.Parse(textClientID.Text),
                                                                                        Int32.Parse(textStaffID.Text),
                                                                           new Date(Int32.Parse(textYearСonclusion.Text),
                                                                                    Int32.Parse(textMonthСonclusion.Text),
                                                                                    Int32.Parse(textDayСonclusion.Text)),
                                                                           new Time(Int32.Parse(textHourСonclusion.Text),
                                                                                    Int32.Parse(textMinuteСonclusion.Text),
                                                                                    Int32.Parse(textSecondСonclusion.Text))));
                            Close();
                        }
                        else MessageBox.Show("Клиент или сотрудник с таким ID не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
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
