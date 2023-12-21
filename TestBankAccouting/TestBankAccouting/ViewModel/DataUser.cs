using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestBankAccouting.Data;
using TestBankAccouting.Model;
using TestBankAccouting.View;

namespace TestBankAccouting.ViewModel
{
    static public class DataUser
    {
        public static void SelectWindowToOpenPassword(string userName, string password, Window LoginWindow)
        {
            using (ApplicationContextUsers appContextUsers = new ApplicationContextUsers())
            {
                User user = new User()
                {
                    RoleID = appContextUsers.Users.Where(u => u.Login == userName && u.Password == password)
                                                  .Select(u => u.RoleID)
                                                  .SingleOrDefault()
                };

                if(user.RoleID is not null)
                {
                    OpenWindowWithPassword(user.RoleID);
                    LoginWindow.Close();
                }
                else MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private static void OpenWindowWithPassword(int? roleID)
        {
            switch (roleID)
            {
                case 1:
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    break;
                case 2:
                    ClientManagerWindow clientManagerWindow = new ClientManagerWindow();
                    clientManagerWindow.Show();
                    break;
            }
        }
    }
}
