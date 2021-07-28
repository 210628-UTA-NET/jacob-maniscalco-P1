using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StoreModels;

namespace StoreWebUI.Models
{
    public class CustomerOrdersVM
    {
        public List<StoreModels.Order> Orders { get; set; }
     
        
        public CustomerOrdersVM() 
        { }

        public CustomerOrdersVM(List<StoreModels.Order> p_orders)
        {
            Orders = p_orders;
        }
    }
}