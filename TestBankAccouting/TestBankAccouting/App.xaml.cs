using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Configuration;
using System.Data;
using System.Windows;
using TestBankAccouting.Data;

namespace TestBankAccouting
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade databaseFacadeBankAccouting = new DatabaseFacade(new ApplicationContext());
            databaseFacadeBankAccouting.EnsureCreated(); //создание БД, если ее нет в СУБД

            DatabaseFacade databaseFacadeUsers = new DatabaseFacade(new ApplicationContextUsers());
            databaseFacadeUsers.EnsureCreated(); //создание БД, если ее нет в СУБД
        }
    }

}
