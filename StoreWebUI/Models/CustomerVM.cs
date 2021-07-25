using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StoreModels;

namespace StoreWebUI.Models
{
    public class CustomerVM
    {
        [Required]
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        public List<Order> Orders { get; set; }
        
        public CustomerVM()
        { }

        public CustomerVM(Customer p_Customer)
        {
            ID = p_Customer.ID;
            Name = p_Customer.Name;
            Address = p_Customer.Address;
            PhoneNumber = p_Customer.PhoneNumber;
            Orders = p_Customer.Orders;
        } 
    }
}