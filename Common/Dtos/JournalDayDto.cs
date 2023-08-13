using System.ComponentModel.DataAnnotations;

namespace Common.Dtos
{
    public class JournalDayDto
    {
        public Guid Id { get; set; } 
        public string ShortDateFormat { get; set; }
        public string? Title { get; set; }
    }
}