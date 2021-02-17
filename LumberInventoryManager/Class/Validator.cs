using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LumberInventoryManager
{
    /// <summary>
    /// Validates input.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Checks if input is able to be converted to a byte.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks for empty textboxes.
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static bool IsPresent(TextBox box)
        {
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if input is able to be converted to a short.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsShort(string input)
        {
            try
            {
                Convert.ToInt16(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsInt(string input)
        {
            try
            {
                Convert.ToInt32(input);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
