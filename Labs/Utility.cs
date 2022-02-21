using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1___Average_Units_Shipped___Dylan_Bharat
{
    internal class Utility
    {
        public static Boolean isInterger(string input )
        {
            int number;
            return Int32.TryParse(input, out number);
        }

        public static Boolean isInRange(int min, int max, string input)
        {
            int number;
            if (Int32.TryParse(input, out number))
            {
                return min <= number && number <= max;
            }
            return false;
        }

        public static Boolean isNumber(KeyEventArgs e)
        {
            return false;
        }
    }
}
