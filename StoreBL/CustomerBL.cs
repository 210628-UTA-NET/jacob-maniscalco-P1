using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private readonly StoreDL.ICustomerRepository _repo;

        public CustomerBL(StoreDL.ICustomerRepository p_repo)
        {
            _repo = p_repo;
        }
        public bool AddCustomer(Customer p_customer)
        {
            return _repo.AddCustomer(p_customer);
        }

        public List<StoreModels.Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public StoreModels.Customer GetCustomer(int p_CustomerID)
        {
            return _repo.GetCustomer(p_CustomerID);
        }

        public StoreModels.Customer GetCustomer(string p_CustomerName)
        {
            return _repo.GetCustomer(p_CustomerName);
        }

        public StoreModels.Customer GetCustomerAll(int p_CustomerID)
        {
            return _repo.GetCustomerAll(p_CustomerID);
        }
        public StoreModels.Customer GetCustomerAll(string p_CustomerName)
        {
            return _repo.GetCustomerAll(p_CustomerName);
        }
        public bool AddOrder(StoreModels.Order p_order, int p_CustomerID)
        {
            return _repo.AddOrder(p_order);
        }

        public List<StoreModels.Order> GetOrders(int p_CustomerID)
        {
            return _repo.GetOrders(p_CustomerID);
        }

        public bool CustomerExists(int p_customerID)
        {
            return _repo.customerExists(p_customerID);
        }

        public StoreModels.Customer UpdateCustomer(StoreModels.Customer p_customer)
        {
            return _repo.UpdateCustomer(p_customer);
        }

        public StoreModels.Order createOrder(StoreModels.Order p_order)
        {
            return _repo.createOrder(p_order);
        }
        public StoreModels.OrderItem AddOrderItem(StoreModels.OrderItem p_OrderItem)
        {
            return _repo.AddOrderItem(p_OrderItem);
        }
        public StoreModels.Order GetOrder(int p_OrderID)
        {
            return _repo.GetOrder(p_OrderID);
        }
        public StoreModels.Order SetOrderPrice(int p_OrderID, double p_price)
        {
            return _repo.SetOrderPrice(p_OrderID, p_price);
        }
    }
}