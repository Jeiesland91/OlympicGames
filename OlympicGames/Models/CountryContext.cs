using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OlympicGames.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                new Game {GameId = "P", Name = "Paralympics"},
                new Game {GameId = "SO", Name = "Summer Olympics"},
                new Game {GameId = "WO", Name = "Winter Olympics"},
                new Game {GameId = "YSO", Name = "Youth Olympic Games"}
            );

            modelBuilder.Entity<Sport>().HasData(
                new Sport { SportId = "Cur", Name = "Curling" },
                new Sport { SportId = "Bob", Name = "Bobsleigh" },
                new Sport { SportId = "Div", Name = "Diving" },
                new Sport { SportId = "RCyc", Name = "Road Cycling" },
                new Sport { SportId = "Arc", Name = "Archery" },
                new Sport { SportId = "CanSpr", Name = "Canoe Sprint" },
                new Sport { SportId = "BreDan", Name = "Breakdancing" },
                new Sport { SportId = "SkaBoa", Name = "Skateboarding" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "I", Name = "Indoor" },
                new Category { CategoryId = "O", Name = "Outdoor" }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = "CAN", Name = "Canada", GameId = "WO", SportId = "Cur", CategoryId = "I", FlagImage = "CAN.png"},
                new Country { CountryId = "SWE", Name = "Sweden", GameId = "WO", SportId = "Cur", CategoryId = "I", FlagImage = "SWE.png"},
                new Country { CountryId = "GB", Name = "Great Britain", GameId = "WO", SportId = "Cur", CategoryId = "I", FlagImage = "GB.png"},
                new Country { CountryId = "JAM", Name = "Jamaica", GameId = "WO", SportId = "Bob", CategoryId = "O", FlagImage = "JAM.png" },
                new Country { CountryId = "ITA", Name = "Italy", GameId = "WO", SportId = "Bob", CategoryId = "O", FlagImage = "ITA.png" },
                new Country { CountryId = "JAP", Name = "Japan", GameId = "WO", SportId = "Bob", CategoryId = "O", FlagImage = "JAP.png" },
                new Country { CountryId = "GER", Name = "Germany", GameId = "SO", SportId = "Div", CategoryId = "I", FlagImage = "GER.png" },
                new Country { CountryId = "CHI", Name = "China", GameId = "SO", SportId = "Div", CategoryId = "I", FlagImage = "CHI.png" },
                new Country { CountryId = "MEX", Name = "Mexico", GameId = "SO", SportId = "Div", CategoryId = "I", FlagImage = "MEX.png" },
                new Country { CountryId = "BRA", Name = "Brazil", GameId = "SO", SportId = "RCyc", CategoryId = "O", FlagImage = "BRA.png" },
                new Country { CountryId = "NET", Name = "Netherlands", GameId = "SO", SportId = "RCyc", CategoryId = "O", FlagImage = "NET.png" },
                new Country { CountryId = "USA", Name = "USA", GameId = "SO", SportId = "RCyc", CategoryId = "O", FlagImage = "USA.png" },
                new Country { CountryId = "THA", Name = "Thailand", GameId = "P", SportId = "Arc", CategoryId = "I", FlagImage = "THA.png" },
                new Country { CountryId = "URU", Name = "Uruguay", GameId = "P", SportId = "Arc", CategoryId = "I", FlagImage = "URU.png" },
                new Country { CountryId = "UKR", Name = "Ukraine", GameId = "P", SportId = "Arc", CategoryId = "I", FlagImage = "UKR.png" },
                new Country { CountryId = "AUS", Name = "Austria", GameId = "P", SportId = "CanSpr", CategoryId = "O", FlagImage = "AUS.png" },
                new Country { CountryId = "PAK", Name = "Pakistan", GameId = "P", SportId = "CanSpr", CategoryId = "O", FlagImage = "PAK.png" },
                new Country { CountryId = "ZIM", Name = "Zimbabwe", GameId = "P", SportId = "CanSpr", CategoryId = "O", FlagImage = "ZIM.png" },
                new Country { CountryId = "FRA", Name = "France", GameId = "YSO", SportId = "BreDan", CategoryId = "I", FlagImage = "FRA.png" },
                new Country { CountryId = "CYP", Name = "Cyprus", GameId = "YSO", SportId = "BreDan", CategoryId = "I", FlagImage = "CYP.png" },
                new Country { CountryId = "RUS", Name = "Russia", GameId = "YSO", SportId = "BreDan", CategoryId = "I", FlagImage = "RUS.png" },
                new Country { CountryId = "FIN", Name = "Finland", GameId = "YSO", SportId = "SkaBoa", CategoryId = "O", FlagImage = "FIN.png" },
                new Country { CountryId = "SLO", Name = "Slovakia", GameId = "YSO", SportId = "SkaBoa", CategoryId = "O", FlagImage = "SLO.png" },
                new Country { CountryId = "POR", Name = "Portugal", GameId = "YSO", SportId = "SkaBoa", CategoryId = "O", FlagImage = "POR.png" }
            );
        }
    }
}
