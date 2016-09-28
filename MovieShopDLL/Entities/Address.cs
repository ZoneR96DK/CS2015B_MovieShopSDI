using System.ComponentModel.DataAnnotations;

namespace MovieShopDLL.Entities
{
    public class Address : AbstractEntity
    {
        [Required]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required]
        [Display(Name = "Street Name")]
        public string StreetNumber { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public int ZipCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}