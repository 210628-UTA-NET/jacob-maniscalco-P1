namespace StoreUI
{
    public enum MenuType {
        MainMenu,
        CustomerMenu,
        AddCustomerMenu,
        ShowCustomerMenu,
        ShowCustomersMenu,
        ShowCustomerOrders,
        CreateOrderMenu,
        StoreMenu,
        StoreInventoryMenu,
        ShowStoresMenu,
        ShowStoreOrdersMenu,
        ReplenishStoreInventoryMenu,
        AddStoreFrontMenu,
        ProductMenu,
        ShowProductMenu,
        ShowProductsMenu,
        Exit
    }
    public interface IMenu
    {
        /// <summary>
        /// Creates a menu to display navigation options to the user.
        /// </summary>
        public void menu();

        /// <summary>
        /// Asks the user via the CLI for their navigation choice via a Console.ReadLine call
        /// </summary>
        public MenuType getChoice();
    }
}