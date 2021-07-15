using System;
using System.Collections.Generic;
using System.Threading;
namespace StoreUI
{
    public class CreateOrderMenu : IMenu
    {
        private StoreBL.StoreBL _storeBL;
        private StoreBL.ProductBL _productBL;
        private StoreBL.CustomerBL _customerBL;

        public CreateOrderMenu(StoreBL.StoreBL p_storeBL, StoreBL.ProductBL p_productBL, StoreBL.CustomerBL p_customerBL)
        {
            _storeBL = p_storeBL;
            _productBL = p_productBL;
            _customerBL = p_customerBL;
        }
        public MenuType getChoice()
        {
            string userInput = Console.ReadLine();
            int userID;
            switch(userInput)
            {
                case "1":
                do 
                {
                    Console.Write("Enter your customer ID: ");
                    userID = int.Parse(Console.ReadLine());
                    Console.Clear();
                } while(!_customerBL.CustomerExists(userID));

                List<StoreModels.StoreFront> stores = _storeBL.GetAllStoreFronts();
                int storeID;
                
                do
                {
                    Console.WriteLine("|----------------");
                    Console.WriteLine("|---- Stores ----");
                    Console.WriteLine("|----------------");
                    foreach(StoreModels.StoreFront storeFront in stores)
                    {
                        Console.WriteLine(storeFront);
                    }                
                        Console.Write("Enter the Store ID: ");
                        userInput = Console.ReadLine();
                        storeID = int.Parse(userInput);
                        Console.Clear();
                } while(!_storeBL.StoreExists(storeID));
                //Retrieve store Items and store Front object
                List<StoreModels.LineItem> storeItems = _storeBL.GetStoreInventory(storeID);
                if (storeItems.Count == 0)
                {
                    Console.WriteLine("This Store's Inventory Is Currently Empty. Try Again Later!");
                    Thread.Sleep(5000);
                    return MenuType.CreateOrderMenu;
                }
                StoreModels.StoreFront store = _storeBL.GetStoreFront(storeID);
                List<StoreModels.OrderItem> customerOrder = new List<StoreModels.OrderItem>();
                List<StoreModels.LineItem> boughtItems = new List<StoreModels.LineItem>();

                bool cond = true;
                while (cond)
                {
                    Console.WriteLine("---- Create Order ----");
                    Console.WriteLine("| [1] Add An Item To Your Order.");
                    Console.WriteLine("| [0] Complete Your Order.");
                    string ProductInput = Console.ReadLine();
                    switch (ProductInput)
                    {
                        case "1": 
                        {
                            Console.Clear();
                            Console.WriteLine("|-----------------");
                            Console.WriteLine("|   Store Items   ");
                            Console.WriteLine("|-----------------\n");
                            foreach(StoreModels.LineItem item in storeItems)
                            {
                                Console.WriteLine(item);
                            }
                            Console.Write("Enter Product ID: ");
                            ProductInput = Console.ReadLine();
                            int id = int.Parse(ProductInput);
                            StoreModels.Product orderItem = _productBL.GetProduct(id);
                            StoreModels.LineItem boughtItem;
                            int itemQuantity;
                            do {
                                Console.Write("Number of Items: ");
                                itemQuantity = int.Parse(Console.ReadLine());
                                boughtItem = _storeBL.GetLineItem(storeID, id);
                                Console.WriteLine("Store Item Quantity: " + boughtItem.Quantity);
                            } while(boughtItem.Quantity < itemQuantity || itemQuantity <= 0);

                            boughtItem.Quantity = itemQuantity;
                            boughtItems.Add(boughtItem);


                            customerOrder.Add(
                                new StoreModels.OrderItem()
                                {
                                    Product = orderItem,
                                    Quantity = itemQuantity
                                }
                            );

                            foreach(StoreModels.LineItem item in boughtItems)
                            {
                                _storeBL.removeInventory(storeID, item.ID, item.Quantity);
                            }
                            storeItems = _storeBL.GetStoreInventory(storeID);
                            Console.Clear();
                            Console.WriteLine("|-----------------------|");
                            Console.WriteLine("|-----Current Order-----|");
                            Console.WriteLine("|-----------------------|\n");
                            foreach(StoreModels.OrderItem item in customerOrder)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                        case "0":
                            if (customerOrder.Count == 0)
                            {
                                Console.WriteLine("No Items Were Added To Your Order.");
                                Console.WriteLine("Returning You To The Customer Menu....");
                                Thread.Sleep(5000);
                                return MenuType.CustomerMenu;
                            }
                            double totalPrice = 0;
                            foreach(StoreModels.OrderItem item in customerOrder)
                            {
                                totalPrice += (item.Product.Price * item.Quantity);
                            }
                            foreach(StoreModels.OrderItem item in customerOrder)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine(String.Format("Total Price: {0:0.00}",totalPrice));
                            Console.WriteLine("Your order has been processed");
                            StoreModels.Order newOrder = new StoreModels.Order()
                            {
                                StoreID = storeID,
                                Items = customerOrder,
                                Location = store.Address,
                                Price = totalPrice
                            };

                            bool success =  _customerBL.AddOrder(newOrder, userID);
                            Thread.Sleep(5000);
                            cond = false;
                            break;
                            
                        default:
                            break;
                    }
                }
                return MenuType.CustomerMenu;
            case "0":
                return MenuType.CustomerMenu;
            default: 
                return MenuType.CreateOrderMenu;
            }
        }

        public void menu()
        {
            Console.WriteLine("---- Create Customer Order ----");
            Console.WriteLine("------------------------------");
            Console.WriteLine("[1] Start Your Order");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("------------------------------");
        }
    }
}