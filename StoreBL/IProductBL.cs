using System.Collections.Generic;
namespace StoreBL
{
    public interface IProductBL
    {
        /// <summary>
        /// Returns all of the products currently in the db
        /// </summary>
        /// <returns>A List of StoreModels.Product objects</returns>
        List<StoreModels.Product> GetAllProducts();

        /// <summary>
        /// Returns a product from the db with the given product id
        /// </summary>
        /// <param name="p_productID">the product id</param>
        /// <returns>StoreModels.Product object</returns>
        StoreModels.Product GetProduct(int p_productID);

        /// <summary>
        /// Adds a product to the database
        /// </summary>
        /// <param name="p_product">the product that will be inserted</param>
        /// <returns>boolean indicating if the product was successfully added</returns>
        bool addProduct(StoreModels.Product p_product);
    }
}