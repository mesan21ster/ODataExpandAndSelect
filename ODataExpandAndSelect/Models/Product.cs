﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ODataExpandAndSelect.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}