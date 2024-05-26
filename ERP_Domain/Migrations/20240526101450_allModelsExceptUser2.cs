using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERP_Domain.Migrations
{
    public partial class allModelsExceptUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_inventory_info",
                columns: table => new
                {
                    ProductInventoryInfoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductVariantId = table.Column<long>(type: "bigint", nullable: false),
                    MinQtyInventory = table.Column<long>(type: "bigint", nullable: false),
                    MaxQtyInventory = table.Column<long>(type: "bigint", nullable: false),
                    AlertQty = table.Column<long>(type: "bigint", nullable: false),
                    InventoryQty = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_inventory_info", x => x.ProductInventoryInfoId);
                    table.ForeignKey(
                        name: "FK_product_inventory_info_product_variant_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "product_variant",
                        principalColumn: "ProductVariantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_inventory_info_ProductVariantId",
                table: "product_inventory_info",
                column: "ProductVariantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_inventory_info");
        }
    }
}
