using Catalog.Api.Entity;
using MongoDB.Driver;

namespace Catalog.Api.Data;

public interface ICatalogContext
{
    public IMongoCollection<Product> Products { get;}
}