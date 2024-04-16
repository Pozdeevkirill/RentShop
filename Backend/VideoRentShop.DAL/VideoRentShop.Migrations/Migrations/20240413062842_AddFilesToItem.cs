using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoRentShop.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddFilesToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "FileAttachments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachments_ItemId",
                table: "FileAttachments",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachments_Items_ItemId",
                table: "FileAttachments",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachments_Items_ItemId",
                table: "FileAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FileAttachments_ItemId",
                table: "FileAttachments");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "FileAttachments");
        }
    }
}
