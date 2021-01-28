using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LumberInventoryManager
{
    public static class Validator
    {
        public static bool IsByte(string input)
        {
            try
            {
                Convert.ToByte(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPresent(TextBox box)
        {
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                return false;
            }
            return true;
        } 
    }
}
