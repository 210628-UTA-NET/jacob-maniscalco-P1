using System.Collections.Generic;
namespace StoreDL
{
    public interface IProductRepository
    {
        List<StoreModels.Product> getAllProducts();
        StoreModels.Product getProduct(int p_productID);


    }

    
}