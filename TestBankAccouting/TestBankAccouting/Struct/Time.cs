using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankAccouting.Struct
{
    public struct Time
    {
        private int hour;
        private int minute;
        private int second;

        public int Hour
        {
            get => hour;
            set
            {
                if (value < 0 || value > 23)
                    hour = 23;
                else hour = value;
            }
        }
        public int Minute
        {
            get => minute;
            set
            {
                if (value < 0 || value > 59)
                    minute = 59;
                else minute = value;
            }
        }
        public int Second
        {
            get => second;
            set
            {
                if (value < 0 || value > 59)
                    second = 59;
                else second = value;
            }
        }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public override string ToString() => $"{Hour}:{Minute}:{Second}";
    }
}
