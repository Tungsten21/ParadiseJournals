using AutoMapper;
using Common.Dtos;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WishlistRepository : IWishlistRepository
    {
        private IMapper _mapper;
        private ApplicationDbContext _context;

        public WishlistRepository(IMapper mapper, ApplicationDbContext dbContext) 
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public ResultDto CreateWishlist(WishlistDto wishlist)
        {
            var wishlistToCreate = _mapper.Map<Wishlist>(wishlist);

            _context.Wishlists.Add(wishlistToCreate);

            _context.SaveChanges();


            //UPDATE
            return new ResultDto() { Id = wishlistToCreate.Id, Success = true };
        }

        public WishlistDto GetWishlist(Guid wishlistId)
        {
            var result = new WishlistDto();

            var wishlist = _context.Wishlists.FirstOrDefault(x => x.Id == wishlistId);

            if (wishlist != null)
            {
                result = _mapper.Map<WishlistDto>(wishlist);
            }

            return result;
        }

        public IQueryable<WishlistDto>? GetWishlists(Guid userId)
        {
            var result = default(IQueryable<WishlistDto>);
            var wishlists = default(IQueryable<Wishlist>);

            wishlists = _context.Wishlists.Where(j => j.OwnerId == userId);

            if (wishlists != null)
            {
                result = _mapper.ProjectTo<WishlistDto>(wishlists);
            }

            return result;
        }
    }
}
