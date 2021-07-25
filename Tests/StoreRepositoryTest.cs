using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using StoreDL;
using StoreModels;

namespace Tests 
{
    public class StoreRepositoryTest 
    {
        private readonly DbContextOptions<StoreDBContext> _options;

        public StoreRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite("Filename = UnitTest.db").Options;
            this.Seed();
        }


    [Fact]
    public void GetAllStoreFrontsShouldReturn1Store()
    {
        using (var context = new StoreDBContext(_options))
        {
            IStoreRepository repo = new StoreRepository(context);

            List<StoreFront> stores = repo.getAllStoreFronts();

            Assert.NotNull(stores);
            Assert.Single(stores);
        }
    }

    [Fact]
    public void GetAStoreFrontShouldReturn1Store()
    {
        using (var context = new StoreDBContext(_options))
        {
            IStoreRepository repo = new StoreRepository(context);

            StoreFront store = repo.getAStoreFront(1);

            Assert.NotNull(store);
            Assert.Equal("Jacob's Halloween Emporium", store.Name);
        }
    }

    [Fact]
    public void GetStoreInventoryShouldReturnListOf3Items()
    {
        using (var context = new StoreDBContext(_options))
        {
            IStoreRepository repo = new StoreRepository(context);

            // Retrieves line items from store with id of 1
            List<LineItem> items = repo.GetStoreInventory(1);

            Assert.NotNull(items);
            Assert.Equal(3, items.Count());
        }
    }

    [Fact]
    public void GetLineItemShouldReturn1LineItem()
    {
        using (var context = new StoreDBContext(_options))
        {
            IStoreRepository repo = new StoreRepository(context);
            // Retrieves a line item from a store with id of 1, and line item id of 1
            LineItem item = repo.GetLineItem(1, 1);

            Assert.NotNull(item);
            Assert.Equal(20, item.Quantity);
        }
    }

    [Fact]
    public void StoreExistsShouldReturnTrue()
    {
        using (var context = new StoreDBContext(_options))
        {
            IStoreRepository repo = new StoreRepository(context);
            bool exists = repo.StoreExists(1);

            Assert.True(exists);
        }
    }

    [Fact]
    public void StoreExistsShouldReturnFalse()
    {
        using (var context = new StoreDBContext(_options))
        {
            IStoreRepository repo = new StoreRepository(context);
            bool exists = repo.StoreExists(2);

            Assert.False(exists);
        }
    }

    [Fact] 
    public void AddInventoryShouldReturn30Quantity()
    {
        using (var context = new StoreDBContext(_options))
        {
            IStoreRepository repo = new StoreRepository(context);
            StoreModels.LineItem updatedItem = repo.addInventory(1, 1, 10);

            Assert.NotNull(updatedItem);
            Assert.Equal(30, updatedItem.Quantity);
        }
    }

    [Fact]
    public void RemoveInventoryShouldReturn10Quantity()
    {
        using (var context = new StoreDBContext(_options))
        {
            IStoreRepository repo = new StoreRepository(context);
            StoreModels.LineItem updatedItem = repo.removeInventory(1, 1, 10);

            Assert.NotNull(updatedItem);
            Assert.Equal(10, updatedItem.Quantity);
        }
    }


        private void Seed()
        {
            using (var context = new StoreDBContext((_options)))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.StoreFronts.AddRange(
                    new StoreFront()
                    {
                        Name = "Jacob's Halloween Emporium",
                        Address = "200 Elm Street",
                        Inventory = new List<LineItem>
                        {
                            new LineItem()
                            {
                                StoreFrontID = 1,
                                Quantity = 20, 
                                Product = new Product()
                                {
                                    Name = "Luke Skywalker Costume",
                                    Price = 24.99,
                                    Description = "Luke Skywalker Costume from Return of the Jedi",
                                    Category = "Costume"
                                }
                            },
                            new LineItem()
                            {
                                StoreFrontID = 1, 
                                Quantity = 142, 
                                Product = new Product()
                                {
                                    Name = "Lightsaber",
                                    Price = 12.99,
                                    Description = "Luke Skywalker's lightsaber from Return of the Jedi",
                                    Category = "Accessory"
                                }
                            },
                            new LineItem()
                            {
                                StoreFrontID = 1, 
                                Quantity = 32,
                                Product = new Product()
                                {
                                    Name = "Vampire Teeth",
                                    Price = 8.99,
                                    Description = "Includes vial of fake blood for application",
                                    Category = "Accessory"
                                }
                            }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}