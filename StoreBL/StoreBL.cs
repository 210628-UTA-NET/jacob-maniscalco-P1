using System;
using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public class StoreBL : IStoreBL
    {

        private readonly StoreDL.IStoreRepository _repo;
        public StoreBL(StoreDL.IStoreRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.getAllStoreFronts();
        }

        public StoreFront GetStoreFront(int p_StoreFrontID)
        {
            return _repo.getAStoreFront(p_StoreFrontID);
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

        public StoreModels.LineItem addInventory(int p_StoreID, int p_LineItemID, int p_quantity)
        {
            return _repo.addInventory(p_StoreID, p_LineItemID, p_quantity);
        }
         public StoreModels.LineItem removeInventory(int p_StoreID, int p_LineItemID, int p_quantity)
         {
             return _repo.removeInventory(p_StoreID, p_LineItemID, p_quantity);
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