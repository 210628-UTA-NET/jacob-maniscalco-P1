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

            var storeController = new StoreController(mockBL.Object);

            var result = storeController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StoreWebUI.Models.StoreVM>>(viewResult.ViewData.Model);

            Assert.Equal(2, model.Count());

        }
        
    }
}