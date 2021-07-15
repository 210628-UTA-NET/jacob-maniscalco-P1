using System;
namespace StoreUI
{
    public class ProductMenu : IMenu
    {
        public MenuType getChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "2":
                    return MenuType.ShowProductsMenu;
                case "1":
                    return MenuType.ShowProductMenu;
                case "0":
                    return MenuType.Exit;
                default:
                    Console.WriteLine("Not a valid input");
                    return MenuType.ProductMenu;
            }
        }

        public void menu()
        {
            Console.WriteLine("[2] Get All Products.");
            Console.WriteLine("[1] Get Specific Product.");
            Console.WriteLine("[0] Exit.");
        }
    }
}