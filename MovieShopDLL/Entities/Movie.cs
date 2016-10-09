using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopDLL.Entities
{
    public class Movie : AbstractEntity
    {
        [Required]
        public string Title { get; set; }

        public DateTime Year { get; set; }

        public double Price { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Trailer URL")]
        public string TrailerUrl { get; set; }

        public Genre Genre { get; set; }

        public List<Order> Orders { get; set; }
    }
}