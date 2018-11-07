using BestMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BestMovies.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class MovieController : Controller
    {
        private readonly BestMoviesBDContext _context;

        public MovieController(BestMoviesBDContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //SeedBestMoviesDB.ExecuteOn(_context);

            return View(_context.Movies.Include(m => m.Genre).ToList());
        }
        public IActionResult Details(int id)
        {
            var movies = _context.Movies.ToList();
            if (movies.Count >= id && id != 0)
                return View(movies[id - 1]);
            else
            {
                return NotFound();
            }
        }
        public IActionResult Create()
        {
            var genreQuery = from g in _context.Genres
                             orderby g.Name
                             select g;
            ViewBag.Genres = new SelectList(genreQuery.AsNoTracking(), "Id", "Name");
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _context.Movies
                .AsNoTracking()
                .SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            var genreQuery = from g in _context.Genres
                             orderby g.Name
                             select g;
            ViewBag.Genres = new SelectList(genreQuery.AsNoTracking(), "Id", "Name");
            return View(movie);

        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost([Bind("Title,GenreId,Id,InStock")]Movie movie)
        {
            if (movie == null)
            {
                return NotFound();
            }
            var movieToUpdate = _context.Movies
                .SingleOrDefault(m => m.Id == movie.Id);
            try
            {
                if (ModelState.IsValid)
                {
                    movieToUpdate.Title = movie.Title;
                    movieToUpdate.GenreId = movie.GenreId;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. ");
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Create([Bind("Title,GenreId,InStock")]Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Movies.Add(movie);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. ");
            }
            return RedirectToAction(nameof(Index));

        }
    }
}