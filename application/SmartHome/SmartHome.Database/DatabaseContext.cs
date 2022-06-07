using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
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
        public DbSet<Cache> Cache { get; set; }
        public DbSet<EntityType> EntityType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString());
            options
                .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
                .UseSqlite($@"Data Source={dir}\database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityType>()
                .HasIndex(u => u.Key)
                .IsUnique();
        }
    }
}
