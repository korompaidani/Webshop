using Microsoft.EntityFrameworkCore;
using System;
using WebshopData.Models;

namespace WebshopData
{
    public class WebshopContext : DbContext
    {
        public WebshopContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
