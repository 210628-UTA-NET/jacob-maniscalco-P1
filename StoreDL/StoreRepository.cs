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
       
        private readonly StoreDBContext _context;
        public StoreRepository(StoreDBContext p_context)
        {
            _context = p_context;
        }
        public List<StoreModels.StoreFront> getAllStoreFronts()
        { 
           return _context.StoreFronts.Select(store => store).ToList();
        }
        
        public StoreModels.StoreFront getAStoreFront(int p_StoreID)
        { 
           return _context.StoreFronts.FirstOrDefault(store => store.ID == p_StoreID);
        }

        public StoreModels.StoreFront GetStoreFrontAll(int p_StoreID)
        {
            return _context.StoreFronts.Include(store => store.Inventory).Include(store => store.Orders).ThenInclude(order => order.Items).ThenInclude(item => item.Product).FirstOrDefault(store => store.ID == p_StoreID);
        }
        public bool addAStoreFront(StoreModels.StoreFront p_store)
        {
            _context.StoreFronts.Add(p_store);
            _context.SaveChanges();
            return true;
        }

        public List<StoreModels.LineItem> GetStoreInventory(int p_storeID)
        {
           return _context.LineItems.Include(store => store.Product).Where(item => item.StoreFrontID == p_storeID).ToList();
        }

        public List<StoreModels.Order> GetOrders(int p_storeID)
        {
            return _context.Orders.Include(order => order.Items).ThenInclude(item => item.Product).Where(order => order.StoreFrontID == p_storeID).ToList();
        }
        public List<StoreModels.Order> GetOrdersByPrice(int p_storeID)
        {
            return _context.Orders.Include(order => order.Items).ThenInclude(item => item.Product).Where(order => order.StoreFrontID == p_storeID).OrderBy(order => order.Price).ToList();
        }
        public List<StoreModels.Order> GetOrdersByDate(int p_storeID)
        {
            return _context.Orders.Include(order => order.Items).ThenInclude(item => item.Product).Where(order => order.StoreFrontID == p_storeID).OrderBy(order => order.TimePlaced).ToList();
        }

        public StoreModels.LineItem addInventory(int p_StoreID, int p_LineItemID, int p_quantity)
        {
            var item = _context.LineItems.FirstOrDefault(lineItem => lineItem.StoreFrontID == p_StoreID && lineItem.ID == p_LineItemID);
            item.Quantity += p_quantity;
            _context.SaveChanges();
            return item;
        }

        public StoreModels.LineItem removeInventory(int p_StoreID, int p_LineItemID, int p_quantity)
        {
           var item = _context.LineItems.FirstOrDefault(lineItem => lineItem.StoreFrontID == p_StoreID && lineItem.ID == p_LineItemID);
            item.Quantity -= p_quantity;
            _context.SaveChanges();
            return item;
        }

        public StoreModels.LineItem updateInventory(int p_StoreID, int p_LineItemID, int p_quantity)
        {
            var item = _context.LineItems.FirstOrDefault(lineItem => lineItem.StoreFrontID == p_StoreID && lineItem.ID == p_LineItemID);
            item.Quantity = p_quantity;
            _context.SaveChanges();
            return item;
        }

        public StoreModels.LineItem GetLineItem(int p_StoreID, int p_LineItemID)
        {
           return _context.LineItems.Include(item => item.Product).FirstOrDefault(item => item.StoreFrontID == p_StoreID && item.ID == p_LineItemID);
        }

        public bool StoreExists(int p_storeID)
        {
           return _context.StoreFronts.Any(store => store.ID == p_storeID);
        }
    }
}