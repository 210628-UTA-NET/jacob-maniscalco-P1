using System;
using System.Collections.Generic;
namespace StoreUI
{
    public class ShowProductsMenu : IMenu
    {

        private StoreBL.IProductBL _productBL;

        public ShowProductsMenu(StoreBL.IProductBL p_productBL)
        {
            _productBL = p_productBL;
        }

        public MenuType getChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                    return MenuType.ProductMenu;
                default:
                    Console.WriteLine("Invalid input");
                    return MenuType.ShowProductMenu;
            }
        }

        public void menu()
        {
            Console.WriteLine("Products:");
            List<StoreModels.Product> products = _productBL.GetAllProducts();
            foreach(StoreModels.Product product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("[0] Exit.");
        }
    }
}