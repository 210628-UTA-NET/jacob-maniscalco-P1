using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerRepository
    {
        bool AddCustomer(StoreModels.Customer p_customer);

        List<StoreModels.Customer> GetAllCustomers();
    
        StoreModels.Customer GetCustomer(int p_UserID);

        bool AddOrder(StoreModels.Order p_order, int p_customerID);

        List<StoreModels.Order> GetOrders(int p_customerID);

        bool customerExists(int p_customerID);
    }
}