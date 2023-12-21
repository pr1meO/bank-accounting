 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankAccouting.Struct
{
    public struct Date
    {
        private int year;
        private int month;
        private int day;

        public int Year 
        {
            get => year;
            set => year = value <= 2021 ? 2023 : value;
        }
        public int Month
        {
            get => month;
            set
            {
                if(value <= 0 || value > 12)
                    month = 12;
                else month = value;
            }
        }
        public int Day
        {
            get => day;
            set
            {
                if (value <= 0 || value > 31)
                    day = 31;
                else day = value;
            }
        }

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public override string ToString() => $"{Day}.{Month}.{Year}";
    }
}
