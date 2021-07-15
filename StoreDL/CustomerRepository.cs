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

        private StoreDBContext _context;
        public CustomerRepository(StoreDBContext p_context)
        {
            _context = p_context;
        }
        public bool AddCustomer(Customer p_customer)
        {
            _context.Customers.Add(p_customer);
            _context.SaveChanges();
            return true;
        }

        public List<StoreModels.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(customer => customer).ToList();
        }

        public StoreModels.Customer GetCustomer(int p_customerID)
        {
            return _context.Customers.FirstOrDefault(customer => customer.ID == p_customerID);
        }

        public bool AddOrder(StoreModels.Order p_order)
        {
            _context.Orders.Add(p_order);
            _context.SaveChanges();
            return true;
        }

        public List<StoreModels.Order> GetOrders(int p_customerID)
        {
            return _context.Orders.Where(order => order.CustomerID == p_customerID).ToList();
        }

        public bool customerExists(int p_customerID)
        {
          return _context.Customers.Any(customer => customer.ID == p_customerID);
        }
    }
}