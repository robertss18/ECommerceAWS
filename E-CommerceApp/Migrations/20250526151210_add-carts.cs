using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_CommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class addcarts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "CartItems",
            columns: new[] { "ProductId", "Quantity", "OrderId" },
            values: new object[,]
            {
                { 1, 2, 1 },
                { 3, 1, 1 },
                { 2, 1, 2 },
                { 4, 1, 3 },
                { 5, 2, 3 }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
