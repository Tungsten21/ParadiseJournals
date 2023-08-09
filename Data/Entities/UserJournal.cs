using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UserJournal
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public User Owner { get; set; }
        [Required]
        public Guid JournalId { get; set; }
        [Required]
        public ICollection<Journal> Journals { get; set; }
    }
}
