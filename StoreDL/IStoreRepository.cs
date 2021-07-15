using System;
using System.Collections.Generic;


namespace StoreDL
{
    public interface IStoreRepository 
    {
        /// <summary>
        /// Retrieves all storeFront fronts from the database
        /// </summary>
        /// <returns>A list of StoreFront objects </returns>
        List<StoreModels.StoreFront> getAllStoreFronts();

        /// <summary>
        /// Retrieves a specific storeFront object from the database
        /// </summary>
        /// <param name="store"> A storeFront object to be retrieved</param>
        /// <returns>A store object from the database</returns>
        StoreModels.StoreFront getAStoreFront(int p_StoreID);

        /// <summary>
        /// Will insert a storeFront object into the database
        /// </summary>
        /// <param name="store">The storeFront object the user wishes to insert into the database</param>
        /// <returns>A storeFront object that has just been created</returns>
        bool addAStoreFront(StoreModels.StoreFront store);

        /// <summary>
        /// Retrieves a list of Line Items (Store Inventory) from the db
        /// </summary>
        /// <param name="p_storeID"> The store ID</param>
        /// <returns>List of Line Items representing the store's inventory</returns>
        List<StoreModels.LineItem> GetStoreInventory(int p_storeID);

        List<StoreModels.Order> GetOrders(int p_storeID);

        bool addInventory(int p_storeID, int p_lineItemID, int p_Quantity);
        bool removeInventory(int p_storeID, int p_lineItemID, int p_Quantity);
         StoreModels.LineItem GetLineItem(int p_storeID, int p_lineItemID);

         bool StoreExists(int p_storeID);
    }
}