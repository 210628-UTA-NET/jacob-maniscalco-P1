using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            LineItems = new HashSet<LineItem>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public decimal? ProductPrice { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
