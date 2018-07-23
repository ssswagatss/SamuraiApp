﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{

    public class SamuraiContext : DbContext
    {

        public static readonly LoggerFactory SamuraiAppLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((category,level)
                                            =>category ==DbLoggerCategory.Database.Command.Name && level == LogLevel.Information,true)});

        public DbSet<Domain.Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                        .UseLoggerFactory(SamuraiAppLoggerFactory)
                        .EnableSensitiveDataLogging(true)
                        .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SamuraiAppData;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
        }
    }
}
