using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using StoreBL;

namespace StoreWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreBL.ICustomerBL _customerBL;

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
        public IActionResult Edit(int p_CustomerID)
        {
            return View(new StoreWebUI.Models.CustomerVM(_customerBL.GetCustomer(p_CustomerID)));
        }
        public IActionResult Add()
        {
            return View(new StoreWebUI.Models.CustomerVM());
        }
        public IActionResult AddCustomer(StoreWebUI.Models.CustomerVM p_customer)
        {
            StoreModels.Customer customer = new StoreModels.Customer()
            {
                Name = p_customer.Name,
                Address = p_customer.Address,
                PhoneNumber = p_customer.PhoneNumber
            };
            _customerBL.AddCustomer(customer);

            return RedirectToAction("Index");
        }

        public IActionResult FindCustomer()
        {
            return View();
        }
        public IActionResult Display(StoreWebUI.Models.CustomerVM p_customer)
        {
            return View(new StoreWebUI.Models.CustomerVM(_customerBL.GetCustomer(p_customer.Name)));
        }
    }
}