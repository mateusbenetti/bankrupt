﻿using Bankrupt.Data.Model;
using Bankrupt.Data.Model.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Bankrupt.Data.Context
{
    public class BankruptContext : DbContext
    {
        private readonly IHostingEnvironment _env;
        public BankruptContext(IHostingEnvironment env)
        {
            _env = env;
        }
        public DbSet<BoardGameInfo> BoardGames { get; set; }
        public DbSet<PlayerInfo> Players { get; set; }
        public DbSet<PossesionInfo> Possesions { get; set; }
        public DbSet<BoardHouseInfo> BoardHouses { get; set; }
        public DbSet<StatisticalAnalysisInfo> StatisticalAnalysis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardGameInfo>()
                .HasOne(p => p.Winner)
                .WithMany(g => g.GamesWins)
                .HasForeignKey(p => p.WinnerId);

            modelBuilder.Entity<BoardGameInfo>()
             .HasOne(p => p.StatisticalAnalysis)
             .WithMany(g => g.BoardGames)
             .HasForeignKey(p => p.StatisticalAnalysisId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
