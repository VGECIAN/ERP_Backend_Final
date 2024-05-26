using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP_Domain.Migrations
{
    public partial class allModelsExceptUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_product_category_CateagoryId",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "CateagoryId",
                table: "product",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_product_CateagoryId",
                table: "product",
                newName: "IX_product_CategoryId");

            migrationBuilder.CreateTable(
                name: "product_inventory_list",
                columns: table => new
                {
                    InventoryListId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductVariantId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryLocation = table.Column<string>(type: "text", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AddedBy = table.Column<string>(type: "text", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReleasedBy = table.Column<string>(type: "text", nullable: true),
                    UOM = table.Column<int>(type: "integer", nullable: false),
                    InventoryStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_inventory_list", x => x.InventoryListId);
                    table.ForeignKey(
                        name: "FK_product_inventory_list_product_variant_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "product_variant",
                        principalColumn: "ProductVariantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_inventory_list_ProductVariantId",
                table: "product_inventory_list",
                column: "ProductVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_category_CategoryId",
                table: "product",
                column: "CategoryId",
                principalTable: "product_category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_product_category_CategoryId",
                table: "product");

            migrationBuilder.DropTable(
                name: "product_inventory_list");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "product",
                newName: "CateagoryId");

            migrationBuilder.RenameIndex(
                name: "IX_product_CategoryId",
                table: "product",
                newName: "IX_product_CateagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_category_CateagoryId",
                table: "product",
                column: "CateagoryId",
                principalTable: "product_category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
