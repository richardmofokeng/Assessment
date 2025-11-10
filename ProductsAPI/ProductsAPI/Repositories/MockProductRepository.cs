using ProductsAPI.Models;
using ProductsAPI.Repositories.Interfaces;
using System.Xml.Linq;

namespace ProductsAPI.Repositories
{
    /// <summary>
    /// Mock implementation of IProductRepository for testing purposes.
    /// </summary>
    public class MockProductRepository: IProductRepository
    {
        private readonly List<Product> _products;

        public MockProductRepository()
        {
            // Mock data
            _products = new List<Product>
            {
                new Product { ProductID = 1, Name = "Laptop", Description = "Gaming Laptop", Price = 1500 },
                new Product { ProductID = 2, Name = "Phone", Description = "Smartphone", Price = 700 },
                new Product { ProductID = 3, Name = "Tablet", Description = "10-inch Tablet", Price = 300 }
            };
        }

        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.ProductID == id);

        public Product Add(Product product)
        {
            product.ProductID = _products.Max(p => p.ProductID) + 1;
            _products.Add(product);
            return product;
        }

        public void Update(Product product)
        {
            var existing = GetById(product.ProductID);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Description = product.Description;
                existing.Price = product.Price;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
