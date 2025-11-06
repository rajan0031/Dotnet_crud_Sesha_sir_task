using Microsoft.EntityFrameworkCore;
using DotNetCrudAPI.Models;

namespace DotNetCrudAPI.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}