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
        {   StoreModels.Customer cust = new StoreModels.Customer()
            {
                ID = customer.ID,
                Name = customer.Name,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber
            };
            _customerBL.UpdateCustomer(cust);

           return RedirectToAction("Index");
        }

        public IActionResult Edit(int custID)
        {
            Console.WriteLine(_customerBL.GetCustomer(custID));
            return View(new StoreWebUI.Models.CustomerVM(_customerBL.GetCustomer(custID)));
        }
    }
}