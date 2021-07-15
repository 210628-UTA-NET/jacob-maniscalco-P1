using System;
using System.Collections.Generic;
using System.Linq;
using StoreModels;

namespace StoreDL
{
    public class ProductRepository : IProductRepository
    {
        private Entities.jacobmaniscalcoprojectContext _context;

        public ProductRepository(Entities.jacobmaniscalcoprojectContext p_context)
        {
            _context = p_context;
        }
        public List<Product> getAllProducts()
        {
            return _context.Products.Select(
                product =>
                    new StoreModels.Product()
                    {
                        ID = product.ProductId,
                        Name = product.ProductName,
                        Description = product.ProductDescription,
                        Price =  Convert.ToDouble(product.ProductPrice),
                        Category = product.ProductCategory
                    }
            ).ToList();
        }

        public Product getProduct(int p_productID)
        {
            var output = _context.Products.Find(p_productID);

            return 
                new StoreModels.Product()
                {
                    ID = output.ProductId,
                    Name = output.ProductName,
                    Category = output.ProductCategory,
                    Description = output.ProductDescription,
                    Price = (double) output.ProductPrice
                };
        }
    }
}