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
        /// Retrieves a StoreFront object from the database using an ID parameter with all related fields
        /// </summary>
        /// <param name="p_storeFrontID">Corresponds to the storefront ID in the database</param>
        /// <returns>StoreFront object</returns>
        StoreModels.StoreFront GetStoreFrontAll(int p_StoreFrontID);
        
        Boolean addStoreFront(StoreModels.StoreFront p_store);

        /// <summary>
        /// Retrieves the inventory for a specific store
        /// </summary>
        /// <param name="p_storeID">The store ID </param>
        /// <returns>List of LineItems representing the store's inventory</returns>
        List<StoreModels.LineItem> GetStoreInventory(int p_StoreID);

        /// <summary>
        /// Retrieves a List of StoreModels.Order objects corresponding to the store ID parameter
        /// </summary>
        /// <param name="p_storeID">the store id </param>
        /// <returns>List of StoreModels.Order objects</returns>
        List<StoreModels.Order> GetOrders(int p_storeID);

        /// <summary>
        /// Adds some quantity to a line item tied to a store
        /// </summary>
        /// <param name="p_StoreID">the store id</param>
        /// <param name="p_LineItemID">the line item id</param>
        /// <param name="p_quantity">the amount of product being added to the item's quantity</param>
        /// <returns>StoreModels.LineItem object</returns>
        StoreModels.LineItem addInventory(int p_StoreID, int p_LineItemID, int p_quantity);

        /// <summary>
        /// Removes some quantity from a line item tied to a store
        /// </summary>
        /// <param name="p_StoreID">the store id</param>
        /// <param name="p_LineItemID">the line item id</param>
        /// <param name="p_quantity">the amount of product being removed from the item's quantity</param>
        /// <returns>A StoreModels.LineItem object </returns>
        StoreModels.LineItem removeInventory(int p_StoreID, int p_LineItemID, int p_quantity);

        StoreModels.LineItem updateInventory(int p_StoreID, int p_LineItemID, int p_quantity);
        
           

        /// <summary>
        /// Retrieves a StoreModels.LineItem object from the db
        /// </summary>
        /// <param name="p_storeID">the store id</param>
        /// <param name="p_lineItemID">the line item id </param>
        /// <returns>StoreModels.LineItem object </returns>
        StoreModels.LineItem GetLineItem(int p_storeID, int p_lineItemID);

        /// <summary>
        /// Determines if a store with the given id exists in the db
        /// </summary>
        /// <param name="p_storeID">the store id</param>
        /// <returns>boolean indicating if the store exists</returns>
        bool StoreExists(int p_storeID);
    }
}