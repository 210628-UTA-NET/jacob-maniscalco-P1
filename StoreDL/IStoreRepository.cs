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
        
         /// <summary>
        /// Retrieves a StoreModels.StoreFront object from the db with all related fields populated
        /// </summary>
        /// <param name="p_StoreFrontID">the store id</param>
        /// <returns>A StoreModels.StoreFront object </returns>
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
    }
}