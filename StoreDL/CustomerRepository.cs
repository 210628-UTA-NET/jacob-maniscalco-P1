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
        private Entities.jacobmaniscalcoprojectContext _context;

        public CustomerRepository(Entities.jacobmaniscalcoprojectContext p_context)
        {
            _context = p_context;
        }
        public bool AddCustomer(Customer p_customer)
        {
            _context.Customers.Add(new StoreDL.Entities.Customer{
                CustomerId = p_customer.ID,
                CustomerName = p_customer.Name,
                CustomerAddress = p_customer.Address,
                CustomerPhoneNumber = p_customer.PhoneNumber
            });
            _context.SaveChanges();
            return true;
        }

        public List<StoreModels.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                customer =>
                    new StoreModels.Customer()
                    {
                        ID = customer.CustomerId,
                        Name = customer.CustomerName,
                        Address = customer.CustomerAddress,
                        PhoneNumber = customer.CustomerPhoneNumber
                    }
            ).ToList();
        }

        public StoreModels.Customer GetCustomer(int p_customerID)
        {
            var output =  _context.Customers.Find(p_customerID);

            return              
                new StoreModels.Customer()
                {
                     ID = output.CustomerId,
                        Name = output.CustomerName,
                        Address = output.CustomerAddress,
                        PhoneNumber = output.CustomerPhoneNumber
                };
        }

        public bool AddOrder(StoreModels.Order p_order, int p_userID)
        {
            StoreDL.Entities.Order customerOrder = new StoreDL.Entities.Order()
            {
                StoreFrontId = p_order.StoreID,
                CustomerId = p_userID,
                OrderLocation = p_order.Location,
                OrderPrice = (decimal?) p_order.Price
            };
            
          _context.Orders.Add(customerOrder);
          _context.SaveChanges();
          

            foreach(OrderItem product in p_order.Items)
            {
                _context.OrderItems.Add(new StoreDL.Entities.OrderItem()
                {
                    OrderId = customerOrder.OrderId,
                    OrderProductId = product.Product.ID,
            
                    ItemQuantity = product.Quantity
                });
            }

            _context.SaveChanges();

            Console.WriteLine("Customer Order ID: " + customerOrder.OrderId);
            return true;
        }

        public List<StoreModels.Order> GetOrders(int p_customerID)
        {
            List<int> orderIDs = new List<int>();
            List<StoreModels.Order> orders = 
                        ( from order in _context.Orders 
                          where (order.CustomerId == p_customerID)
            select new StoreModels.Order()
            {
                Items = new List<OrderItem>(),
                ID = order.OrderId,
                Location = order.OrderLocation,
                Price = (double) order.OrderPrice,
                
            }).ToList();

            foreach(StoreModels.Order order in orders)
            {
                orderIDs.Add(order.ID);
            }
            
            List<StoreModels.OrderItem> orderItems = 
                ( from orderItem in _context.OrderItems join product in _context.Products on 
                orderItem.OrderProductId equals product.ProductId
                where orderIDs.Contains(orderItem.OrderId)
                select new StoreModels.OrderItem()
                {
                    OrderID = orderItem.OrderId, 
                    Quantity = (int) orderItem.ItemQuantity,
                    Product = new Product()
                    {
                        Name = product.ProductName,
                        ID = product.ProductId,
                        Category = product.ProductCategory,
                        Description = product.ProductDescription,
                        Price = (double) product.ProductPrice
                    }
                }).ToList();
            
            foreach(Order order in orders)
            {
                foreach(OrderItem orderItem in orderItems)
                {
                    if(order.ID == orderItem.OrderID)
                    {
                        order.Items.Add(orderItem);
                    }
                }
            }
            return orders;
        }

        public bool customerExists(int p_customerID)
        {
            return (from customer in _context.Customers where customer.CustomerId == p_customerID select customer).Any();
            
        }
    }
}