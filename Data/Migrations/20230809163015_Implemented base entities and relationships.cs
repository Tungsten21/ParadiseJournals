using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Implementedbaseentitiesandrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Journals",
                newName: "UserJournalId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserImageId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserJournalsId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserWishlistId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JournalImagesId",
                table: "Journals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "JournalImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Thumbnail = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage3 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage4 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage5 = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserJournal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJournal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserJournal_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWishlist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWishlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWishlist_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistAccommodationImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistAccommodationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Thumbnail = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage3 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage4 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage5 = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistAccommodationImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishlistImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishlistLocationImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistLocationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Thumbnail = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage3 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage4 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage5 = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistLocationImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishlistNoteImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistNotesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage3 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage4 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdditionalImage5 = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistNoteImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserWishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistAccommodationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistLocationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistNotesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_UserWishlist_UserWishlistId",
                        column: x => x.UserWishlistId,
                        principalTable: "UserWishlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlists_WishlistImage_WishlistImageId",
                        column: x => x.WishlistImageId,
                        principalTable: "WishlistImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistAccommodations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistAccomidationImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistAccommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistAccommodations_WishlistAccommodationImages_WishlistAccomidationImagesId",
                        column: x => x.WishlistAccomidationImagesId,
                        principalTable: "WishlistAccommodationImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistAccommodations_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistLocationImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryCode = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    PricePerPerson = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistLocations_WishlistLocationImages_WishlistLocationImagesId",
                        column: x => x.WishlistLocationImagesId,
                        principalTable: "WishlistLocationImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistLocations_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistNoteImagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistNotes_WishlistNoteImages_WishlistNoteImagesId",
                        column: x => x.WishlistNoteImagesId,
                        principalTable: "WishlistNoteImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistNotes_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserImageId",
                table: "Users",
                column: "UserImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Journals_JournalImagesId",
                table: "Journals",
                column: "JournalImagesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Journals_UserJournalId",
                table: "Journals",
                column: "UserJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJournal_OwnerId",
                table: "UserJournal",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlist_OwnerId",
                table: "UserWishlist",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistAccommodations_WishlistAccomidationImagesId",
                table: "WishlistAccommodations",
                column: "WishlistAccomidationImagesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistAccommodations_WishlistId",
                table: "WishlistAccommodations",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistLocations_WishlistId",
                table: "WishlistLocations",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistLocations_WishlistLocationImagesId",
                table: "WishlistLocations",
                column: "WishlistLocationImagesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistNotes_WishlistId",
                table: "WishlistNotes",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistNotes_WishlistNoteImagesId",
                table: "WishlistNotes",
                column: "WishlistNoteImagesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserWishlistId",
                table: "Wishlists",
                column: "UserWishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_WishlistImageId",
                table: "Wishlists",
                column: "WishlistImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_JournalImages_JournalImagesId",
                table: "Journals",
                column: "JournalImagesId",
                principalTable: "JournalImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_UserJournal_UserJournalId",
                table: "Journals",
                column: "UserJournalId",
                principalTable: "UserJournal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserImage_UserImageId",
                table: "Users",
                column: "UserImageId",
                principalTable: "UserImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journals_JournalImages_JournalImagesId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_Journals_UserJournal_UserJournalId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserImage_UserImageId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "JournalImages");

            migrationBuilder.DropTable(
                name: "UserImage");

            migrationBuilder.DropTable(
                name: "UserJournal");

            migrationBuilder.DropTable(
                name: "WishlistAccommodations");

            migrationBuilder.DropTable(
                name: "WishlistLocations");

            migrationBuilder.DropTable(
                name: "WishlistNotes");

            migrationBuilder.DropTable(
                name: "WishlistAccommodationImages");

            migrationBuilder.DropTable(
                name: "WishlistLocationImages");

            migrationBuilder.DropTable(
                name: "WishlistNoteImages");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "UserWishlist");

            migrationBuilder.DropTable(
                name: "WishlistImage");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserImageId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Journals_JournalImagesId",
                table: "Journals");

            migrationBuilder.DropIndex(
                name: "IX_Journals_UserJournalId",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "UserImageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserJournalsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserWishlistId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JournalImagesId",
                table: "Journals");

            migrationBuilder.RenameColumn(
                name: "UserJournalId",
                table: "Journals",
                newName: "Owner");
        }
    }
}
