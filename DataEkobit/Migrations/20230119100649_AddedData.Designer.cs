// <auto-generated />
using System;
using DataEkobit.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataEkobit.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230119100649_AddedData")]
    partial class AddedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataEkobit.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("user", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            Address = "Ulica 1",
                            Birthday = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Varaždin",
                            Email = "dvuljak@ekobit.hr",
                            LastName = "Vuljak",
                            Name = "Dominik",
                            Nickname = "Dodo",
                            Password = "lozinka",
                            ZipCode = 42000
                        },
                        new
                        {
                            UserId = 3L,
                            Address = "Ulica 11",
                            Birthday = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Varaždin1",
                            Email = "dvuljak1@ekobit.hr",
                            LastName = "Vuljak1",
                            Name = "Dominik1",
                            Nickname = "Dodo1",
                            Password = "lozinka1",
                            ZipCode = 42000
                        },
                        new
                        {
                            UserId = 2L,
                            Address = "Ulica 11",
                            Birthday = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Varaždin1",
                            Email = "dvuljak1@ekobit.hr",
                            LastName = "Vuljak1",
                            Name = "Dominik1",
                            Nickname = "Dodo1",
                            Password = "lozinka1",
                            ZipCode = 42000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
