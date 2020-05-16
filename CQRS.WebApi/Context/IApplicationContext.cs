using CQRS.WebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.WebApi.Infrastructure.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
    }
}