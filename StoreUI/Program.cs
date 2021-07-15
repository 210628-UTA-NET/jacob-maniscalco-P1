using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;
namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory menuFactory = new MenuFactory();
            IMenu menu = new MainMenu();
            MenuType currMenu = MenuType.MainMenu;
            bool cond = true;

            while(cond)
            {
                Console.Clear();
                menu.menu();
                currMenu = menu.getChoice();
                
                switch(currMenu) {
                    case MenuType.MainMenu: 
                        menu = menuFactory.GetMenu(MenuType.MainMenu);
                        break;
                    case MenuType.CustomerMenu:
                        menu = menuFactory.GetMenu(MenuType.CustomerMenu);
                        break;
                    case MenuType.AddCustomerMenu:
                        menu = menuFactory.GetMenu(MenuType.AddCustomerMenu);
                        break;
                    case MenuType.ShowCustomerMenu:
                        menu = menuFactory.GetMenu(MenuType.ShowCustomerMenu);
                        break;
                    case MenuType.ShowCustomersMenu:
                        menu = menuFactory.GetMenu(MenuType.ShowCustomersMenu);
                        break;
                    case MenuType.ShowCustomerOrders:
                        menu = menuFactory.GetMenu(MenuType.ShowCustomerOrders);
                        break;
                    case MenuType.CreateOrderMenu:
                        menu = menuFactory.GetMenu(MenuType.CreateOrderMenu);
                        break;
                    case MenuType.StoreMenu: 
                        menu = menuFactory.GetMenu(MenuType.StoreMenu);
                        break;
                    case MenuType.StoreInventoryMenu:
                        menu = menuFactory.GetMenu(MenuType.StoreInventoryMenu);
                        break;
                    case MenuType.ShowStoresMenu:
                        menu = menuFactory.GetMenu(MenuType.ShowStoresMenu);
                        break;
                    case MenuType.ShowStoreOrdersMenu:
                        menu = menuFactory.GetMenu(MenuType.ShowStoreOrdersMenu);
                        break;
                    case MenuType.AddStoreFrontMenu:
                        menu = menuFactory.GetMenu(MenuType.AddStoreFrontMenu);
                        break;
                    case MenuType.ReplenishStoreInventoryMenu:
                        menu = menuFactory.GetMenu(MenuType.ReplenishStoreInventoryMenu);
                        break;
                    case MenuType.ProductMenu:
                        menu = menuFactory.GetMenu(MenuType.ProductMenu);
                        break;
                    case MenuType.ShowProductsMenu:
                        menu = menuFactory.GetMenu(MenuType.ShowProductsMenu);
                        break;
                    case MenuType.Exit:
                        cond = false;
                        break;
                }
            }
        }
    }
}
