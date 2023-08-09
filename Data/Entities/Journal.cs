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
        [Required]
        public UserJournal UserJournal { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int TotalDays { get; set; }
        public ICollection<JournalDay> DayIds { get; set; }
    }
}
