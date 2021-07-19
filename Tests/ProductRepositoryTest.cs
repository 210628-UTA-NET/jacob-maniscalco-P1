using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using StoreDL;
using StoreModels;

namespace Tests 
{
    public class ProductRepositoryTest
    {
        private readonly DbContextOptions<StoreDBContext> _options;

        public ProductRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite("Filename = UnitTest.db").Options;
            this.Seed();
        }

        [Fact]
        public void GetAllProductsShouldReturn3Products()
        {
            using (var context = new StoreDBContext(_options))
            {
                IProductRepository repo = new ProductRepository(context);

                List<Product> products = repo.getAllProducts();

                Assert.NotNull(products);

                Assert.Equal(3, products.Count());
            }
        }

        [Fact]
        public void getProductShouldReturn1Product()
        {
            using (var context = new StoreDBContext(_options))
            {
                IProductRepository repo = new ProductRepository(context);

                Product product = repo.getProduct(1);

                Assert.NotNull(product);
                Assert.Equal("Luke Skywalker Costume", product.Name);
            }
        }

        private void Seed()
        {
            using (var context = new StoreDBContext((_options)))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Luke Skywalker Costume",
                        Price = 24.99,
                        Description = "Luke Skywalker Costume from Return of the Jedi",
                        Category = "Costume"
                    },
                    new Product 
                    {
                        Name = "Lightsaber",
                        Price = 12.99,
                        Description = "Luke Skywalker's lightsaber from Return of the Jedi",
                        Category = "Accessory"
                    },
                    new Product 
                    {
                        Name = "Vampire Teeth",
                        Price = 8.99,
                        Description = "Includes vial of fake blood for application",
                        Category = "Accessory"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}