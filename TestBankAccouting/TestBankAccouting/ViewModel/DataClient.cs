using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TestBankAccouting.Data;
using TestBankAccouting.Model;
using TestBankAccouting.View;
using TestBankAccouting.ViewModel;

namespace TestBankAccouting.ViewModel
{
    public class DataClient
    {
        public static void AddClientToApplicationContext(Client newClient) 
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                appContext.Clients.Add(newClient);
                appContext.SaveChanges();
            }
        }
        public static void DeleteClientToApplicationContext(int indexOldClient)
        {
            if (indexOldClient != -1)
            {
                using (ApplicationContext appContext = new ApplicationContext())
                {
                    appContext.Clients.Remove(appContext.Clients.ElementAt(indexOldClient));
                    appContext.SaveChanges();
                }
            }
        }
        public static void EditClientToApplicationContext(int indexEditClient, string lastName, string firstName, string middleName, string gender, string numberPhone)
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                appContext.Clients.ElementAt(indexEditClient).LastName = lastName;
                appContext.Clients.ElementAt(indexEditClient).FirstName = firstName;
                appContext.Clients.ElementAt(indexEditClient).MiddleName = middleName;
                appContext.Clients.ElementAt(indexEditClient).NumberPhone = numberPhone;
                appContext.Clients.ElementAt(indexEditClient).Gender = gender;
                appContext.SaveChanges();
            }
        }

        public static List<Client> UpdateClientToApplicationContext()
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                return appContext.Clients.ToList();
            }
        }
    }
}

