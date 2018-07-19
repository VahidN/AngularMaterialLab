using MaterialAspNetCoreBackend.DataLayer.Configurations;
using MaterialAspNetCoreBackend.DomainClasses;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore2JwtAuthentication.DataLayer.Context
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<UserNote> UserNotes { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // it should be placed here, otherwise it will rewrite the following settings!
            base.OnModelCreating(builder);

            // Custom application mappings
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserNoteConfiguration());
        }
    }
}