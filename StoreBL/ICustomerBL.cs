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

        bool AddOrder(StoreModels.Order p_order, int p_customerID);

        List<StoreModels.Order> GetOrders(int p_customerID);

        bool CustomerExists(int p_customerID);
    }
}