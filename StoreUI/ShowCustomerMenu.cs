using System;
namespace StoreUI
{
    public class ShowCustomerMenu : IMenu
    {
        private static StoreModels.Customer _customer = new StoreModels.Customer();

        private StoreBL.CustomerBL _customerBL;

        public ShowCustomerMenu(StoreBL.CustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public MenuType getChoice()
        {
            string userInput = Console.ReadLine();
            string userID;
            switch(userInput)
            {
                
                case "1":
                    do {
                        Console.Write("Customer ID: ");
                        userID = Console.ReadLine();
                        Console.Clear();
                    } while(!_customerBL.CustomerExists(int.Parse(userID)));
                    
                    StoreModels.Customer customer = _customerBL.GetCustomer(int.Parse(userID));
                    Console.WriteLine(customer.ToString());
                    Console.WriteLine("[0] Exit");
                    string exit = Console.ReadLine();
                    while (exit != "0")
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect Input");
                        Console.WriteLine("[0] Exit");
                        exit = Console.ReadLine();
                    }
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("Incorrect Input");
                    return MenuType.ShowCustomerMenu;
            }
        }

        public void menu()
        {
            Console.WriteLine("---- View Customer Info ----");
            Console.WriteLine("------------------------------");
            Console.WriteLine("| [1] Enter the customer's ID.");
            Console.WriteLine("| [0] Exit.");
            Console.WriteLine("------------------------------");
        }
    }
}