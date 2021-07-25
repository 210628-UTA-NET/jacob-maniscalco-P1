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

        // Think about changing this to return a boolean instead, which can act as a flag for success
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
            return _context.Orders.Where(order => order.StoreFrontID == p_storeID).ToList();
        }

        public bool addInventory(int p_StoreID, int p_LineItemID, int p_quantity)
        {
            throw new NotImplementedException();
        }

        public bool removeInventory(int p_StoreID, int p_LineItemID, int p_quantity)
        {
           throw new NotImplementedException();
        }

        public StoreModels.LineItem GetLineItem(int p_StoreID, int p_LineItemID)
        {
           return _context.LineItems.FirstOrDefault(item => item.StoreFrontID == p_StoreID && item.ID == p_LineItemID);
        }

        public bool StoreExists(int p_storeID)
        {
           return _context.StoreFronts.Any(store => store.ID == p_storeID);
        }
    }
}