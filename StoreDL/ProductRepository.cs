using System;
using System.Collections.Generic;
using System.Linq;
using StoreModels;

namespace StoreDL
{
    public class ProductRepository : IProductRepository
    {
        
        private readonly StoreDBContext _context;
        public ProductRepository(StoreDBContext p_context)
        {
            _context = p_context;
        }
        public List<Product> getAllProducts()
        {
            return _context.Products.Select(product => product).ToList();
        }

        public Product getProduct(int p_productID)
        {
           return _context.Products.FirstOrDefault(product => product.ID == p_productID);
        }
    }
}