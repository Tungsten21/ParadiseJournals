using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Data.Entities;
using System.Reflection.Emit;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<JournalDay> JournalDays { get; set; }
        public DbSet<JournalImages> JournalImages { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistLocations> WishlistLocations { get; set; }
        public DbSet<WishlistLocationImages> WishlistLocationImages { get; set; }
        public DbSet<WishlistAccommodations> WishlistAccommodations { get; set; }
        public DbSet<WishlistAccommodationImages> WishlistAccommodationImages { get; set; }
        public DbSet<WishlistNotes> WishlistNotes { get; set; }
        public DbSet<WishlistNoteImages> WishlistNoteImages { get; set; }

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
            modelBuilder.Entity<Journal>().Property("StartDate").HasColumnType("date");
            modelBuilder.Entity<Journal>().Property("EndDate").HasColumnType("date");
            modelBuilder.Entity<Wishlist>().Property("StartDate").HasColumnType("date");
            modelBuilder.Entity<Wishlist>().Property("EndDate").HasColumnType("date");

            InitializeDB(modelBuilder);
        }

        private void InitializeDB(ModelBuilder modelBuilder)
        {
            InitializeUsers(modelBuilder);
            InitializeJournals(modelBuilder);
            InitializeWishlists(modelBuilder);
        }

        private void InitializeWishlists(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wishlist>(x => x.ToTable("Wishlists"));
            modelBuilder.Entity<WishlistImage>(x => x.ToTable("WishlistImages"));
            modelBuilder.Entity<WishlistAccommodations>(x => x.ToTable("WishlistAccommodations"));
            modelBuilder.Entity<WishlistAccommodationImages>(x => x.ToTable("WishlistAccommodationImages"));
            modelBuilder.Entity<WishlistLocations>(x => x.ToTable("WishlistLocations"));
            modelBuilder.Entity<WishlistLocationImages>(x => x.ToTable("WishlistLocationImages"));
            modelBuilder.Entity<WishlistNotes>(x => x.ToTable("WishlistNotes"));
            modelBuilder.Entity<WishlistNoteImages>(x => x.ToTable("WishlistNoteImages"));

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.WishlistImage)
                .WithOne(wi => wi.Wishlist)
                .HasForeignKey<Wishlist>(w => w.WishlistImageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.Owner)
                .WithMany(o => o.UserWishlists)
                .HasForeignKey(w => w.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist>()
                .HasMany(w => w.WishlistAccommodations)
                .WithOne(wa => wa.Wishlist)
                .HasForeignKey(wa => wa.WishlistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishlistAccommodations>()
                .HasOne(wa => wa.WishlistAccommodationImages)
                .WithOne(wai => wai.WishlistAccommodations)
                .HasForeignKey<WishlistAccommodations>(wa => wa.WishlistAccomidationImagesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist>()
                .HasMany(w => w.WishlistLocations)
                .WithOne(wl => wl.Wishlist)
                .HasForeignKey(wl => wl.WishlistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishlistLocations>()
                .HasOne(wl => wl.WishlistLocationImages)
                .WithOne(wli => wli.WishlistLocations)
                .HasForeignKey<WishlistLocations>(wli => wli.WishlistLocationImagesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist>()
                .HasMany(w => w.WishlistNotes)
                .WithOne(wn => wn.Wishlist)
                .HasForeignKey(wn => wn.WishlistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishlistNotes>()
                .HasOne(wn => wn.WishlistNoteImages)
                .WithOne(wni => wni.WishlistNotes)
                .HasForeignKey<WishlistNotes>(wni => wni.WishlistNoteImagesId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void InitializeJournals(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Journal>(x => x.ToTable("Journals"));
            modelBuilder.Entity<JournalDay>(x => x.ToTable("JournalDays"));
            modelBuilder.Entity<JournalImages>(x => x.ToTable("JournalImages"));

            modelBuilder.Entity<Journal>()
                .HasOne(j => j.JournalImages)
                .WithOne(ji => ji.Journal)
                .HasForeignKey<Journal>(j => j.JournalImagesId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Journal>()
            //    .HasMany(j => j.DayIds)
            //    .WithOne(jd => jd.Journal)
            //    .HasForeignKey(jd => jd.JournalId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Journal>()
                .HasOne(j => j.Owner)
                .WithMany(o => o.UserJournals)
                .HasForeignKey(j => j.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void InitializeUsers(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(x => x.ToTable("Users"));
            modelBuilder.Entity<UserImage>(x => x.ToTable("UserImages"));

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserImage)
                .WithOne(ui => ui.User)
                .HasForeignKey<User>(u => u.UserImageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserJournals)
                .WithOne(uj => uj.Owner)
                .HasForeignKey(uj => uj.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserWishlists)
                .WithOne(uw => uw.Owner)
                .HasForeignKey(uw => uw.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
