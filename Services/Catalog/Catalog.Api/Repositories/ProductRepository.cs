using Catalog.Api.Data;
using Catalog.Api.Entity;
using MongoDB.Driver;

namespace Catalog.Api.Repositories;

public class ProductRepository:IProductRepository
{
    private readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context=context;
    }


    public async Task<IEnumerable<Product>> GetProduct()
    {
        return await _context.Products.Find(p => true).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Name, name);

        return await _context.Products.Find(filterDefinition).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByCategory(string category)
    {
        FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Category,category);

        return await _context.Products.Find(filterDefinition).ToListAsync();
    }

    public async Task<Product> GetProductById(string id)
    {
        return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateProduct(Product product)
    {
       await _context.Products.InsertOneAsync(product);
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var result = await _context.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);

        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProduct(string id)
    {
        FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Id, id);

        var result = await _context.Products.DeleteOneAsync(filterDefinition);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}