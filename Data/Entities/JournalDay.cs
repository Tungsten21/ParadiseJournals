using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class JournalDay
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid JournalId { get; set; }
        [Required]
        public Journal Journal { get; set; }
        [Required]
        public string ShortDateFormat { get; set; }
        public string? Title { get; set; }
    }
}
