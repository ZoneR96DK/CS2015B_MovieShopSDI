using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieShopDLL.Entities
{
    public class Order : AbstractEntity
    {
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public List<Movie> Movies { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}