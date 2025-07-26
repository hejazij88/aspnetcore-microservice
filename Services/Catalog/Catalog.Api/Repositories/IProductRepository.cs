using Catalog.Api.Entity;

namespace Catalog.Api.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProduct();
    Task<IEnumerable<Product>> GetProductByName(string name);
    Task<IEnumerable<Product>> GetProductByCategory(string category);
    Task<Product> GetProductById(string id);
    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string id);
}