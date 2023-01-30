using DataEkobit.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataEkobit.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\MSSqlLocalDb;Database=Ekobit;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Dominik",
                    LastName = "Vuljak",
                    Email = "dvuljak@ekobit.hr",
                    Address = "Ulica 1",
                    City = "Varaždin",
                    ZipCode = 42000,
                    Birthday = new DateTime(2000, 1, 1, 0, 0, 0),
                    Password = "lozinka",
                    Nickname = "Dodo"
                },

                new User
                {
                    UserId = 3,
                    Name = "Dominik1",
                    LastName = "Vuljak1",
                    Email = "dvuljak1@ekobit.hr",
                    Address = "Ulica 11",
                    City = "Varaždin1",
                    ZipCode = 42000,
                    Birthday = new DateTime(2001, 1, 1, 0, 0, 0),
                    Password = "lozinka1",
                    Nickname = "Dodo1"
                }
            );
            modelBuilder.ApplyConfiguration(new UserConfiguration()); //https://code-maze.com/migrations-and-seed-data-efcore/
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    CountryId = 1,
                    Name = "Croatia",
                    Continent = "Europe",
                    CountryCode = "CRO",
                    Capital = "Zagreb"
                },
                new Country
                {
                    CountryId = 2,
                    Name = "Bosnia and Herzegovina",
                    Continent = "Europe",
                    CountryCode = "BH",
                    Capital = "Sarajevo"
                },
                new Country
                {
                    CountryId = 3,
                    Name = "United States of America",
                    Continent = "North America",
                    CountryCode = "USA",
                    Capital = "Washington D.C."
                }
                );
            modelBuilder.Entity<User>()
                .HasOne(u => u.Country)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CountryId)
                .HasPrincipalKey(c => c.CountryId);
        }
        public DbSet<User> Users { get; set; }
    }
}
