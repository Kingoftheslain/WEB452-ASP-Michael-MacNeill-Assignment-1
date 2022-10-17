﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ClocksApp.Data;

namespace ClocksApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ClocksAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ClocksAppContext>>())) 
            { 
                if (context.Clocks.Any())
                {
                    return; //DB Has already Been Seeded
                }

                context.Clocks.AddRange(
                    new Clocks
                    {
                        Name = "Silver Analog Watch",
                        ReleaseDate = DateTime.Parse("1994-3-17"),
                        Type = "Pocket Watch",
                        Price = 149.99M,
                        Rating = 3,
                        Size = "5in"
                    },

                    new Clocks
                    {
                        Name = "Gold Analog Watch",
                        ReleaseDate = DateTime.Parse("1991-7-04"),
                        Type = "Pocket Watch",
                        Price = 179.99M,
                        Rating = 4,
                        Size = "8in"
                    },

                    new Clocks
                    {
                        Name = "Apple Watch Ultra",
                        ReleaseDate = DateTime.Parse("2022-09-23"),
                        Type = "Wrist Watch",
                        Price = 1099.99M,
                        Rating = 3,
                        Size = "22mm"
                    },

                    new Clocks
                    {
                        Name = "Apple Watch",
                        ReleaseDate = DateTime.Parse("2015-4-10"),
                        Type = "Wrist Watch",
                        Price = 89.99M,
                        Rating = 3,
                        Size = "20mm"
                    },

                    new Clocks
                    {
                        Name = "Apple Watch Series 7",
                        ReleaseDate = DateTime.Parse("2021-10-15"),
                        Type = "Wrist Watch",
                        Price = 599.99M,
                        Rating = 3,
                        Size = "20mm"
                    },

                    new Clocks
                    {
                        Name = "Galaxy Watch 5",
                        ReleaseDate = DateTime.Parse("2022-8-10"),
                        Type = "Wrist Watch",
                        Price = 299.99M,
                        Rating = 4,
                        Size = "22mm"
                    },

                    new Clocks
                    {
                        Name = "Galaxy Watch 5 Pro",
                        ReleaseDate = DateTime.Parse("2022-8-26"),
                        Type = "Wrist Watch",
                        Price = 479.99M,
                        Rating = 4,
                        Size = "22mm"
                    },

                    new Clocks
                    {
                        Name = "Galaxy Watch 4 Bluetooth",
                        ReleaseDate = DateTime.Parse("2021-8-27"),
                        Type = "Wrist Watch",
                        Price = 249.99M
                    },

                    new Clocks
                    {
                        Name = "Vintage Gold Watch",
                        ReleaseDate = DateTime.Parse("1994-3-17"),
                        Type = "Pocket Watch",
                        Price = 1499.99M,
                        Rating = 5,
                        Size = "8in"
                    },

                    new Clocks
                    {
                        Name = "Vintage Silver 8in Watch",
                        ReleaseDate = DateTime.Parse("1994-3-17"),
                        Type = "Pocket Watch",
                        Price = 1249.99M,
                        Rating = 3,
                        Size = "5in"
                    } 
                    );
            }
        }
    }
}
