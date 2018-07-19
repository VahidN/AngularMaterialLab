using System;
using MaterialAspNetCoreBackend.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaterialAspNetCoreBackend.DataLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(450).IsRequired();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.HasData(
                   new User
                   {
                       Id = 1,
                       Name = "User 1",
                       BirthDate = DateTimeOffset.UtcNow.AddYears(-25),
                       Avatar = "user1",
                       Bio = "This is my biography ...."
                   },
                   new User
                   {
                       Id = 2,
                       Name = "User 2",
                       BirthDate = DateTimeOffset.UtcNow.AddYears(-35),
                       Avatar = "user2",
                       Bio = "This is my biography ...."
                   },
                   new User
                   {
                       Id = 3,
                       Name = "User 3",
                       BirthDate = DateTimeOffset.UtcNow.AddYears(-45),
                       Avatar = "user3",
                       Bio = "This is my biography ...."
                   }
            );
        }
    }
}