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

        public StoreController(IStoreBL p_StoreBL)
        {
            _storeBL = p_StoreBL;
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
    }
}

