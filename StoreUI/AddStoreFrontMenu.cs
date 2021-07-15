using System;

namespace StoreUI
{
    public class addStoreFrontMenu : IMenu
    {
        StoreBL.IStoreBL _storeBL;

        public addStoreFrontMenu(StoreBL.IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }

        private static StoreModels.StoreFront _store = new StoreModels.StoreFront();
        public MenuType getChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "3":
                    Console.Write("Store name: ");
                    _store.Name = Console.ReadLine();
                    return MenuType.AddStoreFrontMenu;
                case "2":
                    Console.Write("Store address: ");
                    _store.Address = Console.ReadLine();
                    return MenuType.AddStoreFrontMenu;
                case "1":
                    _storeBL.addStoreFront(_store);
                    return MenuType.AddStoreFrontMenu;
                case "0":
                    return MenuType.StoreMenu;
                default:
                    return MenuType.AddStoreFrontMenu;
            }
        }

        public void menu()
        {
            Console.WriteLine("---Add a store front----");
            Console.WriteLine($"[3] Name: {_store.Name}");
            Console.WriteLine($"[2] Address: {_store.Address}");
            Console.WriteLine("[1] Add store.");
            Console.WriteLine("[0] Exit to store front menu.");
        }
    }
}