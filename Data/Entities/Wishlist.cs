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
        public Guid PictureId { get; set; }
        public Picture Picture { get; set; }
        [Required]
        public Guid Owner { get; set; }
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
