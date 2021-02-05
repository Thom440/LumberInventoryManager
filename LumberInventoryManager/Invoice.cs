using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumberInventoryManager
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Required]
        public int InvoiceNumber { get; set; }

        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ShipDate { get; set; }

        public IList<InvoiceLineItems> InvoiceLineItems { get; set; }
    }
}
