using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoftZone.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ReviewsCount = table.Column<int>(type: "int", nullable: false),
                    LikesCount = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo" },
                    { 2, "Alexandria" },
                    { 3, "Giza" },
                    { 4, "Mansoura" },
                    { 5, "Aswan" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "CityId", "Description", "ImageUrl", "LikesCount", "Name", "Rating", "ReviewsCount" },
                values: new object[,]
                {
                    { 1, 1, "At vero eos et accusamus et iusto odio dignissimos ducimus.", "assets/images/restaurant1.jpg", 50, "Restaurant 1", 5.0, 189 },
                    { 2, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "assets/images/restaurant2.jpg", 6, "Restaurant 2", 4.5, 12 },
                    { 3, 1, "Best grilled meats and oriental dishes in downtown Cairo.", "assets/images/restaurant3.jpg", 120, "Cairo Grill & BBQ", 4.7999999999999998, 310 },
                    { 4, 1, "Enjoy dining with a direct view of the Nile river.", "assets/images/restaurant1.jpg", 95, "Nile View Restaurant", 4.5999999999999996, 215 },
                    { 5, 2, "Sed ut perspiciatis unde omnis iste natus error sit voluptatem.", "assets/images/restaurant2.jpg", 1, "Restaurant 3", 4.0, 5 },
                    { 6, 2, "Fresh fish and seafood directly from the Mediterranean sea.", "assets/images/restaurant3.jpg", 340, "Alex Sea Food", 4.9000000000000004, 520 },
                    { 7, 2, "Coffee, deserts, and sea breeze.", "assets/images/restaurant1.jpg", 45, "Corniche Cafe", 4.2999999999999998, 88 },
                    { 8, 3, "Great food with a breathtaking view of the Pyramids.", "assets/images/restaurant2.jpg", 210, "Pyramids View Diner", 4.7000000000000002, 405 },
                    { 9, 3, "Authentic Egyptian fast food and traditional meals.", "assets/images/restaurant3.jpg", 78, "Giza Koshary & More", 4.2000000000000002, 150 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum has been the industry's standard dummy text ever since.", "assets/images/item1.jpg", "Item 1 (Caesar Salad)", 12m, 1 },
                    { 2, "Lorem Ipsum has been the industry's standard dummy text ever since.", "assets/images/item2.jpg", "Item 2 (Grilled Salmon)", 25m, 1 },
                    { 3, "Lorem Ipsum has been the industry's standard dummy text ever since.", "assets/images/item3.jpg", "Item 3 (Pasta Carbonara)", 17m, 1 },
                    { 4, "Lorem Ipsum has been the industry's standard dummy text ever since.", "assets/images/item4.jpg", "Item 4 (Steak Special)", 20m, 1 },
                    { 5, "Classic cheese and tomato pizza.", "assets/images/item1.jpg", "Margherita Pizza", 15m, 2 },
                    { 6, "Loaded with spicy pepperoni slices.", "assets/images/item2.jpg", "Pepperoni Pizza", 19m, 2 },
                    { 7, "Toasted bread with garlic butter and herbs.", "assets/images/item3.jpg", "Garlic Bread", 6m, 2 },
                    { 8, "Kofta, kebab, and shish tawook with rice.", "assets/images/item4.jpg", "Mixed Grill Platter", 35m, 3 },
                    { 9, "Marinated grilled chicken skewers.", "assets/images/item1.jpg", "Shish Tawook Meal", 22m, 3 },
                    { 10, "Fresh catch of the day grilled with lemon and oil.", "assets/images/item2.jpg", "Grilled Sea Bass", 40m, 6 },
                    { 11, "Jumbo shrimps cooked in a rich tomato and garlic sauce.", "assets/images/item3.jpg", "Shrimp Casserole", 38m, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantId",
                table: "MenuItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CityId",
                table: "Restaurants",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
