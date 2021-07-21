using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerRepository
    {
        bool AddCustomer(StoreModels.Customer p_customer);

        List<StoreModels.Customer> GetAllCustomers();
    
        StoreModels.Customer GetCustomer(int p_UserID);
        StoreModels.Customer GetCustomer(string p_customerName);

        bool AddOrder(StoreModels.Order p_order);

        List<StoreModels.Order> GetOrders(int p_customerID);

        bool customerExists(int p_customerID);

        /// <summary>
        /// Update's a customer's information in the database
        /// </summary>
        /// <param name="customer">StoreModels.Customer object used to update the customer</param>
        /// <returns>boolean if the customer's information was successfully updated</returns>
       StoreModels.Customer UpdateCustomer(StoreModels.Customer customer);
    }
}