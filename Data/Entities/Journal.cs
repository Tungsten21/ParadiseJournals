using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Journal
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? JournalImagesId { get; set; }
        public JournalImages? JournalImages { get; set; }
        [Required]
        public Guid UserJournalId { get; set; }
        public UserJournal UserJournal { get; set; }
        public IEnumerable<JournalDay> JournalDays { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? City { get; set; }
        public int TotalDays { get; set; }
    }
}
