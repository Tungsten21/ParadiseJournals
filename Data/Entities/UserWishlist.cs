using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UserWishlist
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public User Owner { get; set; }
        [Required]
        public Guid WishlistId { get; set; }
        [Required]
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
