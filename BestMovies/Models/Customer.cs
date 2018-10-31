using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BestMovies.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public bool IsSubscribedToNewsletter { get; set; }
        [Required]
        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        public Customer()
        {
            
        }
        public Customer(int id, string fullname)
        {
            this.Id = id;
            this.FullName = fullname;
        }
        public Customer(string fullname)
        {
            this.FullName = fullname;
        }
    }
    
}
