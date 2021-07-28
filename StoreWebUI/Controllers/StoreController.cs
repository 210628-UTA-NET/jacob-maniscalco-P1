using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using StoreBL;

namespace StoreWebUI.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreBL.IStoreBL _storeBL;
        private readonly StoreBL.IProductBL _productBL;
        private readonly StoreBL.ICustomerBL _customerBL;

        public StoreController(IStoreBL p_StoreBL, IProductBL p_ProductBL, ICustomerBL p_CustomerBL)
        {
            _storeBL = p_StoreBL;
            _productBL = p_ProductBL;
            _customerBL = p_CustomerBL;
        }

        public IActionResult Index()
        {
            return View(
                _storeBL.GetAllStoreFronts()
                .Select(store => new StoreWebUI.Models.StoreVM(store))
                .ToList()
            );
        }
        public IActionResult View(int p_StoreFrontID)
        {
            return View(new StoreWebUI.Models.StoreVM(_storeBL.GetStoreFrontAll(p_StoreFrontID)));
        }

        public IActionResult AddInventory(int p_StoreID, int p_ItemID)
        {
            return View(new StoreWebUI.Models.LineItemVM(_storeBL.GetLineItem(p_StoreID, p_ItemID)));
        }

        public IActionResult AddQuantity(StoreWebUI.Models.LineItemVM p_item)
        {
            Console.WriteLine("\n\nQuantity: "+ p_item.Quantity);
            Console.WriteLine("\n\nID: " + p_item.ID);
            StoreModels.LineItem item = new StoreModels.LineItem()
            {
                ID = p_item.ID,
                StoreFrontID = p_item.StoreFrontID,
                Product = p_item.Product,
                Quantity = p_item.Quantity
            };

           StoreModels.LineItem updatedItem = _storeBL.updateInventory(item.StoreFrontID, item.ID, item.Quantity);

           return RedirectToAction("Index");

        }

        public IActionResult MakeOrder(int p_StoreID)
        {
            StoreModels.Order order = new StoreModels.Order()
            {
                StoreFrontID = p_StoreID,
                Items = new List<StoreModels.OrderItem>(),
            };
            StoreModels.StoreFront store = _storeBL.GetStoreFrontAll(p_StoreID);
            StoreWebUI.Models.OrderVM orderVM = new StoreWebUI.Models.OrderVM(order);
            return View(orderVM);
        }

        public IActionResult BeginOrder(StoreWebUI.Models.OrderVM p_order)
        {
            StoreModels.Order order = new StoreModels.Order()
            {
                StoreFrontID = p_order.Order.StoreFrontID,
                CustomerID = p_order.Order.CustomerID,
                Location = p_order.Order.Location
            };
            StoreModels.Order newOrder = _customerBL.createOrder(order);
            StoreModels.OrderItem item = new StoreModels.OrderItem()
            {
                OrderID = newOrder.ID
            };
            return View(new StoreWebUI.Models.OrderItemVM(item, _storeBL.GetStoreFrontAll(order.StoreFrontID)));
        }

        [HttpPost]
        public IActionResult AddItem(StoreWebUI.Models.OrderItemVM p_order, string p_action)
        {
            StoreModels.OrderItem item = new StoreModels.OrderItem()
            {
                OrderID = p_order.Item.OrderID,
                Product = _productBL.GetProduct(p_order.Item.ID),
                Quantity = p_order.Item.Quantity
            };
            
            StoreModels.OrderItem newItem = _customerBL.AddOrderItem(item);
            return View(new StoreWebUI.Models.OrderItemVM(item, _storeBL.GetStoreFrontAll(p_order.StoreFront.ID)));
        }

        [HttpPost]
        public IActionResult CompleteOrder(StoreWebUI.Models.OrderItemVM p_order)
        {
            // Get stuff from db 
            StoreModels.Order order = _customerBL.GetOrder(p_order.Item.OrderID);
            double price = 0;
            foreach(var item in order.Items)
            {
                price += item.Product.Price * item.Quantity;
            }
            order = _customerBL.SetOrderPrice(p_order.Item.OrderID, price);

            StoreWebUI.Models.OrderVM finalOrder= new StoreWebUI.Models.OrderVM()
            {
                Order = new StoreModels.Order()
                {
                    ID = order.ID,
                    StoreFrontID = order.StoreFrontID,
                    CustomerID = order.CustomerID,
                    Location = order.Location,
                    Price = order.Price,
                    Items = order.Items
                }
            };
            return View(finalOrder);
        }

        public IActionResult ViewCustomerOrders(int p_StoreID)
        {
            return View(new StoreWebUI.Models.StoreVM(p_StoreID));
        }

        public IActionResult OrderByPrice(int p_StoreID)
        {
            List<StoreModels.Order> custOrders = _storeBL.GetOrdersByPrice(p_StoreID);

            return View(new StoreWebUI.Models.CustomerOrdersVM(custOrders));
        }
        public IActionResult OrderByDate(int p_StoreID)
        {
            List<StoreModels.Order> custOrders = _storeBL.GetOrdersByDate(p_StoreID);

            return View(new StoreWebUI.Models.CustomerOrdersVM(custOrders));
        }
    }
}

