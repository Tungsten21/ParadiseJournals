using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Index(nameof(OwnerId))]
    public class Wishlist
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? WishlistImageId { get; set; }
        public WishlistImage? WishlistImage { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public User Owner { get; set; }
        public Guid? WishlistAccommodationsId { get; set; }
        public ICollection<WishlistAccommodations>? WishlistAccommodations { get; set; }
        public Guid? WishlistLocationsId { get; set; }
        public ICollection<WishlistLocations>? WishlistLocations { get; set; }
        public Guid? WishlistNotesId { get; set; }
        public ICollection<WishlistNotes>? WishlistNotes { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int TotalDays { get; set; }

    }
}
