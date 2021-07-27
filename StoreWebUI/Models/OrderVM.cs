using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StoreModels;

namespace StoreWebUI.Models
{
    public class OrderVM
    {
        public StoreModels.Order Order { get; set; }
     
        
        public OrderVM() 
        { }

        public OrderVM(StoreModels.Order p_order)
        {
            Order = p_order;
        }
    }
}