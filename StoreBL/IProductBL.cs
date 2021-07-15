using System.Collections.Generic;
namespace StoreBL
{
    public interface IProductBL
    {
        List<StoreModels.Product> GetAllProducts();

        StoreModels.Product GetProduct(int p_productID);

        bool addProduct(StoreModels.Product p_product);
    }
}