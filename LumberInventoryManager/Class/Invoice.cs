﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumberInventoryManager
{
    /// <summary>
    /// Represents the order.
    /// </summary>
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Required]
        public int InvoiceNumber { get; set; }

        /// <summary>
        /// The date the order was placed.
        /// </summary>
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// The date the order has shipped. (nullable)
        /// </summary>
        [Column(TypeName = "smalldatetime")]
        public DateTime? ShipDate { get; set; }

        public IList<InvoiceLineItems> InvoiceLineItems { get; set; }
    }
}