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
       
        private StoreDBContext _context;
        public StoreRepository(StoreDBContext p_context)
        {
            _context = p_context;
        }
        public List<StoreModels.StoreFront> getAllStoreFronts()
        { 
           return _context.StoreFronts.Select(store => store).ToList();
        }
        
        public StoreModels.StoreFront getAStoreFront(int p_storeID)
        { 
           return _context.StoreFronts.FirstOrDefault(store => store.ID == p_storeID);
        }

        // Think about changing this to return a boolean instead, which can act as a flag for success
        public bool addAStoreFront(StoreModels.StoreFront p_store)
        {
            _context.StoreFronts.Add(p_store);
            _context.SaveChanges();
            return true;
        }

        public List<StoreModels.LineItem> GetStoreInventory(int p_storeID)
        {
           return _context.LineItems.Where(item => item.StoreID == p_storeID).ToList();
        }

        public List<StoreModels.Order> GetOrders(int p_storeID)
        {
            return _context.Orders.Where(order => order.StoreID == p_storeID).ToList();
        }

        public bool addInventory(int p_storeID, int p_lineItemID, int p_Quantity)
        {
            throw new NotImplementedException();
        }

        public bool removeInventory(int p_storeID, int p_lineItemID, int p_Quantity)
        {
           throw new NotImplementedException();
        }

        public StoreModels.LineItem GetLineItem(int p_storeID, int p_lineItemID)
        {
           return _context.LineItems.FirstOrDefault(item => item.StoreID == p_storeID && item.ID == p_lineItemID);
        }

        public bool StoreExists(int p_storeID)
        {
           return _context.StoreFronts.Any(store => store.ID == p_storeID);
        }
    }
}