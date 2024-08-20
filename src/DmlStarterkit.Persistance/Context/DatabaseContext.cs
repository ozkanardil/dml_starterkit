using DmlStarterkit.Domain.Entities;
using DmlStarterkit.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DmlStarterkit.Persistance.Context
{
    public class DatabaseContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DatabaseContext(DbContextOptions dbContextOptions,
                                IConfiguration configuration)
                            : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        
        public DbSet<LogEntity> Logs { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<UserRoleEntity> UserRole { get; set; }
        public DbSet<UserRoleVEntity> UserRoleV { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleVEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LogEntityConfiguration());
        }
    }
}
