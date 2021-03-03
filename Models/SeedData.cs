using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Assign5.Models;

namespace Assign5.Models
{
    // creating data sets to fill the database
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            OidoDBContext context = application.ApplicationServices.
                CreateScope().
                ServiceProvider.GetRequiredService<OidoDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Projects.Any())
            {
                context.Projects.AddRange(
                    new Project
                    {
                        //BookId = 1, 
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorMiddle = "",
                        AuthorLast = "Hugo",
                        Pages = 1488,
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                    },

                    new Project
                    {
                        //BookId = 2,
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns",
                        AuthorLast = "Goodwin",
                        Pages = 944,
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                    },

                    new Project
                    {
                        //BookId = 3,
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorMiddle = "",
                        AuthorLast = "Schroeder",
                        Pages = 832,
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                    },

                    new Project
                    {
                        //BookId = 4,
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C",
                        AuthorLast = "White",
                        Pages = 864,
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                    },

                    new Project
                    {
                        //BookId = 5,
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorMiddle = "",
                        AuthorLast = "Hillenbrand",
                        Pages = 528,
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                    },

                    new Project
                    {
                        //BookId = 6,
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorMiddle = "",
                        AuthorLast = "Crichton",
                        Pages = 288,
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                    },

                    new Project
                    {
                        //BookId = 7,
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorMiddle = "",
                        AuthorLast = "Newport",
                        Pages = 304,
                        Publisher = "Grand Central Publishing",
                        ISBN = "978 - 1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                    },

                    new Project
                    {
                        //BookId = 8,
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorMiddle = "",
                        AuthorLast = "Abrashoff",
                        Pages = 240,
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                    },

                    new Project
                    {
                        //BookId = 9,
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorMiddle = "",
                        AuthorLast = "Branson",
                        Pages = 400,
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                    },

                    new Project
                    {
                        //BookId = 10,
                        Title = "Sycamore Row",
                        AuthorFirst = "Josh",
                        AuthorMiddle = "",
                        AuthorLast = "Grisham",
                        Pages = 642,
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                    },
                   
                    new Project
                    {
                        //BookId = 11,
                        Title = "The Far Pavilions",
                        AuthorFirst = "M",
                        AuthorMiddle = "M",
                        AuthorLast = "Kaye",
                        Pages = 1000,
                        Publisher = "Allen Lane",
                        ISBN = "978-0312151256",
                        Classification = "Fiction",
                        Category = "Novel",
                        Price = 13.99,
                    },

                    new Project
                    {
                        //BookId = 12,
                        Title = "Atlas Shrugged",
                        AuthorFirst = "Ayn",
                        AuthorMiddle = "",
                        AuthorLast = "Rand",
                        Pages = 1395,
                        Publisher = "Random House",
                        ISBN = "978-0451191144",
                        Classification = "Fiction",
                        Category = "Novel",
                        Price = 9.99,
                    },

                    new Project
                    {
                        //BookId = 13,
                        Title = "A Tale of Two Cities",
                        AuthorFirst = "Charles",
                        AuthorMiddle = "",
                        AuthorLast = "Dickens",
                        Pages = 437,
                        Publisher = "London: Chapman & Hall",
                        ISBN = "978-0141439600",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 30.00,
                    }


            );
                context.SaveChanges();
            }
        }
    }
}
