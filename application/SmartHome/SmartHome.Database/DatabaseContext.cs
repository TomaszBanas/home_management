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
        public DatabaseContext()
        {
            ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //var dir = @"D:\Projects\inzynieria_oprogramowania_home_management\application\SmartHome\SmartHome.App"; // to create a migration set your local machine destination
            var dir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString());
            options
                //.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
                .UseSqlite($@"Data Source={dir}\database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
