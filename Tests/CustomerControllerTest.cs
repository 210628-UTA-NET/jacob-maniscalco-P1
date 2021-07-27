using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StoreWebUI.Controllers;

namespace Tests
{
    public class CustomerControllerTest
    {
        [Fact]

        public void IndexActionShouldReturnCustomerList()
        {
            var mockBL = new Mock<StoreBL.ICustomerBL>();
            mockBL.Setup(custBL => custBL.GetAllCustomers()).Returns
            (
                new List<StoreModels.Customer>
                {
                    new StoreModels.Customer() { Name = "Jacob"},
                    new StoreModels.Customer() { Name = "Ethan"}
                }
            );

            var customerController = new CustomerController(mockBL.Object);

            var result = customerController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StoreWebUI.Models.CustomerVM>>(viewResult.ViewData.Model);

            Assert.Equal(2, model.Count());

        }
        
    }
}