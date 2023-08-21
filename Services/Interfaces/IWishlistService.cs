using Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IWishlistService
    {
        ResultDto CreateWishlist(WishlistDto wishlist);

        WishlistDto GetWishlist(Guid wishlistId);

        ResultDto GetWishlists(Guid userId);
    }
}
