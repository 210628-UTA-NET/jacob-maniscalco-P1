using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using StoreDL;
using StoreModels;

namespace Tests 
{
    public class CustomerRepositoryTest
    {
        private readonly DbContextOptions<StoreDBContext> _options;

        public CustomerRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite("Filename = UnitTest.db").Options;
            this.Seed();
        }

        [Fact]
        public void GetAllCustomersShouldReturnAllCustomers()
        {
            using (var context = new StoreDBContext(_options))
            {
                ICustomerRepository repo = new CustomerRepository(context);
                List<Customer> customers = repo.GetAllCustomers();

                Assert.NotNull(customers);
                Assert.Single(customers);
            }
        }

        [Fact]
        public void GetCustomerShouldReturnACustomer()
        {
            using (var context = new StoreDBContext(_options))
            {
                ICustomerRepository repo = new CustomerRepository(context);
                Customer customer = repo.GetCustomer(1);

                Assert.NotNull(customer);
                Assert.Equal("Jacob Maniscalco", customer.Name);
            }
        }

        [Fact]
        public void GetOrdersShouldReturnAUsersOrder()
        {
            using (var context = new StoreDBContext(_options))
            {
                ICustomerRepository repo = new CustomerRepository(context);
                List<Order> orders = repo.GetOrders(1);

                Assert.NotNull(orders);
                Assert.Single(orders);
            }
        }

        [Fact]
        public void CustomerExistsShouldReturnTrue()
        {
            using (var context = new StoreDBContext(_options))
            {
                ICustomerRepository repo = new CustomerRepository(context);
                bool exists = repo.customerExists(1);

                Assert.True(exists);
            }
        }

        [Fact]
        public void CustomerExistsShouldReturnFalse()
        {
            using (var context = new StoreDBContext(_options))
            {
                ICustomerRepository repo = new CustomerRepository(context);
                bool exists = repo.customerExists(10);

                Assert.False(exists);
            }
        }

        [Fact]
        public void UpdateCustomerShouldReturnTrue()
        {

            using (var context = new StoreDBContext(_options))
            {
                 StoreModels.Customer updatedCustomer = new StoreModels.Customer()
                {
                    ID = 1,
                    Name = "Jack Skellington",
                    Address = "123 HalloweenTown Drive",
                    PhoneNumber = "0593041234"
                };
                ICustomerRepository repo = new CustomerRepository(context);
                StoreModels.Customer customer = repo.UpdateCustomer(updatedCustomer);
                Assert.NotNull(customer);
                Assert.Equal("Jack Skellington", customer.Name);
            }
        }
        
        private void Seed()
        {
            using (var context = new StoreDBContext((_options)))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Jacob Maniscalco",
                        Address = "500 Spooky Road",
                        PhoneNumber = "4012944506",
                        Orders = new List<Order>
                        {
                            new Order()
                            {
                                StoreID = 1,
                                CustomerID = 1,
                                Location = "500 Spooky Road",
                                Price = 100.99,
                                Items = new List<OrderItem>
                                {
                                   new OrderItem()
                                   {
                                       Quantity = 5,
                                       Product = new Product()
                                       {
                                           Name = "Clown Mask",
                                           Price = 9.99,
                                           Description = "Mask from the movie IT",
                                           Category = "Accessory"
                                       }
                                   },
                                    new OrderItem()
                                   {
                                       Quantity = 4,
                                       Product = new Product()
                                       {
                                           Name = "Batman Costume",
                                           Price = 18.99,
                                           Description = "Costume from the 1989 movie Batman",
                                           Category = "Costume"
                                       }
                                   }

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