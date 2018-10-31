using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace BestMovies
{
    public class BestMoviesBDContext : DbContext
    {
        public BestMoviesBDContext(DbContextOptions<BestMoviesBDContext> options):base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre {Id = 1, Name = "Comedy"},
                new Genre {Id = 2, Name = "Drama"},
                new Genre {Id = 3, Name = "Sci-Fi"},
                new Genre {Id = 4, Name = "Thriller"},
            });
        }
    }
}
