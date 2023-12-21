using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using TestBankAccouting.Data;
using TestBankAccouting.Model;

namespace TestBankAccouting.ViewModel
{
    public static class DataStaff
    {
        public static void AddStaffToApplicationContext(Staff newStaff) 
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                appContext.Staffs.Add(newStaff);
                appContext.SaveChanges();
            }
        }
        public static void DeleteStaffToApplicationContext(int indexOldStaff) 
        {
            if (indexOldStaff != -1)
            {
                using (ApplicationContext appContext = new ApplicationContext())
                {
                    appContext.Staffs.Remove(appContext.Staffs.ElementAt(indexOldStaff));
                    appContext.SaveChanges();
                }
            }    
        }
        public static void EditStaffToApplicationContext(int indexEditStaff, string lastName, string firstName, string middleName, string gender, string numberPhone, string post)
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                appContext.Staffs.ElementAt(indexEditStaff).LastName = lastName;
                appContext.Staffs.ElementAt(indexEditStaff).FirstName = firstName;
                appContext.Staffs.ElementAt(indexEditStaff).MiddleName = middleName;
                appContext.Staffs.ElementAt(indexEditStaff).Post = post;
                appContext.Staffs.ElementAt(indexEditStaff).NumberPhone = numberPhone;
                appContext.Staffs.ElementAt(indexEditStaff).Gender = gender;
                appContext.SaveChanges();
            }
        }

        public static List<Staff> UpdateStaffToApplicationContext()
        {
            using (ApplicationContext appContext = new ApplicationContext())
            {
                return appContext.Staffs.ToList();
            }
        }
    }
}
