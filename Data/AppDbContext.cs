using Microsoft.EntityFrameworkCore; // used to get the class like dbcontext , ..Dbset etc..
using DotNetCrudAPI.Models;

namespace DotNetCrudAPI.Data  // namespace convention 
{
    public class AppDbContext : DbContext // inheriting 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // represents the users table ...
    }
}