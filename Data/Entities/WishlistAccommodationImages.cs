using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class WishlistAccommodationImages
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid WishlistAccommodationsId { get; set; }
        [Required]
        public WishlistAccommodations WishlistAccommodations { get; set; }
        public byte[]? Thumbnail { get; set; }
        public byte[]? AdditionalImage { get; set; }
        public byte[]? AdditionalImage2 { get; set; }
        public byte[]? AdditionalImage3 { get; set; }
        public byte[]? AdditionalImage4 { get; set; }
        public byte[]? AdditionalImage5 { get; set; }

    }
}
