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
        ///  Adds a StoreFront object to the database 
        /// </summary>
        /// <returns> Returns a boolean if the data was successfully added to the database</returns>
        
        /// <summary>
        /// Retrieves a StoreFront object from the database using an ID parameter with all related fields
        /// </summary>
        /// <param name="p_storeFrontID">Corresponds to the storefront ID in the database</param>
        /// <returns>StoreFront object</returns>
        StoreModels.StoreFront GetStoreFrontAll(int p_StoreID);
        bool addAStoreFront(StoreModels.StoreFront p_store);

        /// <summary>
        /// Retrieves a list of Line Items (Store Inventory) from the db
        /// </summary>
        /// <param name="p_storeID"> The store ID</param>
        /// <returns>List of Line Items representing the store's inventory</returns>
        List<StoreModels.LineItem> GetStoreInventory(int p_storeID);

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
        StoreModels.LineItem GetLineItem(int p_StoreID, int p_LineItemID);

        /// <summary>
        /// Determines if a store with the given id exists in the db
        /// </summary>
        /// <param name="p_storeID">the store id</param>
        /// <returns>boolean indicating if the store exists</returns>
        bool StoreExists(int p_storeID);

        /// <summary>
        /// Returns a list of orders from the db ordered by price
        /// </summary>
        /// <param name="p_storeID">the id for the store</param>
        /// <returns>list of order objects</returns>
        List<StoreModels.Order> GetOrdersByPrice(int p_storeID);

        /// <summary>
        /// Returns a list of orders from the db ordered by date
        /// </summary>
        /// <param name="p_storeID">the id of the store</param>
        /// <returns></returns>
        List<StoreModels.Order> GetOrdersByDate(int p_storeID);

        /// <summary>
        /// Retrieves the store inventory
        /// </summary>
        /// <param name="p_StoreID">the id of the store</param>
        /// <returns>storefront object</returns>
        StoreModels.StoreFront GetStoreFrontInventory(int p_StoreID);
    }
}