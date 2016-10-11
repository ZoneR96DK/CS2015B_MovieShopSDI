using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopDLL.Entities
{
    public class Order : AbstractEntity
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        //[Required]
        public Customer Customer { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        //[Required]
        public Movie Movie { get; set; }

        //[Required]
        public DateTime Date { get; set; }
    }
}