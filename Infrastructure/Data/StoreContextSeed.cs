using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext dbContext)
        {
            if (!dbContext.ProductCategories.Any())
            {
                var categoryData = File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoryData);
                dbContext.ProductCategories.AddRange(categories);
                await dbContext.SaveChangesAsync();
            }


            if (!dbContext.Products.Any())
            {
                var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                dbContext.Products.AddRange(products);
                await dbContext.SaveChangesAsync();
            }

            if(dbContext.ChangeTracker.HasChanges())
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
 