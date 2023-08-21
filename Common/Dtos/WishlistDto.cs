using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class WishlistDto
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? City { get; set; }
    }
}
