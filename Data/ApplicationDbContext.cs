using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Data.Entities;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<JournalDay> JournalDays { get; set; }
        public DbSet<JournalImages> JournalImages { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistLocation> WishlistLocations { get; set; }
        public DbSet<WishlistAccommodation> WishlistAccommodations { get; set; }
        public DbSet<WishlistNote> WishlistNotes { get; set; }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints here
            //Journal
            modelBuilder.Entity<Journal>()
                .HasOne(j => j.JournalImages)
                .WithOne(ji => ji.Journal)
                .HasForeignKey<Journal>(j => j.JournalImagesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Journal>()
                .HasMany(j => j.DayIds)
                .WithOne(jd => jd.Journal)
                .HasForeignKey(jd => jd.JournalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Journal>()
                .HasOne(j => j.Owner)
                .WithMany(o => o.Journals)
                .OnDelete(DeleteBehavior.Cascade);

            //User
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserImage)
                .WithOne(ui => ui.User)
                .HasForeignKey<User>(u => u.UserImageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Journals)
                .WithOne(j => j.Owner)
                .HasForeignKey<Wishlist>(u => wl.PictureId);

            modelBuilder.Entity<WishlistAccommodation>()
                .HasOne(wla => wla.Picture)
                .WithOne(p => p.WishlistAccommodation)
                .HasForeignKey<WishlistAccommodation>(wla => wla.PictureId);
        }
    }
}
