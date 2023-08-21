using Common.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IWishlistRepository
    {
        ResultDto CreateWishlist(WishlistDto wishlist);

        WishlistDto GetWishlist(Guid wishlistId);

        IQueryable<WishlistDto> GetWishlists(Guid userId);
    }
}
