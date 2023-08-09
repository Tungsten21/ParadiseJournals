﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230809211505_Updated table names")]
    partial class Updatedtablenames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.Journal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("JournalImagesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalDays")
                        .HasColumnType("int");

                    b.Property<Guid>("UserJournalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JournalImagesId")
                        .IsUnique()
                        .HasFilter("[JournalImagesId] IS NOT NULL");

                    b.HasIndex("UserJournalId");

                    b.ToTable("Journals", (string)null);
                });

            modelBuilder.Entity("Data.Entities.JournalDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JournalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JournalId");

                    b.ToTable("JournalDays", (string)null);
                });

            modelBuilder.Entity("Data.Entities.JournalImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("AdditionalImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage2")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage3")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage4")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage5")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("JournalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Thumbnail")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("JournalImages", (string)null);
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserJournalsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserWishlistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserImageId")
                        .IsUnique()
                        .HasFilter("[UserImageId] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Data.Entities.UserImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserImages", (string)null);
                });

            modelBuilder.Entity("Data.Entities.UserJournal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JournalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("UserJournals", (string)null);
                });

            modelBuilder.Entity("Data.Entities.UserWishlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WishlistId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("UserWishlists", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Wishlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalDays")
                        .HasColumnType("int");

                    b.Property<Guid>("UserWishlistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WishlistAccommodationsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WishlistImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WishlistLocationsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WishlistNotesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserWishlistId");

                    b.HasIndex("WishlistImageId")
                        .IsUnique()
                        .HasFilter("[WishlistImageId] IS NOT NULL");

                    b.ToTable("Wiishlists", (string)null);
                });

            modelBuilder.Entity("Data.Entities.WishlistAccommodationImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("AdditionalImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage2")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage3")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage4")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage5")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Thumbnail")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("WishlistAccommodationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("WishlistAccommodationImages", (string)null);
                });

            modelBuilder.Entity("Data.Entities.WishlistAccommodations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricePerNight")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WishlistAccomidationImagesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WishlistId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WishlistAccomidationImagesId")
                        .IsUnique()
                        .HasFilter("[WishlistAccomidationImagesId] IS NOT NULL");

                    b.HasIndex("WishlistId");

                    b.ToTable("WishlistAccommodations", (string)null);
                });

            modelBuilder.Entity("Data.Entities.WishlistImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("WishlistId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("WishlistImages", (string)null);
                });

            modelBuilder.Entity("Data.Entities.WishlistLocationImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("AdditionalImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage2")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage3")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage4")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage5")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Thumbnail")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("WishlistLocationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("WishlistLocationImages", (string)null);
                });

            modelBuilder.Entity("Data.Entities.WishlistLocations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryCode")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricePerPerson")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WishlistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WishlistLocationImagesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WishlistId");

                    b.HasIndex("WishlistLocationImagesId")
                        .IsUnique()
                        .HasFilter("[WishlistLocationImagesId] IS NOT NULL");

                    b.ToTable("WishlistLocations", (string)null);
                });

            modelBuilder.Entity("Data.Entities.WishlistNoteImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("AdditionalImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage2")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage3")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage4")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AdditionalImage5")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("WishlistNotesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("WishlistNoteImages", (string)null);
                });

            modelBuilder.Entity("Data.Entities.WishlistNotes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WishlistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WishlistNoteImagesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WishlistId");

                    b.HasIndex("WishlistNoteImagesId")
                        .IsUnique()
                        .HasFilter("[WishlistNoteImagesId] IS NOT NULL");

                    b.ToTable("WishlistNotes", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Journal", b =>
                {
                    b.HasOne("Data.Entities.JournalImages", "JournalImages")
                        .WithOne("Journal")
                        .HasForeignKey("Data.Entities.Journal", "JournalImagesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.UserJournal", "UserJournal")
                        .WithMany("Journals")
                        .HasForeignKey("UserJournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JournalImages");

                    b.Navigation("UserJournal");
                });

            modelBuilder.Entity("Data.Entities.JournalDay", b =>
                {
                    b.HasOne("Data.Entities.Journal", "Journal")
                        .WithMany("DayIds")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journal");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.HasOne("Data.Entities.UserImage", "UserImage")
                        .WithOne("User")
                        .HasForeignKey("Data.Entities.User", "UserImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("UserImage");
                });

            modelBuilder.Entity("Data.Entities.UserJournal", b =>
                {
                    b.HasOne("Data.Entities.User", "Owner")
                        .WithMany("UserJournals")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Data.Entities.UserWishlist", b =>
                {
                    b.HasOne("Data.Entities.User", "Owner")
                        .WithMany("UserWishlists")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Data.Entities.Wishlist", b =>
                {
                    b.HasOne("Data.Entities.UserWishlist", "UserWishlist")
                        .WithMany("Wishlists")
                        .HasForeignKey("UserWishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.WishlistImage", "WishlistImage")
                        .WithOne("Wishlist")
                        .HasForeignKey("Data.Entities.Wishlist", "WishlistImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("UserWishlist");

                    b.Navigation("WishlistImage");
                });

            modelBuilder.Entity("Data.Entities.WishlistAccommodations", b =>
                {
                    b.HasOne("Data.Entities.WishlistAccommodationImages", "WishlistAccommodationImages")
                        .WithOne("WishlistAccommodations")
                        .HasForeignKey("Data.Entities.WishlistAccommodations", "WishlistAccomidationImagesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.Wishlist", "Wishlist")
                        .WithMany("WishlistAccommodations")
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wishlist");

                    b.Navigation("WishlistAccommodationImages");
                });

            modelBuilder.Entity("Data.Entities.WishlistLocations", b =>
                {
                    b.HasOne("Data.Entities.Wishlist", "Wishlist")
                        .WithMany("WishlistLocations")
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.WishlistLocationImages", "WishlistLocationImages")
                        .WithOne("WishlistLocations")
                        .HasForeignKey("Data.Entities.WishlistLocations", "WishlistLocationImagesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Wishlist");

                    b.Navigation("WishlistLocationImages");
                });

            modelBuilder.Entity("Data.Entities.WishlistNotes", b =>
                {
                    b.HasOne("Data.Entities.Wishlist", "Wishlist")
                        .WithMany("WishlistNotes")
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.WishlistNoteImages", "WishlistNoteImages")
                        .WithOne("WishlistNotes")
                        .HasForeignKey("Data.Entities.WishlistNotes", "WishlistNoteImagesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Wishlist");

                    b.Navigation("WishlistNoteImages");
                });

            modelBuilder.Entity("Data.Entities.Journal", b =>
                {
                    b.Navigation("DayIds");
                });

            modelBuilder.Entity("Data.Entities.JournalImages", b =>
                {
                    b.Navigation("Journal")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Navigation("UserJournals");

                    b.Navigation("UserWishlists");
                });

            modelBuilder.Entity("Data.Entities.UserImage", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.UserJournal", b =>
                {
                    b.Navigation("Journals");
                });

            modelBuilder.Entity("Data.Entities.UserWishlist", b =>
                {
                    b.Navigation("Wishlists");
                });

            modelBuilder.Entity("Data.Entities.Wishlist", b =>
                {
                    b.Navigation("WishlistAccommodations");

                    b.Navigation("WishlistLocations");

                    b.Navigation("WishlistNotes");
                });

            modelBuilder.Entity("Data.Entities.WishlistAccommodationImages", b =>
                {
                    b.Navigation("WishlistAccommodations")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.WishlistImage", b =>
                {
                    b.Navigation("Wishlist")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.WishlistLocationImages", b =>
                {
                    b.Navigation("WishlistLocations")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.WishlistNoteImages", b =>
                {
                    b.Navigation("WishlistNotes")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
