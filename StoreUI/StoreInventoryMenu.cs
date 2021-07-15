using System;
using System.Collections.Generic;
namespace StoreUI
{
    public class StoreInventoryMenu : IMenu
    {
        private StoreBL.IStoreBL _storeBL;

        public StoreInventoryMenu(StoreBL.IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public MenuType getChoice()
        {
            string userInput = Console.ReadLine();
            Console.Clear();

            switch(userInput)
            {
                case "1":
                    List<StoreModels.StoreFront> stores = _storeBL.GetAllStoreFronts();
                    foreach(StoreModels.StoreFront store in stores)
                    {
                        Console.WriteLine(store);
                    }
                    string storeID;
                    do
                    {
                        Console.Write("Store ID: ");
                        storeID = Console.ReadLine();
                    } while(!_storeBL.StoreExists(int.Parse(storeID)));

                    List<StoreModels.LineItem> items = new List<StoreModels.LineItem>();
                    items = _storeBL.GetStoreInventory(int.Parse(storeID));
                    Console.Clear();
                    
                    if (items.Count == 0)
                    {
                        Console.WriteLine("This store's inventory is empty.");
                    }
                    else 
                    {
                        foreach(StoreModels.LineItem item in items)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    
                    Console.WriteLine("Enter 1 to exit.");
                    string exit = Console.ReadLine();
                    
                    while (exit != "1")
                    {
                        Console.WriteLine("Incorrect Input");
                        Console.WriteLine("[0] Exit");
                        exit = Console.ReadLine();
                    }
                    return MenuType.StoreInventoryMenu;
                
                case "0":
                    return MenuType.StoreMenu;
                default:
                    return MenuType.StoreInventoryMenu;
            }
        }

        public void menu()
        {
            Console.WriteLine("---- Store Inventory ----");
            Console.WriteLine("------------------------");
            Console.WriteLine("| [1] Enter Store ID");
            Console.WriteLine("| [0] Exit");
            Console.WriteLine("------------------------");
        }
    }
}