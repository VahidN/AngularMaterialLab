using System;
using MaterialAspNetCoreBackend.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaterialAspNetCoreBackend.DataLayer.Configurations
{
    public class UserNoteConfiguration : IEntityTypeConfiguration<UserNote>
    {
        public void Configure(EntityTypeBuilder<UserNote> builder)
        {
            builder.HasOne(un => un.User)
                     .WithMany(u => u.UserNotes)
                     .HasForeignKey(un => un.UserId);
            builder.HasData(
                    new UserNote
                    {
                        Id = 1,
                        Date = DateTimeOffset.UtcNow.AddDays(1),
                        Title = "Do something ...",
                        UserId = 1
                    },
                    new UserNote
                    {
                        Id = 2,
                        Date = DateTimeOffset.UtcNow.AddDays(10),
                        Title = "Make something ...",
                        UserId = 1
                    },
                    new UserNote
                    {
                        Id = 3,
                        Date = DateTimeOffset.UtcNow.AddDays(3),
                        Title = "Do something ...",
                        UserId = 1
                    },
                    new UserNote
                    {
                        Id = 4,
                        Date = DateTimeOffset.UtcNow.AddDays(15),
                        Title = "Make something ...",
                        UserId = 1
                    },
                    new UserNote
                    {
                        Id = 5,
                        Date = DateTimeOffset.UtcNow.AddDays(2),
                        Title = "Make something ...",
                        UserId = 2
                    },
                    new UserNote
                    {
                        Id = 6,
                        Date = DateTimeOffset.UtcNow.AddDays(3),
                        Title = "Do something ...",
                        UserId = 3
                    }
            );
        }
    }
}