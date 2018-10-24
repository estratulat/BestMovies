using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestMovies.Controllers
{
    public class MovieController : Controller
    {
        IList<Movie> movies = new List<Movie> { new Movie(1, "M1"), new Movie(2, "M2") };
        public IActionResult Index()
        {
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            if (movies.Count >= id && id != 0)
                return View(movies[id - 1]);
            else
            {
                return NotFound();
            }
        }
    }
}