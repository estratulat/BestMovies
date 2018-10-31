using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.Controllers
{
    public class CustomersController : Controller
    {
        private readonly BestMoviesBDContext _context;
        public CustomersController(BestMoviesBDContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Customers.Include(c => c.MembershipType).ToList());
        }
        public IActionResult Details(int id)
        {
            var customers = _context.Customers.ToList();
            if (customers.Count >= id && id!=0)
                return View(customers[id-1]);
            else
            {
                return NotFound();
            }
        }
    }
}