using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class WishlistLocations
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid WishlistId { get; set; }
        [Required]
        public Wishlist Wishlist { get; set; }
        public Guid? WishlistLocationImagesId { get; set; }
        public WishlistLocationImages? WishlistLocationImages { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Website { get; set; }
        public int CategoryCode { get; set; }//create enum
        public string Location { get; set; }
        public int CurrencyCode { get; set; } //create enum
        public int PricePerPerson { get; set; }
        public string Notes { get; set; }
    }
}
