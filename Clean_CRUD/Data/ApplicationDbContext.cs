using Clean_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Clean_CRUD.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

      
    }
}
