using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Models;

namespace BestMovies
{
    public static class SeedBestMoviesDB
    {
        public static void ExecuteOn(BestMoviesBDContext context)
        {
            context.Database.EnsureCreated();
            context.MembershipTypes.AddRange(new MembershipType[]
            {
                new MembershipType("Pay as You Go", 0, 0, 0),
                new MembershipType("Monthly", 30, 1, 10),
                new MembershipType("Quarterly", 90, 4, 15),
                new MembershipType("Annual", 300, 12, 20),
            });
                
            context.SaveChanges();

        }
}
}
