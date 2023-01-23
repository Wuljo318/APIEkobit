using DataEkobit.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //Ovo ispod bi možda sad moglo funkcionirati s ovim točnim imenom baze

            //IConfigurationRoot configuration = new ConfigurationBuilder()

            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("AppDbContext"));

            //IConfiguration configuration;
            // var connectionStrings = new ConnectionStrings();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>.HasKey(c => c.UserId);  //nađeno na https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=fluent-api
            modelBuilder.Entity<User>().HasData(
                new User {
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

                //za ovog drugog nije dalo da se unese u bazu ako je UserId=2 jer već postoji u UserConfiguration

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

                //new User
                //{
                //    Name = "Dominik1",
                //    LastName = "Vuljak1",
                //    Email = "dvuljak1@ekobit.hr",
                //    Address = "Ulica 11",
                //    City = "Varaždin1",
                //    ZipCode = 42000,
                //    Birthday = new DateTime(2001, 1, 1, 0, 0, 0),
                //    Password = "lozinka1",
                //    Nickname = "Dodo1"
                //}

            );
            modelBuilder.ApplyConfiguration(new UserConfiguration()); //https://code-maze.com/migrations-and-seed-data-efcore/

            //IList<User> users = new List<User>();
            //users.Add(new User() {
            //    UserId = 2,
            //    Name = "Dominik1",
            //    LastName = "Vuljak1",
            //    Email = "dvuljak1@ekobit.hr",
            //    Address = "Ulica 11",
            //    City = "Varaždin1",
            //    ZipCode = 42000,
            //    Birthday = new DateTime(2001, 1, 1, 0, 0, 0),
            //    Password = "lozinka1",
            //    Nickname = "Dodo1"
            //});
        }
        public DbSet<User> Users { get; set; }
    }
}
