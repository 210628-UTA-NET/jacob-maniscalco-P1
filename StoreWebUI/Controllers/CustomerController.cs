using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using StoreBL;
using Serilog;

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
            if(ModelState.IsValid)
            {
                StoreModels.Customer customer = new StoreModels.Customer()
                {
                    Name = p_customer.Name,
                    Address = p_customer.Address,
                    PhoneNumber = p_customer.PhoneNumber
                };
                try {
                    _customerBL.AddCustomer(customer);
                }catch(SystemException)
                {
                    Log.Logger = new LoggerConfiguration().WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day).
                    CreateLogger();
                    Log.Information("An error occured when adding a new user to the database.");
                    return RedirectToAction("Index");
                }
                Log.Logger = new LoggerConfiguration().WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day).
                CreateLogger();
                Log.Information("New User " + customer.Name + " created.");
            }
            // Write event to log
            
            return RedirectToAction("Index");
        }

        public IActionResult FindCustomer()
        {
            return View();
        }
        public IActionResult Display(StoreWebUI.Models.CustomerVM p_customer)
        {
            return View(new StoreWebUI.Models.CustomerVM(_customerBL.GetCustomerAll(p_customer.Name)));
        }
    }
}