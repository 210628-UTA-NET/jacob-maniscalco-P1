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
    public class StoreControllerTest
    {
        [Fact]
        public void IndexActionShouldReturnStoreList()
        {
            var mockBL = new Mock<StoreBL.IStoreBL>();
            mockBL.Setup(custBL => custBL.GetAllStoreFronts()).Returns
            (
                new List<StoreModels.StoreFront>
                {
                    new StoreModels.StoreFront() { Name = "Jacob's Store"},
                    new StoreModels.StoreFront() { Name = "Ethan's Store"}
                }
            );

            var productBL = new Mock<StoreBL.IProductBL>();
            productBL.Setup(pBL => pBL.GetAllProducts()).Returns
            (
                new List<StoreModels.Product>
                {
                    new StoreModels.Product() { Name = "Batman Costume"},
                    new StoreModels.Product() { Name = "Ironman Costume"}
                }
            );

            var customerBL = new Mock<StoreBL.ICustomerBL>();
            customerBL.Setup(cBL => cBL.GetAllCustomers()).Returns
            (
                new List<StoreModels.Customer>
                {
                    new StoreModels.Customer() { Name = "Jacob"},
                    new StoreModels.Customer() { Name = "Ethan"}
                }
            
            );

            var storeController = new StoreController(mockBL.Object, productBL.Object, customerBL.Object);

            var result = storeController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StoreWebUI.Models.StoreVM>>(viewResult.ViewData.Model);

            Assert.Equal(2, model.Count());

        }
        
    }
}