namespace BlazorEcommerce.Server.Data
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductVariant>()
				.HasKey(p => new { p.ProductId, p.ProductTypeId});

			modelBuilder.Entity<ProductType>().HasData(
					new ProductType { Id = 1, Name = "Default" },
					new ProductType { Id = 2, Name = "Paperback" },
					new ProductType { Id = 3, Name = "E-Book" },
					new ProductType { Id = 4, Name = "Audiobook" },
					new ProductType { Id = 5, Name = "Stream" },
					new ProductType { Id = 6, Name = "Blu-ray" },
					new ProductType { Id = 7, Name = "VHS" },
					new ProductType { Id = 8, Name = "PC" },
					new ProductType { Id = 9, Name = "PlayStation" },
					new ProductType { Id = 10, Name = "Xbox" }
				);

			modelBuilder.Entity<Category>().HasData(
				new Category
				{
					Id = 1,
					Name = "Books",
					Url = "books"
				},
				new Category
				{
					Id = 2,
					Name = "Movies",
					Url = "movies"
				},
				new Category
				{
					Id = 3,
					Name = "Video Games",
					Url = "video-games"
				},
				new Category
				{
					Id=4,
					Name = "Gaming Gear",
					Url = "gaming-gear"
				}
				);

			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Id = 1,
					Title = "Assassin's Creed Unity",
					Description = "Assassin's Creed Unity is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It was released in November 2014 for PlayStation 4, Windows, and Xbox One, and in December 2020 for Stadia. It is the eighth major installment in the Assassin's Creed series, and the successor to 2013's Assassin's Creed IV: Black Flag. It also has ties to Assassin's Creed Rogue, which was released for the previous generation consoles on the same day as Unity.",
					ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/41/Assassin%27s_Creed_Unity_cover.jpg",
					CategoryId = 3,
					Featured = true
				},
				new Product
				{
					Id = 2,
					Title = "Red Dead Redemption 2",
					Description = "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead Redemption. The story is set in a fictionalized representation of the United States in 1899 and follows the exploits of Arthur Morgan, an outlaw and member of the Van der Linde gang, who must deal with the decline of the Wild West whilst attempting to survive against government forces, rival gangs, and other adversaries. The game is presented through first- and third-person perspectives, and the player may freely roam in its interactive open world. Gameplay elements include shootouts, robberies, hunting, horseback riding, interacting with non-player characters, and maintaining the character's honor rating through moral choices and deeds. A bounty system governs the response of law enforcement and bounty hunters to crimes committed by the player.",
					ImageUrl = "https://upload.wikimedia.org/wikipedia/vi/4/44/Red_Dead_Redemption_II.jpg",
					CategoryId = 1,
				},
				new Product
				{
					Id = 3,
					Title = "Death Stranding",
					Description = "Death Stranding is a 2019 action game developed by Kojima Productions and published by Sony Interactive Entertainment for the PlayStation 4. It is the first game from director Hideo Kojima and Kojima Productions after their split from Konami in 2015. A Windows port licensed by Sony was released by 505 Games in July 2020. A director's cut version was released for the PlayStation 5 in September 2021, followed by a release for Windows in March 2022. A macOS version is scheduled to be released, although a release date has yet to be announced.",
					ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/22/Death_Stranding.jpg",
					CategoryId = 2,
					Featured = true
				},
				new Product
				{
					Id = 4,
					Title = "Pulsar X2 Wireless Gaming Mouse",
					Description = "Ultralight weight below 60grams without the perforation. Equipped with the latest flagship 26K sensor. Lag-free 2.4Hz wireless technology. Shape that is delightfully comfortable.",
					ImageUrl = "https://maxpinggear.vn/wp-content/uploads/2022/11/Pulsar_Gaming_Gears-X2_Wireless_Gaming_Mouse_White_01.png",
					CategoryId = 4,
				},
				new Product
				{
					Id = 5,
					Title = "Razer Viper V2 Pro Wireless",
					Description = "Esports has a new apex predator. As successor to the award-winning Razer Viper Ultimate, our latest evolution is more than 20% lighter and armed with all-round upgrades for enhanced performance. With one of the lightest wireless gaming mice ever, there’s now nothing holding you back.",
					ImageUrl = "https://media.prod.bunnings.com.au/api/public/content/1c77462d4f244631afae5fe4d922a384?v=c347c397",
					CategoryId = 4,
				},
				new Product
				{
					Id = 6,
					Title = "The Last 10 Years",
					Description = "Twenty-year-old Matsuri Takabayashi learns that she only has ten years to live due to an incurable disease. She decides to not dwell on her life and not to fall in love, but she meets Kazuto Manabe at a school reunion.",
					ImageUrl = "https://m.media-amazon.com/images/M/MV5BMWI2OTBhODMtMGM1MC00MWJiLWE0M2UtMDY2NzQwNTQ3M2E4XkEyXkFqcGdeQXVyNTMxMzcyMzM@._V1_.jpg",
					CategoryId = 1
				},
				new Product
				{
					Id = 7,
					Title = "Your Name",
					Description = "Your Name (Japanese: 君の名は。, Hepburn: Kimi no Na wa) is a 2016 Japanese animated romantic fantasy film written and directed by Makoto Shinkai, produced by CoMix Wave Films and distributed by Toho. It depicts the story of high school students Taki Tachibana and Mitsuha Miyamizu, who suddenly begin to swap bodies despite having never met, unleashing chaos on each other's lives.",
					ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0b/Your_Name_poster.png",
					CategoryId = 2,
					Featured = true
				},
				new Product
				{
					Id = 8,
					Title = "The Complete Witcher Series (8 Books Collection Box Set)",
					Description = "The Complete Witcher Series Box Set contains all the 8 books: 1. The Last Wish, 2. Sword of Destiny, 3. Blood of Elves, 4. Time of Contempt, 5. Baptism of Fire, 6. The Tower of The Swallow, 7. The Lady of the Lake, 8. Season of Storms",
					ImageUrl = "https://m.media-amazon.com/images/I/91ygvOV8F7L._SL1500_.jpg",
					CategoryId = 1
				}
				);;

			modelBuilder.Entity<ProductVariant>().HasData(
				new ProductVariant
				{
					ProductId = 1,
					ProductTypeId = 9,
					Price = 9.99m,
					OriginalPrice = 19.99m
				},
				new ProductVariant
				{
					ProductId = 1,
					ProductTypeId = 8,
					Price = 7.99m
				},
				new ProductVariant
				{
					ProductId = 1,
					ProductTypeId = 10,
					Price = 19.99m,
					OriginalPrice = 29.99m
				},
				new ProductVariant
				{
					ProductId = 2,
					ProductTypeId = 2,
					Price = 7.99m,
					OriginalPrice = 14.99m
				},
				new ProductVariant
				{
					ProductId = 3,
					ProductTypeId = 6,
					Price = 6.99m
				},
				new ProductVariant
				{
					ProductId = 4,
					ProductTypeId = 8,
					Price = 94.95m
				},
				new ProductVariant
				{
					ProductId = 5,
					ProductTypeId = 8,
					Price = 129.95m,
				},
				new ProductVariant
				{
					ProductId = 6,
					ProductTypeId = 2,
					Price = 2.99m
				},
				new ProductVariant
				{
					ProductId = 7,
					ProductTypeId = 5,
					Price = 19.99m,
					OriginalPrice = 29.99m
				},
				new ProductVariant
				{
					ProductId = 7,
					ProductTypeId = 7,
					Price = 69.99m
				},
				new ProductVariant
				{
					ProductId = 7,
					ProductTypeId = 6,
					Price = 49.99m,
					OriginalPrice = 59.99m
				},
				new ProductVariant
				{
					ProductId = 8,
					ProductTypeId = 1,
					Price = 84.65m,
					OriginalPrice = 99.95m,
				});
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<ProductVariant> ProductVariants { get; set; }
    }
}
