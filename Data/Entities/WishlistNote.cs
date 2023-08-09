using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class WishlistNote
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid WishlistId { get; set; }
        [Required]
        public Wishlist Wishlist { get; set; }
        [Required]
        public Guid WishlistNoteImagesId { get; set; }
        [Required]
        public WishlistNoteImages WishlistNoteImages { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Note { get; set; }
    }
}
