using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestMovies.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public Customer(int id, string fullname)
        {
            this.Id = id;
            this.FullName = fullname;
        }
    }
    
}
