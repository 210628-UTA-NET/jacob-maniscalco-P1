using System;
using System.Collections.Generic;
namespace StoreUI
{
    public class ShowStoreOrdersMenu : IMenu
    {
        private StoreBL.StoreBL _storeBL;
        public ShowStoreOrdersMenu(StoreBL.StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public MenuType getChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1": 
                    Console.WriteLine("----Enter Store ID----");
                    userInput = Console.ReadLine();
                    Console.Clear();
                    int storeID = int.Parse(userInput);
                    List<StoreModels.Order> storeOrders = _storeBL.GetOrders(storeID);
                    
                    Console.WriteLine("----Store Orders----");
                    foreach(StoreModels.Order order in storeOrders)
                    {
                        Console.WriteLine(order);
                    }

                    do {
                        Console.WriteLine("Enter 1 to exit");
                        userInput = Console.ReadLine();
                    } while(userInput != "1");

                    return MenuType.ShowStoreOrdersMenu;
                case "0":
                    return MenuType.StoreMenu;
                default: 
                    return MenuType.ShowStoreOrdersMenu;
            }
        }

        public void menu()
        {
            Console.WriteLine("----Store Orders----");
            Console.WriteLine("[1] Enter store ID.");
            Console.WriteLine("[0] Exit.");
        }
    }
}