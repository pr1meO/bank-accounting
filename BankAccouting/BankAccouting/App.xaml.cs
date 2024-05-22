using BankAccouting.Models;
using BankAccouting.Pages;
using BankAccouting.View;
using BankAccouting.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using System.Windows.Controls;

namespace BankAccouting
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost HostService { get; private set; }

        static App()
        {
            HostService = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<AppDbContext>();

                    services.AddTransient<MainWindow>();
                    services.AddTransient<LoginViewModel>();
                    services.AddTransient<LoginWindow>();

                    services.AddSingleton<StaffPage>();
                    services.AddSingleton<ClientPage>();
                    services.AddSingleton<AccountPage>();
                    services.AddSingleton<ContractPage>();
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var loginWindow = HostService.Services.GetRequiredService<LoginWindow>();
            loginWindow.Show();

            base.OnStartup(e);
        }
    }

}
