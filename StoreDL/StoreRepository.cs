using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL 

{
    public class StoreRepository : IStoreRepository
    {
        private Entities.jacobmaniscalcoprojectContext _context;
        
        public StoreRepository(Entities.jacobmaniscalcoprojectContext p_context)
        {
            _context = p_context;
        }
        public List<StoreModels.StoreFront> getAllStoreFronts()
        { 
            return _context.StoreFronts.Select(
                store =>
                    new StoreModels.StoreFront()
                    {
                        ID = store.StoreFrontId,
                        Name = store.StoreFrontName,
                        Address = store.StoreFrontAddress
                    }
                ).ToList();
        }
        
        public StoreModels.StoreFront getAStoreFront(int p_storeID)
        { 
            Entities.StoreFront store = _context.StoreFronts.First(store => store.StoreFrontId == p_storeID);

            return new StoreModels.StoreFront()
            {
                ID = store.StoreFrontId,
                Name = store.StoreFrontName,
                Address = store.StoreFrontAddress
            };
        }

        // Think about changing this to return a boolean instead, which can act as a flag for success
        public bool addAStoreFront(StoreModels.StoreFront p_store)
        {
           _context.StoreFronts.Add(new StoreDL.Entities.StoreFront{
               StoreFrontId = p_store.ID,
               StoreFrontName = p_store.Name,
               StoreFrontAddress = p_store.Address
           });

           _context.SaveChanges();
           return true;
        }

        public List<StoreModels.LineItem> GetStoreInventory(int p_storeID)
        {
            var query = _context.StoreFronts.Include("LineItems").Where(store => store.StoreFrontId == p_storeID).ToList();
            var productQuery = _context.Products.ToList();

            List<StoreModels.LineItem> items = new List<StoreModels.LineItem>();
    
            foreach(var store in query)
            {
                foreach(var item in store.LineItems)
                {
                    foreach(var product in productQuery)
                    {
                        if(item.LineItemProductId == product.ProductId)
                        items.Add(
                            new LineItem()
                            {
                                ID = item.LineItemId,
                                Quantity = (int) item.ItemQuantity,
                                Product = new StoreModels.Product()
                                {
                                    ID = product.ProductId,
                                    Name = product.ProductName,
                                    Category = product.ProductCategory,
                                    Description = product.ProductDescription,
                                    Price = (double) product.ProductPrice
                                }
                        });
                    }
                }
            }
            return items;
        }

        public List<StoreModels.Order> GetOrders(int p_storeID)
        {
            
            List<int> orderIDs = new List<int>();

            List<StoreModels.Order> orders = (from order in _context.Orders  where (order.StoreFrontId == p_storeID)
                                                select new StoreModels.Order()
                                                {
                                                    Items = new List<OrderItem>(),
                                                    ID = order.OrderId,
                                                    Location = order.OrderLocation,
                                                    Price = (double) order.OrderPrice,
                                                    StoreID = (int) order.StoreFrontId

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

        public bool addInventory(int p_storeID, int p_lineItemID, int p_Quantity)
        {
            var query = (from item in _context.LineItems where item.StoreFrontId == p_storeID && item.LineItemId == p_lineItemID select item);

            foreach(var item in query)
            {
                item.ItemQuantity += p_Quantity;
            }
            _context.SaveChanges();
            return true;

        }

        public bool removeInventory(int p_storeID, int p_lineItemID, int p_Quantity)
        {
            var query = (from item in _context.LineItems where item.StoreFrontId == p_storeID && item.LineItemId == p_lineItemID select item);

            foreach(var item in query)
            {
                item.ItemQuantity -= p_Quantity;
            }
            _context.SaveChanges();
            return true;
        }

        public StoreModels.LineItem GetLineItem(int p_storeID, int p_lineItemID)
        {
            Entities.StoreFront store = _context.StoreFronts.First(store => store.StoreFrontId == p_storeID);
            Entities.LineItem lineItem  = _context.LineItems.First(item => item.StoreFrontId == p_storeID && item.LineItemProductId == p_lineItemID);
            return new StoreModels.LineItem()
            {
                ID = lineItem.LineItemId,
                Quantity = (int) lineItem.ItemQuantity
            };
        }

        public bool StoreExists(int p_storeID)
        {
            return (from store in _context.StoreFronts where store.StoreFrontId == p_storeID select store).Any();
        }
    }
}