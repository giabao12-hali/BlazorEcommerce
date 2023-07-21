﻿// <auto-generated />
using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230721184956_SeedMoreProductAndCategory")]
    partial class SeedMoreProductAndCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorEcommerce.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Books",
                            Url = "books"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Movies",
                            Url = "movies"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Video Games",
                            Url = "video-games"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Gaming Gear",
                            Url = "gaming-gear"
                        });
                });

            modelBuilder.Entity("BlazorEcommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 3,
                            Description = "Assassin's Creed Unity is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It was released in November 2014 for PlayStation 4, Windows, and Xbox One, and in December 2020 for Stadia. It is the eighth major installment in the Assassin's Creed series, and the successor to 2013's Assassin's Creed IV: Black Flag. It also has ties to Assassin's Creed Rogue, which was released for the previous generation consoles on the same day as Unity.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/41/Assassin%27s_Creed_Unity_cover.jpg",
                            Price = 6.99m,
                            Title = "Assassin's Creed Unity"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead Redemption. The story is set in a fictionalized representation of the United States in 1899 and follows the exploits of Arthur Morgan, an outlaw and member of the Van der Linde gang, who must deal with the decline of the Wild West whilst attempting to survive against government forces, rival gangs, and other adversaries. The game is presented through first- and third-person perspectives, and the player may freely roam in its interactive open world. Gameplay elements include shootouts, robberies, hunting, horseback riding, interacting with non-player characters, and maintaining the character's honor rating through moral choices and deeds. A bounty system governs the response of law enforcement and bounty hunters to crimes committed by the player.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/vi/4/44/Red_Dead_Redemption_II.jpg",
                            Price = 7.99m,
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Death Stranding is a 2019 action game developed by Kojima Productions and published by Sony Interactive Entertainment for the PlayStation 4. It is the first game from director Hideo Kojima and Kojima Productions after their split from Konami in 2015. A Windows port licensed by Sony was released by 505 Games in July 2020. A director's cut version was released for the PlayStation 5 in September 2021, followed by a release for Windows in March 2022. A macOS version is scheduled to be released, although a release date has yet to be announced.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/22/Death_Stranding.jpg",
                            Price = 9.99m,
                            Title = "Death Stranding"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "Ultralight weight below 60grams without the perforation. Equipped with the latest flagship 26K sensor. Lag-free 2.4Hz wireless technology. Shape that is delightfully comfortable.",
                            ImageUrl = "https://maxpinggear.vn/wp-content/uploads/2022/11/Pulsar_Gaming_Gears-X2_Wireless_Gaming_Mouse_White_01.png",
                            Price = 94.95m,
                            Title = "Pulsar X2 Wireless Gaming Mouse"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 4,
                            Description = "Esports has a new apex predator. As successor to the award-winning Razer Viper Ultimate, our latest evolution is more than 20% lighter and armed with all-round upgrades for enhanced performance. With one of the lightest wireless gaming mice ever, there’s now nothing holding you back.",
                            ImageUrl = "https://media.prod.bunnings.com.au/api/public/content/1c77462d4f244631afae5fe4d922a384?v=c347c397",
                            Price = 129.95m,
                            Title = "Razer Viper V2 Pro Wireless"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Description = "Twenty-year-old Matsuri Takabayashi learns that she only has ten years to live due to an incurable disease. She decides to not dwell on her life and not to fall in love, but she meets Kazuto Manabe at a school reunion.",
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BMWI2OTBhODMtMGM1MC00MWJiLWE0M2UtMDY2NzQwNTQ3M2E4XkEyXkFqcGdeQXVyNTMxMzcyMzM@._V1_.jpg",
                            Price = 6.99m,
                            Title = "The Last 10 Years"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "Your Name (Japanese: 君の名は。, Hepburn: Kimi no Na wa) is a 2016 Japanese animated romantic fantasy film written and directed by Makoto Shinkai, produced by CoMix Wave Films and distributed by Toho. It depicts the story of high school students Taki Tachibana and Mitsuha Miyamizu, who suddenly begin to swap bodies despite having never met, unleashing chaos on each other's lives.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0b/Your_Name_poster.png",
                            Price = 6.99m,
                            Title = "Your Name"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Description = "The Complete Witcher Series Box Set contains all the 8 books: 1. The Last Wish, 2. Sword of Destiny, 3. Blood of Elves, 4. Time of Contempt, 5. Baptism of Fire, 6. The Tower of The Swallow, 7. The Lady of the Lake, 8. Season of Storms",
                            ImageUrl = "https://m.media-amazon.com/images/I/91ygvOV8F7L._SL1500_.jpg",
                            Price = 84.65m,
                            Title = "The Complete Witcher Series (8 Books Collection Box Set)"
                        });
                });

            modelBuilder.Entity("BlazorEcommerce.Shared.Product", b =>
                {
                    b.HasOne("BlazorEcommerce.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}