using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatednullablefields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wishlists_WishlistImageId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_WishlistNotes_WishlistNoteImagesId",
                table: "WishlistNotes");

            migrationBuilder.DropIndex(
                name: "IX_WishlistLocations_WishlistLocationImagesId",
                table: "WishlistLocations");

            migrationBuilder.DropIndex(
                name: "IX_WishlistAccommodations_WishlistAccomidationImagesId",
                table: "WishlistAccommodations");

            migrationBuilder.DropIndex(
                name: "IX_Journals_JournalImagesId",
                table: "Journals");

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistNotesId",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistLocationsId",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistImageId",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistAccommodationsId",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistNoteImagesId",
                table: "WishlistNotes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage5",
                table: "WishlistNoteImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage4",
                table: "WishlistNoteImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage3",
                table: "WishlistNoteImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage2",
                table: "WishlistNoteImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage",
                table: "WishlistNoteImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistLocationImagesId",
                table: "WishlistLocations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Thumbnail",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage5",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage4",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage3",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage2",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistAccomidationImagesId",
                table: "WishlistAccommodations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Thumbnail",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage5",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage4",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage3",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage2",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "JournalImagesId",
                table: "Journals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Thumbnail",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage5",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage4",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage3",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage2",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_WishlistImageId",
                table: "Wishlists",
                column: "WishlistImageId",
                unique: true,
                filter: "[WishlistImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistNotes_WishlistNoteImagesId",
                table: "WishlistNotes",
                column: "WishlistNoteImagesId",
                unique: true,
                filter: "[WishlistNoteImagesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistLocations_WishlistLocationImagesId",
                table: "WishlistLocations",
                column: "WishlistLocationImagesId",
                unique: true,
                filter: "[WishlistLocationImagesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistAccommodations_WishlistAccomidationImagesId",
                table: "WishlistAccommodations",
                column: "WishlistAccomidationImagesId",
                unique: true,
                filter: "[WishlistAccomidationImagesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_JournalImagesId",
                table: "Journals",
                column: "JournalImagesId",
                unique: true,
                filter: "[JournalImagesId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wishlists_WishlistImageId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_WishlistNotes_WishlistNoteImagesId",
                table: "WishlistNotes");

            migrationBuilder.DropIndex(
                name: "IX_WishlistLocations_WishlistLocationImagesId",
                table: "WishlistLocations");

            migrationBuilder.DropIndex(
                name: "IX_WishlistAccommodations_WishlistAccomidationImagesId",
                table: "WishlistAccommodations");

            migrationBuilder.DropIndex(
                name: "IX_Journals_JournalImagesId",
                table: "Journals");

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistNotesId",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistLocationsId",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistImageId",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistAccommodationsId",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistNoteImagesId",
                table: "WishlistNotes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage5",
                table: "WishlistNoteImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage4",
                table: "WishlistNoteImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage3",
                table: "WishlistNoteImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage2",
                table: "WishlistNoteImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage",
                table: "WishlistNoteImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistLocationImagesId",
                table: "WishlistLocations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Thumbnail",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage5",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage4",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage3",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage2",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage",
                table: "WishlistLocationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WishlistAccomidationImagesId",
                table: "WishlistAccommodations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Thumbnail",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage5",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage4",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage3",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage2",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage",
                table: "WishlistAccommodationImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JournalImagesId",
                table: "Journals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Thumbnail",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage5",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage4",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage3",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage2",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "AdditionalImage",
                table: "JournalImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_WishlistImageId",
                table: "Wishlists",
                column: "WishlistImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistNotes_WishlistNoteImagesId",
                table: "WishlistNotes",
                column: "WishlistNoteImagesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistLocations_WishlistLocationImagesId",
                table: "WishlistLocations",
                column: "WishlistLocationImagesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistAccommodations_WishlistAccomidationImagesId",
                table: "WishlistAccommodations",
                column: "WishlistAccomidationImagesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Journals_JournalImagesId",
                table: "Journals",
                column: "JournalImagesId",
                unique: true);
        }
    }
}
