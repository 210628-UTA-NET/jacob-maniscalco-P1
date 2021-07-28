using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Adds a customer row into the db
        /// </summary>
        /// <param name="p_customer">StoreModels.Customer object</param>
        /// <returns>boolean indicating if the customer was successfully added to the db</returns>
        bool AddCustomer(StoreModels.Customer p_customer);

        /// <summary>
        /// Gets all the customers from the db
        /// </summary>
        /// <returns>List of StoreModels.Customer objects</returns>
        List<StoreModels.Customer> GetAllCustomers();
    
        /// <summary>
        /// Retrieves a single customer from the db depending on customer id
        /// </summary>
        /// <param name="p_CustomerID">integer representing the customer id</param>
        /// <returns>StoreModels.Customer object </returns>
        StoreModels.Customer GetCustomer(int p_CustomerID);

        /// <summary>
        /// Retrieves a single customer from the db depending on customer name
        /// </summary>
        /// <param name="p_CustomerName">the customer name</param>
        /// <returns>StoreModels.Customer object</returns>
        StoreModels.Customer GetCustomer(string p_CustomerName);

        /// <summary>
        /// Retrieves a customer with all associated fields populated from the db
        /// </summary>
        /// <param name="p_CustomerID">customer id</param>
        /// <returns>StoreModels.Customer object</returns>
        StoreModels.Customer GetCustomerAll(int p_CustomerID);

        /// <summary>
        /// Retrieves a customer with all associated fields populated from the db
        /// </summary>
        /// <param name="p_CustomerName">customer name</param>
        /// <returns>StoreModels.Customer object</returns>
        StoreModels.Customer GetCustomerAll(string p_CustomerName);

        /// <summary>
        /// Adds an order row to the db
        /// </summary>
        /// <param name="p_order">StoreModels.Order object</param>
        /// <returns>boolean indicating if the row was succesfully inserted</returns>
        bool AddOrder(StoreModels.Order p_order);

        /// <summary>
        /// Gets a list of orders from the db 
        /// </summary>
        /// <param name="p_CustomerID">customer id</param>
        /// <returns>List of StoreModels.Order objects</returns>
        List<StoreModels.Order> GetOrders(int p_CustomerID);

        /// <summary>
        /// Searches the db to see if a customer with the provided customer id exists
        /// </summary>
        /// <param name="p_customerID">Customer ID</param>
        /// <returns>boolean indicating if the customer exists</returns>
        bool customerExists(int p_customerID);

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