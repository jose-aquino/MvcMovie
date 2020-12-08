using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "R",
                        Price = 7.99M,
                        Path = "/images/The_R.M._poster.jpg"
                    },

                    new Movie
                    {
                        Title = "The RM ",
                        ReleaseDate = DateTime.Parse("2005-3-13"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 8.99M,
                        Path = "/images/The_R.M._poster.jpg"
                    },

                    new Movie
                    {
                        Title = "Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("1999-2-23"),
                        Genre = "Drama",
                        Rating = "R",
                        Price = 9.99M,
                        Path = "/images/OtherSideofHeaven.jfif"
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2013-4-15"),
                        Genre = "Documental",
                        Rating = "PG",
                        Price = 3.99M,
                        Path = "/images/MeetTheMormons.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}