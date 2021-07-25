using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StoreModels;

namespace StoreWebUI.Models
{
    public class StoreVM
    {
        [Required]
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public List<LineItem> Inventory { get; set; }
        
        public List<Order> Orders { get; set; }

        public StoreVM()
        { }

        public StoreVM(StoreFront p_store)
        {
            ID = p_store.ID;
            Name = p_store.Name;
            Address = p_store.Address;
            Inventory = p_store.Inventory;
            Orders = p_store.Orders;
        }
    }
}