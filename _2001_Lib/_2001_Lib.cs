using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2001_Lib
{
    public class DateTimeFunctions
    {
        public string TwoDatesDifference(DateTime date1, DateTime date2)
        {
            var dateDif = date1 - date2;
            return $"Разница составляет: {dateDif.Days} дн(ей/я)";
        }

        public bool LeapYear(int date)
        {
            return DateTime.IsLeapYear(date);
        }

        public string TimeOfDay(DateTime time)
        {
            if ((5 <= time.Hour) && (time.Hour < 12))
            {
                return "Утро";
            }
            else if ((12 <= time.Hour) && (time.Hour < 17))
            {
                return "День";
            }
            else if ((17 <= time.Hour) && (time.Hour < 23))
            {
                return "Вечер";
            }
            else
            {
                return "Ночь";
            }
        }

        public string DateTimeFormat(DateTime dateTime)
        {
            return dateTime.ToString("dd.MM.yyyy HH:mm:ss");
        }
    }
}
