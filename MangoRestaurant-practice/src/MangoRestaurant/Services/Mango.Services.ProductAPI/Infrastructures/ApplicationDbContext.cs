using Microsoft.EntityFrameworkCore;
using Mango.Services.ProductAPI.Models.DTOs;

namespace Mango.Services.ProductAPI.Infrastructures
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
