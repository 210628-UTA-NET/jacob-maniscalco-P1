using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StoreModels;

namespace StoreWebUI.Models
{
    public class OrderItemVM
    {
        public StoreModels.OrderItem Item{ get; set; }
     
        public StoreModels.StoreFront StoreFront { get; set; }
        
        public OrderItemVM() 
        { }

        public OrderItemVM(StoreModels.OrderItem p_item, StoreModels.StoreFront p_store)
        {
            Item = p_item;
            StoreFront = p_store;
        }
    }
}