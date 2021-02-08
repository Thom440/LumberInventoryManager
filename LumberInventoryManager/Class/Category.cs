using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumberInventoryManager
{
    /// <summary>
    /// Represents category of lumber.
    /// </summary>
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        /// <summary>
        /// The name of the type of lumber, ie: white wood, decking.
        /// </summary>
        [Required]
        public string CategoryName { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
