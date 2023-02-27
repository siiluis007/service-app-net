using MyMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using MyMicroservice.DataSeed;
using System.Text.Json;
using Newtonsoft.Json;

namespace MyMicroservice.Data
{

    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(JsonFileReader.GetProductsSeed());
            modelBuilder.Entity<Sale>().HasData(JsonFileReader.GetSalesSeed());
            modelBuilder.Entity<Stock>().HasData(JsonFileReader.GetStocksSeed());
            modelBuilder.Entity<Customer>().HasData(JsonFileReader.GetCustomersSeed());
            
            modelBuilder.Entity<Stock>().HasOne(p => p.Product);
            modelBuilder.Entity<Sale>().HasOne(p => p.Customer);
        }

        public DbSet<StudentDetails> Students { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
