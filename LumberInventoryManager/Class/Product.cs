﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumberInventoryManager
{
    /// <summary>
    /// Represents individual unit of lumber.
    /// </summary>
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        /// <summary>
        /// The height of the lumber. ex 2 inches
        /// </summary>
        [Required]
        public byte Height { get; set; }

        /// <summary>
        /// The width of the lumber. ex 4 inches
        /// </summary>
        [Required]
        public byte Width { get; set; }

        /// <summary>
        /// The length of the lumber ex 8 foot
        /// </summary>
        [Required]
        public byte Length { get; set; }

        /// <summary>
        /// The amount in the inventory. Default is zero
        /// </summary>
        public short OnHand { get; set; } = 0;

        /// <summary>
        /// The amount of units sold. Default is zero
        /// </summary>
        public short Sold { get; set; } = 0;

        public override string ToString()
        {
            return Height + " x " + Width + " x " + Length + " In Stock " + OnHand + " Sold " + Sold + " " + String.Join(" ", Category);
        }

        public string InvoiceDisplayString()
        {
            return Height + " x " + Width + " x " + Length + " " + String.Join(" ", Category);
        }

        public List<Category> Category { get; set; } = new List<Category>();

        public virtual List<InvoiceLineItems> InvoiceLineItems { get; set; } = new List<InvoiceLineItems>();
    }
}
