using CQRS.WebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.WebApi.Infrastructure.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
       
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(p => p.BuyingPrice)
                .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Product>()
                .Property(p => p.Rate)
                .HasColumnType("decimal(18,4)");
        }
    }
}
