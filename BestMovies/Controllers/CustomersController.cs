using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestMovies.Controllers
{
    public class CustomersController : Controller
    {
        IList<Customer> customers = new List<Customer> { new Customer(1, "John Smith"), new Customer(2, "Marry Williams") };
        public IActionResult Index()
        {
            return View(customers);
        }
        public IActionResult Details(int id)
        {
            if (customers.Count >= id && id!=0)
                return View(customers[id-1]);
            else
            {
                return NotFound();
            }
        }
    }
}