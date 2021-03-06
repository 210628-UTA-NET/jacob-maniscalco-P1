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

        private readonly StoreDBContext _context;
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

        public StoreModels.Customer GetCustomer(int p_CustomerID)
        {
            return _context.Customers.Include("Orders").FirstOrDefault(customer => customer.ID == p_CustomerID);
        }
        public StoreModels.Customer GetCustomer(string p_CustomerName)
        {
            return _context.Customers.Include(customer => customer.Orders).ThenInclude(order => order.Items).ThenInclude(product => product.Product).FirstOrDefault(customer => customer.Name == p_CustomerName);
        }

        public StoreModels.Customer GetCustomerAll(int p_CustomerID)
        {
            return _context.Customers.Include(customer => customer.Orders).ThenInclude(order => order.Items).ThenInclude(product => product.Product).FirstOrDefault(customer => customer.ID == p_CustomerID);
        }
        public StoreModels.Customer GetCustomerAll(string p_CustomerName)
        {
            return _context.Customers.Include(customer => customer.Orders).ThenInclude(order => order.Items).ThenInclude(product => product.Product).FirstOrDefault(customer => customer.Name == p_CustomerName);
        }

        public bool AddOrder(StoreModels.Order p_order)
        {
            _context.Orders.Add(p_order);
            _context.SaveChanges();
            return true;
        }

        public List<StoreModels.Order> GetOrders(int p_CustomerID)
        {
            return _context.Orders.Where(order => order.CustomerID == p_CustomerID).ToList();
        }

        public bool customerExists(int p_customerID)
        {
          return _context.Customers.Any(customer => customer.ID == p_customerID);
        }
        public StoreModels.Customer UpdateCustomer(StoreModels.Customer p_customer)
        {
            var cust = _context.Customers.FirstOrDefault(updatedCustomer => updatedCustomer.ID == p_customer.ID);
            cust.Name = p_customer.Name;
            cust.Address = p_customer.Address;
            cust.PhoneNumber = p_customer.PhoneNumber;
            _context.Customers.Update(cust);
            _context.SaveChanges();
            return p_customer;
        }

        public StoreModels.Order createOrder(StoreModels.Order p_order)
        {
            _context.Orders.Add(p_order);
            _context.SaveChanges();
            return p_order;
        }

        public StoreModels.OrderItem AddOrderItem(StoreModels.OrderItem p_OrderItem)
        {
            _context.OrderItems.Add(p_OrderItem);
            _context.SaveChanges();
            return p_OrderItem;
        }
        public StoreModels.Order GetOrder(int p_OrderID)
        {
            StoreModels.Order order = _context.Orders.Include(order => order.Items).ThenInclude(item => item.Product).FirstOrDefault(order => order.ID == p_OrderID);
            return order;
        }
         public StoreModels.Order SetOrderPrice(int p_OrderID, double p_price)
        {
            StoreModels.Order order = _context.Orders.FirstOrDefault(order => order.ID == p_OrderID);
            order.Price = p_price;
            _context.SaveChanges();
            return order;
        }
    }
}