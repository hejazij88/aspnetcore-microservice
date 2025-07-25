using Catalog.Api.Entity;
using MongoDB.Driver;

namespace Catalog.Api.Data;

public class CatalogContext:ICatalogContext
{
    public IMongoCollection<Product> Products { get; }

    public CatalogContext(IConfiguration builder)
    {
        var client = new MongoClient(builder.GetValue<string>("ConnectionSetting:ConnectionString"));
        var db=client.GetDatabase("ConnectionSetting:DBName");
        Products = db.GetCollection<Product>("ConnectionSetting:Collection");
        CatalogContextSeed.SeedData(Products);
    }
}