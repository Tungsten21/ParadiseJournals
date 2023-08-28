using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Models
{
    public class WishListAccommodationModel
    {
        public Guid Id { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Name { get; set; }
        public string WebsiteURL { get; set; }
        public int Rating { get; set; }
        public string Location { get; set; }
        public Currency Currency { get; set; }
        public double PricePerNight { get; set; }
        public string Notes { get; set; }
        public List<byte[]> AdditionalPhotos { get; set;}
    }
}
