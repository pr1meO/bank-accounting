using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestBankAccouting.Data;
using TestBankAccouting.Model;
using TestBankAccouting.View;

namespace TestBankAccouting.ViewModel
{
    public static class DataAccount
    {
        public static void AddAccountToApplicationContext(Account newAccount) 
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                appContext.Accounts.Add(newAccount);
                appContext.SaveChanges();
            }
        }
        public static void DeleteAccountToApplicationContext(int indexOldAccount) 
        {
            if (indexOldAccount != -1)
            {
                using (ApplicationContext appContext = new ApplicationContext())
                {
                    appContext.Accounts.Remove(appContext.Accounts.ElementAt(indexOldAccount));
                    appContext.SaveChanges();
                }
            }
        }
        public static void EditAccountToApplicationContext(int indexEditAccount, double balance, string typeAccount)
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                appContext.Accounts.ElementAt(indexEditAccount).Balance = balance;
                appContext.Accounts.ElementAt(indexEditAccount).TypeAccount = typeAccount;
                appContext.SaveChanges();
            }
        }

        public static List<Account> UpdateAccountToApplicationContext()
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                return appContext.Accounts.ToList();
            }
        }
    }
}