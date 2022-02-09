using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieContext : DbContext
    {
        // constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            // blank for now
        }

        public DbSet<CreateMovie> responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Romance"},
                new Category { CategoryID = 2, CategoryName = "Sci-Fi" },
                new Category { CategoryID = 3, CategoryName = "Action/Adventure" }
            );

            mb.Entity<CreateMovie>().HasData(
                
                new CreateMovie
                {
                    ApplicationId = 1,
                    CategoryID =  1,
                    Title = "About Time",
                    Year = 2013,
                    Director = "Richard Curtis",
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },

                new CreateMovie
                {
                    ApplicationId = 2,
                    CategoryID = 2,
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },

                new CreateMovie
                {
                    ApplicationId = 3,
                    CategoryID = 3,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
