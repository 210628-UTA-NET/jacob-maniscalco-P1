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
       
        
        public StoreRepository()
        {
        
        }
        public List<StoreModels.StoreFront> getAllStoreFronts()
        { 
           throw new NotImplementedException();
        }
        
        public StoreModels.StoreFront getAStoreFront(int p_storeID)
        { 
           throw new NotImplementedException();
        }

        // Think about changing this to return a boolean instead, which can act as a flag for success
        public bool addAStoreFront(StoreModels.StoreFront p_store)
        {
          throw new NotImplementedException();
        }

        public List<StoreModels.LineItem> GetStoreInventory(int p_storeID)
        {
            throw new NotImplementedException();
        }

        public List<StoreModels.Order> GetOrders(int p_storeID)
        {
            throw new NotImplementedException();
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
           throw new NotImplementedException();
        }

        public bool StoreExists(int p_storeID)
        {
           throw new NotImplementedException();
        }
    }
}