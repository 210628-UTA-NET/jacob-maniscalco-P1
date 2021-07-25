using System;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IStoreBL
    {
        /// <summary>
        /// Retrieves all of the StoreFront objects stored in the database 
        /// </summary>
        /// <returns>Returns a list of StoreFront objects</returns>
        List<StoreModels.StoreFront> GetAllStoreFronts();

        /// <summary>
        /// Retrieves a StoreFront object from the database using an ID parameter
        /// </summary>
        /// <param name="p_storeFrontID">Corresponds to the storefront ID in the database</param>
        /// <returns>StoreFront object</returns>
        StoreModels.StoreFront GetStoreFront(int p_StoreFrontID);

        /// <summary>
        ///  Adds a StoreFront object to the database 
        /// </summary>
        /// <returns> Returns a boolean if the data was successfully added to the database</returns>
        Boolean addStoreFront(StoreModels.StoreFront p_store);

        /// <summary>
        /// Retrieves the inventory for a specific store
        /// </summary>
        /// <param name="p_storeID">The store ID </param>
        /// <returns>List of LineItems representing the store's inventory</returns>
        List<StoreModels.LineItem> GetStoreInventory(int p_StoreID);

        List<StoreModels.Order> GetOrders(int p_storeID);

        StoreModels.LineItem addInventory(int p_StoreID, int p_LineItemID, int p_quantity);
        StoreModels.LineItem removeInventory(int p_StoreID, int p_LineItemID, int p_quantity);

        StoreModels.LineItem GetLineItem(int p_storeID, int p_lineItemID);

        bool StoreExists(int p_storeID);
    }
}