using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftZone.DAL
{
    public class RestaurantSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // 1. Cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Cairo" },
                new City { Id = 2, Name = "Alexandria" },
                new City { Id = 3, Name = "Giza" },
                new City { Id = 4, Name = "Mansoura" },
                new City { Id = 5, Name = "Aswan" }
            );

            // 2. Restaurants
            modelBuilder.Entity<Restaurant>().HasData(
                // Cairo (CityId = 1)
                new Restaurant { Id = 1, Name = "Restaurant 1", CityId = 1, Description = "At vero eos et accusamus et iusto odio dignissimos ducimus.", Rating = 5.0, LikesCount = 50, ReviewsCount = 189, ImageUrl = "assets/images/restaurant1.jpg" },
                new Restaurant { Id = 2, Name = "Restaurant 2", CityId = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Rating = 4.5, LikesCount = 06, ReviewsCount = 12, ImageUrl = "assets/images/restaurant2.jpg" },
                new Restaurant { Id = 3, Name = "Cairo Grill & BBQ", CityId = 1, Description = "Best grilled meats and oriental dishes in downtown Cairo.", Rating = 4.8, LikesCount = 120, ReviewsCount = 310, ImageUrl = "assets/images/restaurant3.jpg" },
                new Restaurant { Id = 4, Name = "Nile View Restaurant", CityId = 1, Description = "Enjoy dining with a direct view of the Nile river.", Rating = 4.6, LikesCount = 95, ReviewsCount = 215, ImageUrl = "assets/images/restaurant1.jpg" },

                // Alexandria (CityId = 2)
                new Restaurant { Id = 5, Name = "Restaurant 3", CityId = 2, Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem.", Rating = 4.0, LikesCount = 01, ReviewsCount = 05, ImageUrl = "assets/images/restaurant2.jpg" },
                new Restaurant { Id = 6, Name = "Alex Sea Food", CityId = 2, Description = "Fresh fish and seafood directly from the Mediterranean sea.", Rating = 4.9, LikesCount = 340, ReviewsCount = 520, ImageUrl = "assets/images/restaurant3.jpg" },
                new Restaurant { Id = 7, Name = "Corniche Cafe", CityId = 2, Description = "Coffee, deserts, and sea breeze.", Rating = 4.3, LikesCount = 45, ReviewsCount = 88, ImageUrl = "assets/images/restaurant1.jpg" },

                // Giza (CityId = 3)
                new Restaurant { Id = 8, Name = "Pyramids View Diner", CityId = 3, Description = "Great food with a breathtaking view of the Pyramids.", Rating = 4.7, LikesCount = 210, ReviewsCount = 405, ImageUrl = "assets/images/restaurant2.jpg" },
                new Restaurant { Id = 9, Name = "Giza Koshary & More", CityId = 3, Description = "Authentic Egyptian fast food and traditional meals.", Rating = 4.2, LikesCount = 78, ReviewsCount = 150, ImageUrl = "assets/images/restaurant3.jpg" }
            );

            // 3. Menu Items (Multiple items for restaurants)
            modelBuilder.Entity<MenuItem>().HasData(
                // Restaurant 1 Items
                new MenuItem { Id = 1, RestaurantId = 1, Name = "Item 1 (Caesar Salad)", Description = "Lorem Ipsum has been the industry's standard dummy text ever since.", Price = 12, ImageUrl = "assets/images/item1.jpg" },
                new MenuItem { Id = 2, RestaurantId = 1, Name = "Item 2 (Grilled Salmon)", Description = "Lorem Ipsum has been the industry's standard dummy text ever since.", Price = 25, ImageUrl = "assets/images/item2.jpg" },
                new MenuItem { Id = 3, RestaurantId = 1, Name = "Item 3 (Pasta Carbonara)", Description = "Lorem Ipsum has been the industry's standard dummy text ever since.", Price = 17, ImageUrl = "assets/images/item3.jpg" },
                new MenuItem { Id = 4, RestaurantId = 1, Name = "Item 4 (Steak Special)", Description = "Lorem Ipsum has been the industry's standard dummy text ever since.", Price = 20, ImageUrl = "assets/images/item4.jpg" },

                // Restaurant 2 Items
                new MenuItem { Id = 5, RestaurantId = 2, Name = "Margherita Pizza", Description = "Classic cheese and tomato pizza.", Price = 15, ImageUrl = "assets/images/item1.jpg" },
                new MenuItem { Id = 6, RestaurantId = 2, Name = "Pepperoni Pizza", Description = "Loaded with spicy pepperoni slices.", Price = 19, ImageUrl = "assets/images/item2.jpg" },
                new MenuItem { Id = 7, RestaurantId = 2, Name = "Garlic Bread", Description = "Toasted bread with garlic butter and herbs.", Price = 6, ImageUrl = "assets/images/item3.jpg" },

                // Restaurant 3 Items (Cairo Grill)
                new MenuItem { Id = 8, RestaurantId = 3, Name = "Mixed Grill Platter", Description = "Kofta, kebab, and shish tawook with rice.", Price = 35, ImageUrl = "assets/images/item4.jpg" },
                new MenuItem { Id = 9, RestaurantId = 3, Name = "Shish Tawook Meal", Description = "Marinated grilled chicken skewers.", Price = 22, ImageUrl = "assets/images/item1.jpg" },

                // Alex Sea Food Items (Restaurant 6)
                new MenuItem { Id = 10, RestaurantId = 6, Name = "Grilled Sea Bass", Description = "Fresh catch of the day grilled with lemon and oil.", Price = 40, ImageUrl = "assets/images/item2.jpg" },
                new MenuItem { Id = 11, RestaurantId = 6, Name = "Shrimp Casserole", Description = "Jumbo shrimps cooked in a rich tomato and garlic sauce.", Price = 38, ImageUrl = "assets/images/item3.jpg" }
            );
        }
    }
}
