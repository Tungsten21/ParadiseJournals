using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class WishListLocationModel
    {
        public Guid Id { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Name { get; set; }
        public string WebsiteURL { get; set; }
        public LocationCategory LocationCategory { get; set; }
        public string Location { get; set; }
        public Currency Currency { get; set; }
        public double PricePerPerson { get; set; }
        public string Notes { get; set; }
        public List<byte[]> AdditionalPhotos { get; set; }
    }
}
