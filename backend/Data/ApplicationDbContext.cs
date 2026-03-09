// Ensure you have installed the Microsoft.EntityFrameworkCore NuGet package.
// You can install it using the following command in the terminal:
// dotnet add package Microsoft.EntityFrameworkCore

using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<User> Users { get; set; } 
    }
}
