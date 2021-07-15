using System;
using System.Collections.Generic;
namespace StoreUI
{
    public class ShowCustomersMenu : IMenu
    {
        private StoreBL.ICustomerBL _customerBL;

        public ShowCustomersMenu(StoreBL.ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public MenuType getChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                    return MenuType.CustomerMenu;
                case "0":
                    return MenuType.Exit;
                default:
                    return MenuType.ShowCustomersMenu;
            }
        }

        public void menu()
        {
            Console.WriteLine("---- All Customers ----");
            List<StoreModels.Customer> customers = _customerBL.GetAllCustomers();
            foreach(StoreModels.Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| [1] Return to Customer Main Menu");
            Console.WriteLine("| [0] Exit");
            Console.WriteLine("------------------------------------------------------");

        }
    }
}