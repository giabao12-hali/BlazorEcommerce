﻿namespace BlazorEcommerce.Server.Data
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Id = 1,
					Title = "Assassin's Creed Unity",
					Description = "Assassin's Creed Unity is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It was released in November 2014 for PlayStation 4, Windows, and Xbox One, and in December 2020 for Stadia. It is the eighth major installment in the Assassin's Creed series, and the successor to 2013's Assassin's Creed IV: Black Flag. It also has ties to Assassin's Creed Rogue, which was released for the previous generation consoles on the same day as Unity.",
					ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/41/Assassin%27s_Creed_Unity_cover.jpg",
					Price = 6.99m
				},
				new Product
				{
					Id = 2,
					Title = "Red Dead Redemption 2",
					Description = "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead Redemption. The story is set in a fictionalized representation of the United States in 1899 and follows the exploits of Arthur Morgan, an outlaw and member of the Van der Linde gang, who must deal with the decline of the Wild West whilst attempting to survive against government forces, rival gangs, and other adversaries. The game is presented through first- and third-person perspectives, and the player may freely roam in its interactive open world. Gameplay elements include shootouts, robberies, hunting, horseback riding, interacting with non-player characters, and maintaining the character's honor rating through moral choices and deeds. A bounty system governs the response of law enforcement and bounty hunters to crimes committed by the player.",
					ImageUrl = "https://upload.wikimedia.org/wikipedia/vi/4/44/Red_Dead_Redemption_II.jpg",
					Price = 7.99m
				},
				new Product
				{
					Id = 3,
					Title = "Death Stranding",
					Description = "Death Stranding is a 2019 action game developed by Kojima Productions and published by Sony Interactive Entertainment for the PlayStation 4. It is the first game from director Hideo Kojima and Kojima Productions after their split from Konami in 2015. A Windows port licensed by Sony was released by 505 Games in July 2020. A director's cut version was released for the PlayStation 5 in September 2021, followed by a release for Windows in March 2022. A macOS version is scheduled to be released, although a release date has yet to be announced.",
					ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/22/Death_Stranding.jpg",
					Price = 9.99m
				}
				);
		}

		public DbSet<Product> Products { get; set; }
    }
}
