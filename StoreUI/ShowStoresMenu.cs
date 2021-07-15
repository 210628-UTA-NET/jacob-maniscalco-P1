using System;
using System.Collections.Generic;
namespace StoreUI
{
    public class ShowStoresMenu : IMenu
    {
        private StoreBL.StoreBL _storeBL;

        public ShowStoresMenu(StoreBL.StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public MenuType getChoice()
        {
            string UserInput = Console.ReadLine();

            switch(UserInput)
            {
                case "1":
                    return MenuType.StoreMenu;
                case "0":
                    return MenuType.Exit;
                default: 
                    return MenuType.ShowStoresMenu;
            }
        }

        public void menu()
        {
            List<StoreModels.StoreFront> stores = _storeBL.GetAllStoreFronts();

            foreach(StoreModels.StoreFront store in stores)
            {
                Console.WriteLine(store);
            }
            Console.WriteLine("[1] Return to store menu.");
            Console.WriteLine("[0] Exit.");
        }
    }
}