using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using StoreBL;

namespace StoreWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private StoreBL.ICustomerBL _customerBL;

        public CustomerController(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }

        public IActionResult Index()
        {
            return View(
                _customerBL.GetAllCustomers()
                .Select(customer => new StoreWebUI.Models.CustomerVM(customer))
                .ToList()
            );
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(StoreWebUI.Models.CustomerVM customer)
        {     
            throw new NotImplementedException();
        }

        public IActionResult Edit(int custID)
        {
            return View(new StoreWebUI.Models.CustomerVM(_customerBL.GetCustomer(custID)));
        }
    }
}