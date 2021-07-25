using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StoreModels;

namespace StoreWebUI.Models
{
    public class LineItemVM
    {
        public int ID { get; set; }
        public int StoreFrontID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public LineItemVM()
        { }

        public LineItemVM(LineItem p_item)
        {
            ID = p_item.ID;
            StoreFrontID = p_item.StoreFrontID;
            Product = new Product()
            {
                ID = p_item.Product.ID,
                Name = p_item.Product.Name,
                Description = p_item.Product.Description,
                Category = p_item.Product.Category,
                Price = p_item.Product.Price
            };

            Quantity = p_item.Quantity;
        }
    }
}