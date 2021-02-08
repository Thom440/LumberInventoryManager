using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumberInventoryManager
{
    public class InvoiceLineItems
    {
        [Key]
        public int InvoiceID { get; set; }

        [Key]
        public int ProductID { get; set; }

        /// <summary>
        /// The number of products that is displayed.
        /// </summary>
        [Required]
        public short Quantity { get; set; }

        public Invoice Invoice { get; set; }

        public Product Product { get; set; }
    }
}
