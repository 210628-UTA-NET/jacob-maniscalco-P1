using System;
using System.Collections.Generic;

namespace StoreBL
{
    public interface ICustomerBL
    {
        /// <summary>
        /// Adds a customer to the database
        /// </summary>
        /// <param name="p_customer"></param>
        /// <returns>Returns a boolean, notifying the user if the customer was properly inserted</returns>
        bool AddCustomer(StoreModels.Customer p_customer);

        /// <summary>
        /// Returns all the customers in the database
        /// </summary>
        /// <returns>Returns a List of Customer models</returns>
        List<StoreModels.Customer> GetAllCustomers();

        /// <summary>
        /// Retrieves a single customer from the database
        /// </summary>
        /// <param name="p_id"> The ID of the customer requested</param>
        /// <returns>Returns a Customer model for the customer</returns>
        StoreModels.Customer GetCustomer(int p_id);

        /// <summary>
        /// Adds an order to the database
        /// </summary>
        /// <param name="p_order">StoreModel.Order object</param>
        /// <param name="p_customerID">integer value representing the customer's id</param>
        /// <returns>boolean if the order was successfully added</returns>
        
        StoreModels.Customer GetCustomer(string p_name);
        bool AddOrder(StoreModels.Order p_order, int p_customerID);

        /// <summary>
        /// Retrieves all orders from a particular customer
        /// </summary>
        /// <param name="p_customerID">integer value representing the customer's id</param>
        /// <returns>A list of StoreModels.Order objects </returns>
        List<StoreModels.Order> GetOrders(int p_customerID);

        /// <summary>
        /// Determines if a customer exists within a table
        /// </summary>
        /// <param name="p_customerID">integer value representing the customer's id</param>
        /// <returns>boolean if the customer exists in the database</returns>
        bool CustomerExists(int p_customerID);

        /// <summary>
        /// Update's a customer's information in the database
        /// </summary>
        /// <param name="customer">StoreModels.Customer object used to update the customer</param>
        /// <returns>boolean if the customer's information was successfully updated</returns>
        StoreModels.Customer UpdateCustomer(StoreModels.Customer customer);
    }
}