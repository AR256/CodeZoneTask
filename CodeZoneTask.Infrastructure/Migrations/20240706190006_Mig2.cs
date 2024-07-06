using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeZoneTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_StoreId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => new { x.StoreId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_StoreItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreItems_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreItems_ItemId",
                table: "StoreItems",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreItems");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_StoreId",
                table: "Items",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
