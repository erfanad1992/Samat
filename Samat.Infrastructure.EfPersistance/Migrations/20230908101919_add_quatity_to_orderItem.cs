using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samat.Infrastructure.EfPersistance.Migrations
{
    /// <inheritdoc />
    public partial class add_quatity_to_orderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "OrderItem");
        }
    }
}
