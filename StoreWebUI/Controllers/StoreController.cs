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
            return View(
                _storeBL.GetStoreInventory(p_StoreID)
                .Select(item => new StoreWebUI.Models.LineItemVM(item))
                .ToList()
            );
        }
    }
}