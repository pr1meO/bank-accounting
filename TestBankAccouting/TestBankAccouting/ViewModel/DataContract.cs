using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestBankAccouting.Data;
using TestBankAccouting.Model;
using TestBankAccouting.Struct;

namespace TestBankAccouting.ViewModel
{
    public static class DataContract
    {
        public static ObservableCollection<Contract> ContractObservableCollection { get; set; } = new ObservableCollection<Contract>();

        public static void AddContractToObservableCollection(Contract newContract) 
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                appContext.Contracts.Add(newContract);
                appContext.SaveChanges();
            }
            ContractObservableCollection.Add(newContract);
        }
        public static void DeleteContractToObservableCollection(int indexOldContract) 
        {
            if (indexOldContract != -1)
            {
                using (ApplicationContext appContext = new ApplicationContext())
                {
                    appContext.Contracts.Remove(appContext.Contracts.ElementAt(indexOldContract));
                    appContext.SaveChanges();
                }
                ContractObservableCollection.Remove(ContractObservableCollection[indexOldContract]);
            }
        }
        public static void EditContractToObservableCollection(int indexEditContract, int clientID, int staffID, Date dateСonclusion, Time timeСonclusion)
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                appContext.Contracts.ElementAt(indexEditContract).ClientID = clientID;
                appContext.Contracts.ElementAt(indexEditContract).StaffID = staffID;
                appContext.Contracts.ElementAt(indexEditContract).DateСonclusion = dateСonclusion;
                appContext.Contracts.ElementAt(indexEditContract).TimeСonclusion = timeСonclusion;
                appContext.SaveChanges();
            }

            ContractObservableCollection[indexEditContract].ClientID = clientID;
            ContractObservableCollection[indexEditContract].StaffID = staffID;
            ContractObservableCollection[indexEditContract].DateСonclusion = dateСonclusion;
            ContractObservableCollection[indexEditContract].TimeСonclusion = timeСonclusion;
        }
    }
}
