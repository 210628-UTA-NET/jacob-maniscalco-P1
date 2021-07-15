using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? StoreFrontId { get; set; }
        public string OrderLocation { get; set; }
        public decimal? OrderPrice { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreFront StoreFront { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
