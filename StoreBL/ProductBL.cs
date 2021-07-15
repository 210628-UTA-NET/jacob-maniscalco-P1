
using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public class ProductBL : IProductBL
    {
        private StoreDL.IProductRepository _repo;

        public ProductBL(StoreDL.IProductRepository p_repo)
        {
            _repo = p_repo;
        }
        public bool addProduct(Product p_product)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            return _repo.getAllProducts();
        }

        public Product GetProduct(int p_productID)
        {
            return _repo.getProduct(p_productID);
        }
    }
}