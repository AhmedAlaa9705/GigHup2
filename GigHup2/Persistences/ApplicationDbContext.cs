using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using GigHup2.Core.Models;

namespace GigHup2.Persistences
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Gig)
                .WithMany(a=>a.Attendances)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
               .HasMany(a => a.Followers)
               .WithRequired(f=>f.Followee)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()

               .HasMany(u => u.Followees)
               .WithRequired(f=>f.Follower)
               .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserNotification>()

             .HasRequired(u => u.User)
             .WithMany(a=>a.UserNotifications)
             .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

        }
    }
}