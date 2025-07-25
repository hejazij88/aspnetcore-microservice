using Catalog.Api.Entity;
using MongoDB.Driver;

namespace Catalog.Api.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> collection)
    {
        bool existProduct = collection.Find(product =>true ).Any();

        if (existProduct)
        {
            collection.InsertMany(GetSeedData());
        }
    }

    private static IEnumerable<Product> GetSeedData()
    {
        return new List<Product>()
        {
            new Product(){Id = Guid.NewGuid().ToString(),Description = "testDescription",ImageFile = "Image.jpg",Name = "C#",Price = 1400,Summery = "summery Test"}
        };
    }
}