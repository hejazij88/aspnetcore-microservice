using Catalog.Api.Entity;
using MongoDB.Driver;

namespace Catalog.Api.Data;

public class CatalogContext:ICatalogContext
{
    public IMongoCollection<Product> Products { get; }

    public CatalogContext(IConfiguration builder)
    {
        var connectionString = builder.GetValue<string>("ConnectionSetting:ConnectionString");
        var dbName = builder.GetValue<string>("ConnectionSetting:DBName");
        var collectionName = builder.GetValue<string>("ConnectionSetting:Collection");

        var client = new MongoClient(connectionString);
        var db = client.GetDatabase(dbName);
        Products = db.GetCollection<Product>(collectionName);

        
        CatalogContextSeed.SeedData(Products);
    }
}