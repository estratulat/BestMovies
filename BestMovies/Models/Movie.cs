using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BestMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        public Movie()
        {
            
        }
        public Movie(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public Movie(string title)
        {
            Title = title;
        }
    }
}
