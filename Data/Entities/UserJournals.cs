using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UserJournals
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Journal JournalId { get; set; }
        [Required]
        public Journal Wishlist { get; set; }
    }
}
