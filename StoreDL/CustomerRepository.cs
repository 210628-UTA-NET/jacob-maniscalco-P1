using System;
using System.Collections.Generic;
using StoreModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace StoreDL
{
    public class CustomerRepository : ICustomerRepository
    {

        public CustomerRepository()
        {
            
        }
        public bool AddCustomer(Customer p_customer)
        {
            throw new NotImplementedException();
        }

        public List<StoreModels.Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public StoreModels.Customer GetCustomer(int p_customerID)
        {
            throw new NotImplementedException();
        }

        public bool AddOrder(StoreModels.Order p_order, int p_userID)
        {
            throw new NotImplementedException();
        }

        public List<StoreModels.Order> GetOrders(int p_customerID)
        {
            throw new NotImplementedException();
        }

        public bool customerExists(int p_customerID)
        {
          throw new NotImplementedException();
        }
    }
}