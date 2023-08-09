using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? UserJournalsId { get; set; }
        public ICollection<UserJournal>? UserJournals { get; set; }
        public Guid? UserWishlistId { get; set; }
        public ICollection<UserWishlist>? UserWishlists { get; set; }
        public Guid? UserImageId { get; set; }
        public UserImage? UserImage { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public bool Deleted { get; set; }
    }
}
