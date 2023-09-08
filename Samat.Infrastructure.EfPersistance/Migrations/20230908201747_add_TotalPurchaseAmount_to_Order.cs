using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samat.Infrastructure.EfPersistance.Migrations
{
    /// <inheritdoc />
    public partial class add_TotalPurchaseAmount_to_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPurchaseAmount",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPurchaseAmount",
                table: "Order");
        }
    }
}
