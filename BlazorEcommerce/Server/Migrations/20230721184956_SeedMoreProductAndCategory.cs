using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorEcommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreProductAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 4, "Gaming Gear", "gaming-gear" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 6, 1, "Twenty-year-old Matsuri Takabayashi learns that she only has ten years to live due to an incurable disease. She decides to not dwell on her life and not to fall in love, but she meets Kazuto Manabe at a school reunion.", "https://m.media-amazon.com/images/M/MV5BMWI2OTBhODMtMGM1MC00MWJiLWE0M2UtMDY2NzQwNTQ3M2E4XkEyXkFqcGdeQXVyNTMxMzcyMzM@._V1_.jpg", 6.99m, "The Last 10 Years" },
                    { 7, 2, "Your Name (Japanese: 君の名は。, Hepburn: Kimi no Na wa) is a 2016 Japanese animated romantic fantasy film written and directed by Makoto Shinkai, produced by CoMix Wave Films and distributed by Toho. It depicts the story of high school students Taki Tachibana and Mitsuha Miyamizu, who suddenly begin to swap bodies despite having never met, unleashing chaos on each other's lives.", "https://upload.wikimedia.org/wikipedia/en/0/0b/Your_Name_poster.png", 6.99m, "Your Name" },
                    { 8, 1, "The Complete Witcher Series Box Set contains all the 8 books: 1. The Last Wish, 2. Sword of Destiny, 3. Blood of Elves, 4. Time of Contempt, 5. Baptism of Fire, 6. The Tower of The Swallow, 7. The Lady of the Lake, 8. Season of Storms", "https://m.media-amazon.com/images/I/91ygvOV8F7L._SL1500_.jpg", 84.65m, "The Complete Witcher Series (8 Books Collection Box Set)" },
                    { 4, 4, "Ultralight weight below 60grams without the perforation. Equipped with the latest flagship 26K sensor. Lag-free 2.4Hz wireless technology. Shape that is delightfully comfortable.", "https://maxpinggear.vn/wp-content/uploads/2022/11/Pulsar_Gaming_Gears-X2_Wireless_Gaming_Mouse_White_01.png", 94.95m, "Pulsar X2 Wireless Gaming Mouse" },
                    { 5, 4, "Esports has a new apex predator. As successor to the award-winning Razer Viper Ultimate, our latest evolution is more than 20% lighter and armed with all-round upgrades for enhanced performance. With one of the lightest wireless gaming mice ever, there’s now nothing holding you back.", "https://media.prod.bunnings.com.au/api/public/content/1c77462d4f244631afae5fe4d922a384?v=c347c397", 129.95m, "Razer Viper V2 Pro Wireless" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
