using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserJournalsUserWishlists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journals_UserJournals_UserJournalId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_UserWishlists_UserWishlistId",
                table: "Wishlists");

            migrationBuilder.DropTable(
                name: "UserJournals");

            migrationBuilder.DropTable(
                name: "UserWishlists");

            migrationBuilder.DropColumn(
                name: "UserJournalsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserWishlistId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserWishlistId",
                table: "Wishlists",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_UserWishlistId",
                table: "Wishlists",
                newName: "IX_Wishlists_OwnerId");

            migrationBuilder.RenameColumn(
                name: "UserJournalId",
                table: "Journals",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Journals_UserJournalId",
                table: "Journals",
                newName: "IX_Journals_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Users_OwnerId",
                table: "Journals",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Users_OwnerId",
                table: "Wishlists",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journals_Users_OwnerId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Users_OwnerId",
                table: "Wishlists");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Wishlists",
                newName: "UserWishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_OwnerId",
                table: "Wishlists",
                newName: "IX_Wishlists_UserWishlistId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Journals",
                newName: "UserJournalId");

            migrationBuilder.RenameIndex(
                name: "IX_Journals_OwnerId",
                table: "Journals",
                newName: "IX_Journals_UserJournalId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserJournalsId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserWishlistId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserJournals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserJournals_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWishlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWishlists_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserJournals_OwnerId",
                table: "UserJournals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlists_OwnerId",
                table: "UserWishlists",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_UserJournals_UserJournalId",
                table: "Journals",
                column: "UserJournalId",
                principalTable: "UserJournals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_UserWishlists_UserWishlistId",
                table: "Wishlists",
                column: "UserWishlistId",
                principalTable: "UserWishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
