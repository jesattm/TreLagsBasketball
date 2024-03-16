using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess.Context
{
    internal class BasketballContext : DbContext
    {
        public BasketballContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=TreLagsBasketballDB;" +
                "User ID=sa;Password=2Us2Ifk9ioD2;TrustServerCertificate=true");
            optionsBuilder.EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Team t1 = new Team { TeamId = -1, TeamName = "Milwuakee Bucks" };
            modelBuilder.Entity<Team>().HasData(new Team[] {
                t1, 
                new Team{TeamId=-2, TeamName="Chicago Bulls"},
                new Team{TeamId=-3, TeamName="Denver Nuggets"},
                new Team{TeamId=-4, TeamName="Philadelphia 76ers"}
            });

            Player p1 = new Player(-1, "Giannis Antetokounmpo", DTO.Model.Position.SmallForward);
            modelBuilder.Entity<Player>().HasData(new Player[] {
                p1,
                new Player{PlayerId=-2, Name="Michael Jordan", Position=DTO.Model.Position.ShootingGuard},
                new Player(-3, "Nicola Jokic", DTO.Model.Position.Center),
                new Player(-4, "Joel Embiid", DTO.Model.Position.Center),
                new Player(-5, "Jrue Holiday", DTO.Model.Position.PointGuard)
            });

            modelBuilder.Entity<Sponsorship>().HasData(new Sponsorship[] {
                new Sponsorship{ SponsorshipId=-1, SponsorshipName="Nike" },
                new Sponsorship{ SponsorshipId=-2, SponsorshipName="Adidas" }
            });
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Sponsorship> Sponsorships { get; set; }
    }
}
