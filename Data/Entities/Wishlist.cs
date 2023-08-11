using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Wishlist
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? WishlistImageId { get; set; }
        public WishlistImage? WishlistImage { get; set; }
        [Required]
        public Guid UserWishlistId { get; set; }
        [Required]
        public UserWishlist UserWishlist { get; set; }
        public Guid? WishlistAccommodationsId { get; set; }
        public ICollection<WishlistAccommodations>? WishlistAccommodations { get; set; }
        public Guid? WishlistLocationsId { get; set; }
        public ICollection<WishlistLocations>? WishlistLocations { get; set; }
        public Guid? WishlistNotesId { get; set; }
        public ICollection<WishlistNotes>? WishlistNotes { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int TotalDays { get; set; }

    }
}
