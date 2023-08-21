using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JournalModel : IModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public IEnumerable<JournalDayModel> Days { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? City { get; set; }
    }
}
