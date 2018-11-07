using System.ComponentModel.DataAnnotations;

namespace BestMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public int GenreId { get; set; }
        [Range(1, 20, ErrorMessage = "Value must be between 1 and 20")]
        public int InStock { get; set; }

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
