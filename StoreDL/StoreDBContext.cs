using System;
using Microsoft.EntityFrameworkCore;

namespace StoreDL
{
    public class StoreDBContext : DbContext
    {
        public DbSet<StoreModels.Customer> Customers { get; set; }
        public DbSet<StoreModels.LineItem> LineItems { get; set; }
        public DbSet<StoreModels.Order> Orders { get; set; }
        public DbSet<StoreModels.OrderItem> OrderItems { get; set; }
        public DbSet<StoreModels.Product> Products { get; set; }
        public DbSet<StoreModels.StoreFront> StoreFronts { get; set; }

        public StoreDBContext(DbContextOptions options) : base(options)
        { }
    
        protected override void OnConfiguring(DbContextOptionsBuilder p_optionsBuilder)
        { }
        
        protected override void OnModelCreating(ModelBuilder p_ModelBuilder)
        {
            p_ModelBuilder.Entity<StoreModels.Customer>()
                .Property(customer => customer.ID)
                .ValueGeneratedOnAdd();
            
            p_ModelBuilder.Entity<StoreModels.LineItem>()
                .Property(item => item.ID)
                .ValueGeneratedOnAdd();
            
            p_ModelBuilder.Entity<StoreModels.Order>()
                .Property(order => order.ID)
                .ValueGeneratedOnAdd();
            
            p_ModelBuilder.Entity<StoreModels.OrderItem>()
                .Property(item => item.ID)
                .ValueGeneratedOnAdd();
            
            p_ModelBuilder.Entity<StoreModels.Product>()
                .Property(product => product.ID)
                .ValueGeneratedOnAdd();
            
            p_ModelBuilder.Entity<StoreModels.StoreFront>()
                .Property(store => store.ID)
                .ValueGeneratedOnAdd();
        }
    }
}