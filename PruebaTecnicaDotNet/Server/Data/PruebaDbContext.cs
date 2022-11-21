using Microsoft.EntityFrameworkCore;
using PruebaTecnicaDotNet.Server.Models;
using System;

namespace PruebaTecnicaDotNet.Server.Data
{
    public class PruebaDbContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomersPhones> CustomersPhones { get; set; }

        public PruebaDbContext()
        {

        }

        public PruebaDbContext(DbContextOptions<PruebaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
