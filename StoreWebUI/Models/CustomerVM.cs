using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreWebUI.Models
{
    public class CustomerVM
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
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