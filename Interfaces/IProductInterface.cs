using StoreEcommerce.DTO;
using StoreEcommerce.Models;

namespace StoreEcommerce.Interfaces
{
    public interface IProductInterface
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task <string> AddProduct(ProductDetailsDTO product);
    }
}
