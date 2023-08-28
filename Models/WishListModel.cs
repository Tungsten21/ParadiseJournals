using Models.Interfaces;

namespace Models
{
    public class WishListModel : IModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? City { get; set; }
        public IEnumerable<WishListAccommodationModel>? Accomodations { get; set; }
        public IEnumerable<WishListLocationModel>? Locations { get; set; }
        public IEnumerable<WishListNoteModel>? Notes { get; set; }

    }
}
