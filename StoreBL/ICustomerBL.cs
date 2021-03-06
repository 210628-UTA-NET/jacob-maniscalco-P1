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
        StoreModels.Customer GetCustomer(int p_CustomerID);

        /// <summary>
        /// Adds an order to the database
        /// </summary>
        /// <param name="p_order">StoreModel.Order object</param>
        /// <param name="p_customerID">integer value representing the customer's id</param>
        /// <returns>boolean if the order was successfully added</returns>
        
        /// <summary>
        /// Returns a StoreModels.Customer object according to user input 
        /// </summary>
        /// <param name="p_CustomerName">the customer name</param>
        /// <returns>StoreModels.Customer object</returns>
        StoreModels.Customer GetCustomer(string p_CustomerName);

        /// <summary>
        /// Returns a StoreModels.Customer object with all fields populated (including Orders => Product)
        /// </summary>
        /// <param name="p_CustomerID">The customer ID</param>
        /// <returns>StoreModels.Customer object</returns>
        StoreModels.Customer GetCustomerAll(int p_CustomerID);

        /// <summary>
        /// Returns a StoreModels.Customer object with all fields populated (including Orders => Product)
        /// </summary>
        /// <param name="p_CustomerName">The Customer Name</param>
        /// <returns>StoreModels.Customer object</returns>
        StoreModels.Customer GetCustomerAll(string p_CustomerName);
        bool AddOrder(StoreModels.Order p_order, int p_CustomerID);

        /// <summary>
        /// Retrieves all orders from a particular customer
        /// </summary>
        /// <param name="p_customerID">integer value representing the customer's id</param>
        /// <returns>A list of StoreModels.Order objects </returns>
        List<StoreModels.Order> GetOrders(int p_CustomerID);

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
        StoreModels.Customer UpdateCustomer(StoreModels.Customer p_customer);

        /// <summary>
        /// Inserts an order into the database 
        /// </summary>
        /// <param name="p_order">the order object to be inserted</param>
        /// <returns>returns the inserted store</returns>
        StoreModels.Order createOrder(StoreModels.Order p_order);

        /// <summary>
        /// Adds an OrderItem to the database
        /// </summary>
        /// <param name="p_OrderItem">the order item object to be inserted</param>
        /// <returns>the order item object that was inserted </returns>
        StoreModels.OrderItem AddOrderItem(StoreModels.OrderItem p_OrderItem);

        /// <summary>
        /// Retrieves a order from the database
        /// </summary>
        /// <param name="p_OrderID">the order id corresponding to the order </param>
        /// <returns>the order object that was retrieved </returns>
        StoreModels.Order GetOrder(int p_OrderID);

        /// <summary>
        /// Sets the price of an order in the db
        /// </summary>
        /// <param name="p_OrderID">the id of the order</param>
        /// <param name="p_price">the price of the order </param>
        /// <returns>the order object that was affected</returns>
        StoreModels.Order SetOrderPrice(int p_OrderID, double p_price);
    }
}