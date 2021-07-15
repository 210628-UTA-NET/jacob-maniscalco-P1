using System;
using System.Collections.Generic;
namespace StoreUI
{
    public class ReplenishStoreInventoryMenu : IMenu
    {
        private StoreBL.StoreBL _storeBL;

        public ReplenishStoreInventoryMenu(StoreBL.StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public MenuType getChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                    List<StoreModels.StoreFront> stores = _storeBL.GetAllStoreFronts();
                    foreach(StoreModels.StoreFront store in stores)
                    {
                        Console.WriteLine(store);
                    }

                    Console.Write("Enter the store ID: ");
                    int storeID = int.Parse(Console.ReadLine());

                    List<StoreModels.LineItem> storeItems = _storeBL.GetStoreInventory(storeID);
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("----Store Inventory----");
                        foreach(StoreModels.LineItem item in storeItems)
                        {
                            Console.WriteLine(item);
                        }

                        Console.Write("Enter Line Item ID: ");
                        int productID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter how much quantity you wish to add: ");
                        int addQuantity = int.Parse(Console.ReadLine());
                        bool success = _storeBL.addInventory(storeID, productID, addQuantity);
                        if (success)
                        {
                            Console.Clear();
                            Console.WriteLine("The item's quantity has been updated successfully");
                        }
                        storeItems = _storeBL.GetStoreInventory(storeID);
                        foreach(StoreModels.LineItem item in storeItems)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Enter 1 to replenish another item, 0 to exit.");
                        userInput = Console.ReadLine();
                    } while(userInput == "1");



                    return MenuType.ReplenishStoreInventoryMenu;

                case "0":
                    return MenuType.StoreMenu;

                default: 
                    return MenuType.ReplenishStoreInventoryMenu;
            }
        }

        public void menu()
        {
            Console.WriteLine("----Replenish Store Inventory----");
            Console.WriteLine("[1] Find store.");
            Console.WriteLine("[0] Return to store menu.");
        }
    }
}