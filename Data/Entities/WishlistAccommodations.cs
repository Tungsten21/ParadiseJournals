using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class WishlistAccommodations
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid WishlistId { get; set; }
        [Required]
        public Wishlist Wishlist { get; set; }
        public Guid? WishlistAccomidationImagesId { get; set; }
        public WishlistAccommodationImages? WishlistAccommodationImages { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Website { get; set; }
        public int Rating { get; set; }
        public string Location { get; set; }
        public int CurrencyCode { get; set; } //create enum
        public int PricePerNight { get; set; }
        public string Notes { get; set; }
    }
}
