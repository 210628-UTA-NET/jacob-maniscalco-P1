using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class LineItem
    {
        public int LineItemId { get; set; }
        public int? StoreFrontId { get; set; }
        public int? LineItemProductId { get; set; }
        public int? ItemQuantity { get; set; }

        public virtual Product LineItemProduct { get; set; }
        public virtual StoreFront StoreFront { get; set; }
    }
}
