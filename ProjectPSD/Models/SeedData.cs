using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectPSD.Data;
using ProjectPSD.Models;
using System;
using System.Linq;

namespace ProjectPSD.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectPSDContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProjectPSDContext>>()))
            {
                // Look for any product.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        ProductName = "Chicken Wings",
                        ImagePath = "chickenwings.jpg",
                        Price = 35000,
                        CategoryID = 1
                    },
                    new Product
                    {
                        ProductName = "Onion Rings",
                        ImagePath = "onionrings.jpg",
                        Price = 27000,
                        CategoryID = 1
                    },
                    new Product
                    {
                        ProductName = "Cheesy Onion Rings",
                        ImagePath = "cheesyonion.jpg",
                        Price = 35000,
                        CategoryID = 1
                    },
                    new Product
                    {
                        ProductName = "French Fries",
                        ImagePath = "frenchfries.jpg",
                        Price = 20000,
                        CategoryID = 1
                    },
                    new Product
                    {
                        ProductName = "Loaded Fries",
                        ImagePath = "loadedfrenchfries.jpg",
                        Price = 27000,
                        CategoryID = 1
                    },
                    new Product
                    {
                        ProductName = "Truffle Fries",
                        ImagePath = "trufflefries.jpg",
                        Price = 27000,
                        CategoryID = 1
                    },
                    new Product
                    {
                        ProductName = "Potato Wedges",
                        ImagePath = "potatowedges.jpg",
                        Price = 87000,
                        CategoryID = 1
                    },
                    new Product
                    {
                        ProductName = "Beef Steak",
                        ImagePath = "beefsteak.jpg",
                        Price = 87000,
                        CategoryID = 2
                    },
                    new Product
                    {
                        ProductName = "Chicken Cordon Bleu",
                        ImagePath = "chickencordonbleu.jpg",
                        Price = 67000,
                        CategoryID = 2
                    },
                    new Product
                    {
                        ProductName = "Oyakodon",
                        ImagePath = "oyakodon.jpg",
                        Price = 54000,
                        CategoryID = 2
                    },
                    new Product
                    {
                        ProductName = "Chicken Teriyaki",
                        ImagePath = "chickenteriyaki.jpg",
                        Price = 57000,
                        CategoryID = 2
                    },
                    new Product
                    {
                        ProductName = "Beef Teriyaki",
                        ImagePath = "beefteriyaki.jpg",
                        Price = 65000,
                        CategoryID = 2
                    },
                    new Product
                    {
                        ProductName = "Chicken Teppanyaki",
                        ImagePath = "chickenteppanyaki.jpg",
                        Price = 60000,
                        CategoryID = 2
                    },
                    new Product
                    {
                        ProductName = "Beef Teppanyaki",
                        ImagePath = "beefteppanyaki.jpg",
                        Price = 67000,
                        CategoryID = 2
                    },
                    new Product
                    {
                        ProductName = "Lamian",
                        ImagePath = "lamian.jpg",
                        Price = 45000,
                        CategoryID = 2
                    },
                    new Product
                    {
                        ProductName = "Spaghetti Carbonara",
                        ImagePath = "spaghetticarbonara.jpg",
                        Price = 42000,
                        CategoryID = 2
                    },
                    new Product
                    {
                        ProductName = "Spaghetti Aglio e Olio",
                        ImagePath = "spaghettiaglioeolio.jpg",
                        Price = 50000,
                        CategoryID = 2
                    },
                    new Product
                    {
                        ProductName = "Oxtail Soup",
                        ImagePath = "oxtailsoup.jpg",
                        Price = 40000,
                        CategoryID = 3
                    },
                    new Product
                    {
                        ProductName = "Corn Cream Soup",
                        ImagePath = "corncreamsoup.jpg",
                        Price = 32000,
                        CategoryID = 3
                    },
                    new Product
                    {
                        ProductName = "Mushroom Soup",
                        ImagePath = "mushroomsoup.jpg",
                        Price = 33000,
                        CategoryID = 3
                    },
                    new Product
                    {
                        ProductName = "Chocolate Lava Cake",
                        ImagePath = "chocolatelavacake.jpg",
                        Price = 27000,
                        CategoryID = 4
                    },
                    new Product
                    {
                        ProductName = "Mousse",
                        ImagePath = "mousse.jpg",
                        Price = 25000,
                        CategoryID = 4
                    },
                    new Product
                    {
                        ProductName = "Softcream",
                        ImagePath = "softcream.png",
                        Price = 15000,
                        CategoryID = 4
                    },
                    new Product
                    {
                        ProductName = "Milk Shake",
                        ImagePath = "milkshake.jpg",
                        Price = 17000,
                        CategoryID = 5
                    },
                    new Product
                    {
                        ProductName = "Soft Drink",
                        ImagePath = "softdrink.jpg",
                        Price = 8000,
                        CategoryID = 5
                    },
                    new Product
                    {
                        ProductName = "Iced Tea",
                        ImagePath = "icedtea.jpg",
                        Price = 8000,
                        CategoryID = 5
                    },
                    new Product
                    {
                        ProductName = "Hot Tea",
                        ImagePath = "hottea.jpg",
                        Price = 6000,
                        CategoryID = 5
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
