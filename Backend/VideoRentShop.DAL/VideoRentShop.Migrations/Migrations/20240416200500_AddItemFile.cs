using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoRentShop.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddItemFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachments_Items_ItemId",
                table: "FileAttachments");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "FileAttachments",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachments_Items_ItemId",
                table: "FileAttachments",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachments_Items_ItemId",
                table: "FileAttachments");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "FileAttachments");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachments_Items_ItemId",
                table: "FileAttachments",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
