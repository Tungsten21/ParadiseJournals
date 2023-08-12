using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class furtherchanges4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PK_Wiishlists",
                table: "Wiishlists");

            migrationBuilder.RenameTable(
                name: "Wiishlists",
                newName: "Wishlists");

            migrationBuilder.RenameIndex(
                name: "IX_Wiishlists_WishlistImageId",
                table: "Wishlists",
                newName: "IX_Wishlists_WishlistImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Wiishlists_UserWishlistId",
                table: "Wishlists",
                newName: "IX_Wishlists_UserWishlistId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserJournalId",
                table: "Journals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists",
                column: "Id");

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
                name: "FK_Wishlists_UserWishlists_UserWishlistId",
                table: "Wishlists",
                column: "UserWishlistId",
                principalTable: "UserWishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_WishlistImages_WishlistImageId",
                table: "Wishlists",
                column: "WishlistImageId",
                principalTable: "WishlistImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Wishlists_UserWishlists_UserWishlistId",
                table: "Wishlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_WishlistImages_WishlistImageId",
                table: "Wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists");

            migrationBuilder.RenameTable(
                name: "Wishlists",
                newName: "Wiishlists");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_WishlistImageId",
                table: "Wiishlists",
                newName: "IX_Wiishlists_WishlistImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_UserWishlistId",
                table: "Wiishlists",
                newName: "IX_Wiishlists_UserWishlistId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserJournalId",
                table: "Journals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wiishlists",
                table: "Wiishlists",
                column: "Id");

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
    }
}
