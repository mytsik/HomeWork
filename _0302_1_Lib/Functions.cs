using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace _0302_1_Lib
{
    public class Functions
    {        
        public bool DBConnection(string connStr)
        {
            
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connStr);                                
                return true;                                
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;            
        }

        public bool IsValidPhoneNumber(string number)
        {
            string pattern = @"^8-[9]\d{2}-\d{3}-\d{2}-\d{2}$";
            return System.Text.RegularExpressions.Regex.IsMatch(number, pattern);
        }
    }
}
