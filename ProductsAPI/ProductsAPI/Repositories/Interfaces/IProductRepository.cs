using ProductsAPI.Models;

namespace ProductsAPI.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface for CRUD operations on Product entities.
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        Product Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
