using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartHome.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly string DbPath;
        
        public DbSet<Cache> Cache { get; set; }
        public DbSet<EntityType> EntityType { get; set; }



        public DatabaseContext(IOptions<DatabaseContextConfig> config)
        {
            DbPath = config.Value.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source=./database.db");
            //options.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityType>()
                .HasIndex(u => u.Key)
                .IsUnique();
        }
    }
}
