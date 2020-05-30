﻿// <auto-generated />
using System;
using ASPNETCore2JwtAuthentication.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MaterialAspNetCoreBackend.DataLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MaterialAspNetCoreBackend.DomainClasses.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Avatar = "user1",
                            Bio = "This is my biography ....",
                            BirthDate = new DateTimeOffset(new DateTime(1995, 5, 30, 4, 38, 39, 467, DateTimeKind.Unspecified).AddTicks(3160), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "User 1"
                        },
                        new
                        {
                            Id = 2,
                            Avatar = "user2",
                            Bio = "This is my biography ....",
                            BirthDate = new DateTimeOffset(new DateTime(1985, 5, 30, 4, 38, 39, 467, DateTimeKind.Unspecified).AddTicks(6227), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "User 2"
                        },
                        new
                        {
                            Id = 3,
                            Avatar = "user3",
                            Bio = "This is my biography ....",
                            BirthDate = new DateTimeOffset(new DateTime(1975, 5, 30, 4, 38, 39, 467, DateTimeKind.Unspecified).AddTicks(6358), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "User 3"
                        });
                });

            modelBuilder.Entity("MaterialAspNetCoreBackend.DomainClasses.UserNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserNotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTimeOffset(new DateTime(2020, 5, 31, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Do something ...",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTimeOffset(new DateTime(2020, 6, 9, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(6882), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Make something ...",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTimeOffset(new DateTime(2020, 6, 2, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(7065), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Do something ...",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTimeOffset(new DateTime(2020, 6, 14, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(7086), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Make something ...",
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTimeOffset(new DateTime(2020, 6, 1, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(7102), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Make something ...",
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTimeOffset(new DateTime(2020, 6, 2, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(7118), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Do something ...",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("MaterialAspNetCoreBackend.DomainClasses.UserNote", b =>
                {
                    b.HasOne("MaterialAspNetCoreBackend.DomainClasses.User", "User")
                        .WithMany("UserNotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
