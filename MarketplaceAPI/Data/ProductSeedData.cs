using MarketplaceAPI.Models;

namespace MarketplaceAPI.Data
{
    public static class ProductSeedData
    {
        public static void Seed(ProductContext context)
        {
            AddNew(new Product { Name = "Lavender heart", Price = 9.25M });
            AddNew(new Product { Name = "Personalised cufflinks", Price = 45.00M });
            AddNew(new Product { Name = "Kids T-shirt", Price = 19.95M });
            context.SaveChanges();

            void AddNew(Product newProduct)
            {
                context.Products.Add(newProduct);
            }
        }
    }
}
