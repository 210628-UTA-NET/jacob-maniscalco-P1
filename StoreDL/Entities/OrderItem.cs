using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int OrderProductId { get; set; }
        public int? ItemQuantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product OrderProduct { get; set; }
    }
}
