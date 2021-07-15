using System;

namespace StoreUI
{
    public class StoreMenu : IMenu
    {
        public void menu()
        {
            Console.WriteLine("---- Store Menu ----");
            Console.WriteLine("------------------------------");
            Console.WriteLine("| [5] Enter a new store.");
            Console.WriteLine("| [4] View a list of stores.");
            Console.WriteLine("| [3] View store inventory");
            Console.WriteLine("| [2] View store orders.");
            Console.WriteLine("| [1] Replenish Store Inventory");
            Console.WriteLine("| [0] Return to main menu.");
            Console.WriteLine("------------------------------");
        }

         public MenuType getChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "5":
                    return MenuType.AddStoreFrontMenu;
                case "4":
                    return MenuType.ShowStoresMenu;
                case "3":
                    return MenuType.StoreInventoryMenu;
                case "2":
                    return MenuType.ShowStoreOrdersMenu;
                case "1":
                    return MenuType.ReplenishStoreInventoryMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    return MenuType.StoreMenu;
            }
        }
    }
}