using System;

namespace StoreUI
{
    public class CustomerMenu: IMenu
    {
        public void menu()
        {
            Console.WriteLine("---- Customer Main Menu ----");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| [6] Enter New Customer");
            Console.WriteLine("| [5] View All Customers");
            Console.WriteLine("| [4] Find A Customer");
            Console.WriteLine("| [3] View Order History");
            Console.WriteLine("| [2] Create An Order");
            Console.WriteLine("| [1] Return To Main Menu");
            Console.WriteLine("| [0] Exit");
            Console.WriteLine("------------------------------------------------------");
        }

        public MenuType getChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "6": 
                    return MenuType.AddCustomerMenu;
                case "5": 
                    return MenuType.ShowCustomersMenu;
                case "3":
                    return MenuType.ShowCustomerOrders;
                case "4":
                    return MenuType.ShowCustomerMenu;
                case "2":
                    return MenuType.CreateOrderMenu;
                case "1":
                    return MenuType.MainMenu;
                case "0":
                    return MenuType.Exit;
                default:
                    Console.WriteLine("That is not a valid input.");
                    return MenuType.CustomerMenu;
            }
        }
    }
}