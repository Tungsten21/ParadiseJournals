using AutoMapper;
using Common.Dtos;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WishlistService : IWishlistService
    {
        private IMapper _mapper;
        private IWishlistRepository _wishlistRepo;

        public WishlistService(IMapper mapper, IWishlistRepository wishlistRepository)
        {
            _mapper = mapper;
            _wishlistRepo = wishlistRepository;
        }

        public ResultDto CreateWishlist(WishlistDto wishlist)
        {
            var result = _wishlistRepo.CreateWishlist(wishlist);

            if (!result.Success)
            {
                result.Message = "Error creating journal: Journal not created.";
            }

            return result;
        }

        public WishlistDto GetWishlist(Guid wishlistId)
        {
            return _wishlistRepo.GetWishlist(wishlistId);
        }

        public ResultDto GetWishlists(Guid userId)
        {
            var result = new ResultDto();

            var wishlists = _wishlistRepo.GetWishlists(userId);

            if (wishlists.Any())
            {
                result.Success = true;
                result.Items = wishlists.ToList<object>();
            }
            else
            {
                result.Message = "Error creating journal: Journal not created.";
            }

            return result;
        }
    }
}
