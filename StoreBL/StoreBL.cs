using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public class StoreBL : IStoreBL
    {

        private StoreDL.IStoreRepository _repo;
        public StoreBL(StoreDL.IStoreRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.getAllStoreFronts();
        }

        public StoreFront GetStoreFront(int p_storeID)
        {
            return _repo.getAStoreFront(p_storeID);
        }

        public Boolean addStoreFront(StoreModels.StoreFront p_store)
        {
            return _repo.addAStoreFront(p_store);
        }

        public List<StoreModels.LineItem> GetStoreInventory(int p_StoreID)
        {
            return _repo.GetStoreInventory(p_StoreID);
        }

        public List<StoreModels.Order> GetOrders(int p_StoreID)
        {
            return _repo.GetOrders(p_StoreID);
        }

        public bool addInventory(int p_storeID, int p_lineItemID, int p_Quantity)
        {
            return _repo.addInventory(p_storeID, p_lineItemID, p_Quantity);
        }
         public bool removeInventory(int p_storeID, int p_lineItemID, int p_Quantity)
         {
             return _repo.removeInventory(p_storeID, p_lineItemID, p_Quantity);
         }
         public StoreModels.LineItem GetLineItem(int p_storeID, int p_lineItemID)
         {
             return _repo.GetLineItem(p_storeID, p_lineItemID);
         }

         public bool StoreExists(int p_storeID)
         {
             return _repo.StoreExists(p_storeID);
         }
    }
}