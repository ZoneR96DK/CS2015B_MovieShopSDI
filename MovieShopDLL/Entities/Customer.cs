using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ExceptionServices;

namespace MovieShopDLL.Entities
{
    public class Customer : AbstractEntity
    {
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public Address Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}