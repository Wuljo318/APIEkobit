using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEkobit.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasData
                (
                new User()
                {
                    UserId = 2,
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
        }
    }
}
