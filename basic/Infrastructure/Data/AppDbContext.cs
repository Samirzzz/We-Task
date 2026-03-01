using basic.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace basic.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Grouproles> Grouproles { get; set; }
        public DbSet<Usergroups> Usergroups { get; set; }
        public DbSet<roles> Roles { get; set; }
        public DbSet<userPermission> Userpermissions { get; set; }
        
        
    }

}
