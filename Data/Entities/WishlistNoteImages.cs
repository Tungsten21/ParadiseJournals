using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class WishlistNoteImages
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid WishlistId { get; set; }
        public byte[] AdditionalImage { get; set; }
        public byte[] AdditionalImage2 { get; set; }
        public byte[] AdditionalImage3 { get; set; }
        public byte[] AdditionalImage4 { get; set; }
        public byte[] AdditionalImage5 { get; set; }
    }
}
