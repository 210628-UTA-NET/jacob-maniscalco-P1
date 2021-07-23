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

        public IActionResult View(int p_StoreID)
        {
            StoreWebUI.Models.StoreVM store = new Models.StoreVM(_storeBL.GetStoreFront(p_StoreID));
            foreach(StoreModels.LineItem item in store.Inventory)
            {
                Console.WriteLine(item);
            }
            return View(new StoreWebUI.Models.StoreVM(_storeBL.GetStoreFront(p_StoreID)));
        }
    }
}