﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumberInventoryManager
{
    /// <summary>
    /// Represents an individual customer.
    /// </summary>
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        /// <summary>
        /// If applicable, the name of the business. (nullable)
        /// </summary>
        public string Business { get; set; }

        /// <summary>
        /// First name of the customer or business.
        /// </summary>
        [Required]
        public string ContactFirstName { get; set; }

        /// <summary>
        /// Last name of the customer or business.
        /// </summary>
        [Required]
        public string ContactLastName { get; set; }

        /// <summary>
        /// Street Address.
        /// </summary>
        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public Int16 ZipCode { get; set; }

        public Invoice Invoice { get; set; }
    }
}
