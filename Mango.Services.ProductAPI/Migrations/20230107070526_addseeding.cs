using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class addseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "its tast good with spicy tast", "https://micodotnet.blob.core.windows.net/mango/samosa.jpg", "Samosa", 15.0 },
                    { 2, "Appetizer", "hello this taste spicy and cold ", "https://micodotnet.blob.core.windows.net/mango/Paneer%20tikka.jpg", "Paneer Tikka", 13.99 },
                    { 3, "Dessert", "This is good in taste with heavy gulp and fried ", "https://micodotnet.blob.core.windows.net/mango/sweet%20pie.jpg", "Sweet Pie", 10.99 },
                    { 4, "Entree", "This is tasty with lots to full a stomach", "https://micodotnet.blob.core.windows.net/mango/pav%20bhaji.jpg", "Pav Bhaji", 15.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
