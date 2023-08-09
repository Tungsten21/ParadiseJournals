using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatedtablenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journals_UserJournal_UserJournalId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserJournal_Users_OwnerId",
                table: "UserJournal");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserImage_UserImageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWishlist_Users_OwnerId",
                table: "UserWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistAccommodations_Wishlists_WishlistId",
                table: "WishlistAccommodations");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistLocations_Wishlists_WishlistId",
                table: "WishlistLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistNotes_Wishlists_WishlistId",
                table: "WishlistNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_UserWishlist_UserWishlistId",
                table: "Wishlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_WishlistImage_WishlistImageId",
                table: "Wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishlistImage",
                table: "WishlistImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWishlist",
                table: "UserWishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserJournal",
                table: "UserJournal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserImage",
                table: "UserImage");

            migrationBuilder.RenameTable(
                name: "Wishlists",
                newName: "Wiishlists");

            migrationBuilder.RenameTable(
                name: "WishlistImage",
                newName: "WishlistImages");

            migrationBuilder.RenameTable(
                name: "UserWishlist",
                newName: "UserWishlists");

            migrationBuilder.RenameTable(
                name: "UserJournal",
                newName: "UserJournals");

            migrationBuilder.RenameTable(
                name: "UserImage",
                newName: "UserImages");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_WishlistImageId",
                table: "Wiishlists",
                newName: "IX_Wiishlists_WishlistImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_UserWishlistId",
                table: "Wiishlists",
                newName: "IX_Wiishlists_UserWishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWishlist_OwnerId",
                table: "UserWishlists",
                newName: "IX_UserWishlists_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserJournal_OwnerId",
                table: "UserJournals",
                newName: "IX_UserJournals_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wiishlists",
                table: "Wiishlists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishlistImages",
                table: "WishlistImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWishlists",
                table: "UserWishlists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserJournals",
                table: "UserJournals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserImages",
                table: "UserImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_UserJournals_UserJournalId",
                table: "Journals",
                column: "UserJournalId",
                principalTable: "UserJournals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserJournals_Users_OwnerId",
                table: "UserJournals",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserImages_UserImageId",
                table: "Users",
                column: "UserImageId",
                principalTable: "UserImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWishlists_Users_OwnerId",
                table: "UserWishlists",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wiishlists_UserWishlists_UserWishlistId",
                table: "Wiishlists",
                column: "UserWishlistId",
                principalTable: "UserWishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wiishlists_WishlistImages_WishlistImageId",
                table: "Wiishlists",
                column: "WishlistImageId",
                principalTable: "WishlistImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistAccommodations_Wiishlists_WishlistId",
                table: "WishlistAccommodations",
                column: "WishlistId",
                principalTable: "Wiishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistLocations_Wiishlists_WishlistId",
                table: "WishlistLocations",
                column: "WishlistId",
                principalTable: "Wiishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistNotes_Wiishlists_WishlistId",
                table: "WishlistNotes",
                column: "WishlistId",
                principalTable: "Wiishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journals_UserJournals_UserJournalId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserJournals_Users_OwnerId",
                table: "UserJournals");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserImages_UserImageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWishlists_Users_OwnerId",
                table: "UserWishlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Wiishlists_UserWishlists_UserWishlistId",
                table: "Wiishlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Wiishlists_WishlistImages_WishlistImageId",
                table: "Wiishlists");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistAccommodations_Wiishlists_WishlistId",
                table: "WishlistAccommodations");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistLocations_Wiishlists_WishlistId",
                table: "WishlistLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistNotes_Wiishlists_WishlistId",
                table: "WishlistNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishlistImages",
                table: "WishlistImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wiishlists",
                table: "Wiishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWishlists",
                table: "UserWishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserJournals",
                table: "UserJournals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserImages",
                table: "UserImages");

            migrationBuilder.RenameTable(
                name: "WishlistImages",
                newName: "WishlistImage");

            migrationBuilder.RenameTable(
                name: "Wiishlists",
                newName: "Wishlists");

            migrationBuilder.RenameTable(
                name: "UserWishlists",
                newName: "UserWishlist");

            migrationBuilder.RenameTable(
                name: "UserJournals",
                newName: "UserJournal");

            migrationBuilder.RenameTable(
                name: "UserImages",
                newName: "UserImage");

            migrationBuilder.RenameIndex(
                name: "IX_Wiishlists_WishlistImageId",
                table: "Wishlists",
                newName: "IX_Wishlists_WishlistImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Wiishlists_UserWishlistId",
                table: "Wishlists",
                newName: "IX_Wishlists_UserWishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_UserWishlists_OwnerId",
                table: "UserWishlist",
                newName: "IX_UserWishlist_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserJournals_OwnerId",
                table: "UserJournal",
                newName: "IX_UserJournal_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishlistImage",
                table: "WishlistImage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWishlist",
                table: "UserWishlist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserJournal",
                table: "UserJournal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserImage",
                table: "UserImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_UserJournal_UserJournalId",
                table: "Journals",
                column: "UserJournalId",
                principalTable: "UserJournal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserJournal_Users_OwnerId",
                table: "UserJournal",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserImage_UserImageId",
                table: "Users",
                column: "UserImageId",
                principalTable: "UserImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWishlist_Users_OwnerId",
                table: "UserWishlist",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistAccommodations_Wishlists_WishlistId",
                table: "WishlistAccommodations",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistLocations_Wishlists_WishlistId",
                table: "WishlistLocations",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistNotes_Wishlists_WishlistId",
                table: "WishlistNotes",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_UserWishlist_UserWishlistId",
                table: "Wishlists",
                column: "UserWishlistId",
                principalTable: "UserWishlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_WishlistImage_WishlistImageId",
                table: "Wishlists",
                column: "WishlistImageId",
                principalTable: "WishlistImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
