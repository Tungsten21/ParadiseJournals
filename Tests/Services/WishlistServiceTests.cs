using AutoMapper;
using Common.Dtos;
using Data.Interfaces;
using Moq;
using Services.Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Mappers;

namespace Tests.Services
{
    [TestClass()]
    public class WishlistServiceTests
    {
        private IWishlistService _wishlistService;
        private IMapper _mapper;
        private Mock<IWishlistRepository> _wishlistRepository;

        [TestInitialize]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceProfiles>();
            });

            _mapper = new Mapper(mapperConfig);
            _wishlistRepository = new();
            _wishlistService = new WishlistService(_mapper, _wishlistRepository.Object);
        }

        //Create Test

        [TestMethod]
        public void GetWishlistWithValidIdShouldReturnHydratedWishlistDto()
        {
            //Arrange
            var wishlistId = Guid.NewGuid();
            var ownerId = Guid.NewGuid();
            var title = "Test Wishlist";
            var country = "Sweden";
            var city = "Stockholm";
            var startDate = DateTime.Parse("21/06/23");
            var endDate = DateTime.Parse("24/06/23");


            var expectedWishlist = new WishlistDto()
            {
                Id = wishlistId,
                OwnerId = ownerId,
                Title = title,
                Country = country,
                City = city,
                StartDate = startDate,
                EndDate = endDate,
            };

            _wishlistRepository.Setup(x => x.GetWishlist(wishlistId)).Returns(expectedWishlist);

            //Act
            var result = _wishlistService.GetWishlist(wishlistId);

            //Assert
            _wishlistRepository.Verify(x => x.GetWishlist(wishlistId));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id.Equals(wishlistId));
            Assert.IsTrue(result.OwnerId.Equals(ownerId));
            Assert.IsTrue(result.Title.Equals(title));
            Assert.IsTrue(result.Country.Equals(country));
            Assert.IsTrue(result.City.Equals(city));
            Assert.IsTrue(result.StartDate.Equals(startDate));
            Assert.IsTrue(result.EndDate.Equals(endDate));
        }

        [TestMethod]
        public void GetWishlistWithDeletedIdShouldReturnEmptyDto()
        {
            //Arrange
            var wishlistId = Guid.NewGuid();
            _wishlistRepository.Setup(x => x.GetWishlist(wishlistId)).Returns(new WishlistDto());

            //Act
            var result = _wishlistService.GetWishlist(wishlistId);

            //Assert
            _wishlistRepository.Verify(x => x.GetWishlist(wishlistId));
            Assert.IsTrue(result.Id == Guid.Empty);
        }

        [TestMethod]
        public void GetWishlistsWithExistingWishlistsShouldReturnHydratedResultDto()
        {
            //Arrange
            var ownerId = Guid.NewGuid();

            var wishlistId1 = Guid.NewGuid();
            var title1 = "Test Wishlist";
            var country1 = "Sweden";
            var city1 = "Stockholm";
            var startDate1 = DateTime.Parse("21/06/23");
            var endDate1 = DateTime.Parse("24/06/23");

            var wishlistId2 = Guid.NewGuid();
            var title2 = "Test Wishlist 2";
            var country2 = "Germany";
            var city2 = "Berlin";
            var startDate2 = DateTime.Parse("05/02/22");
            var endDate2 = DateTime.Parse("07/02/22");


            var expectedWishlist1 = new WishlistDto()
            {
                Id = wishlistId1,
                OwnerId = ownerId,
                Title = title1,
                Country = country1,
                City = city1,
                StartDate = startDate1,
                EndDate = endDate1,
            };

            var expectedWishlist2 = new WishlistDto()
            {
                Id = wishlistId2,
                OwnerId = ownerId,
                Title = title2,
                Country = country2,
                City = city2,
                StartDate = startDate2,
                EndDate = endDate2
            };

            _wishlistRepository.Setup(x => x.GetWishlists(ownerId)).Returns(
                new List<WishlistDto>() { expectedWishlist1, expectedWishlist2 }.AsQueryable
                );

            //Act
            var result = _wishlistService.GetWishlists(ownerId);

            //Assert
            _wishlistRepository.Verify(x => x.GetWishlists(ownerId));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Items.Count == 2);

            var wishlists = result.Items.Cast<WishlistDto>().ToList();

            Assert.IsTrue(wishlists[0].Id == wishlistId1);
            Assert.IsTrue(wishlists[0].OwnerId == ownerId);
            Assert.IsTrue(wishlists[0].Title == title1);
            Assert.IsTrue(wishlists[0].Country == country1);
            Assert.IsTrue(wishlists[0].City == city1);
            Assert.IsTrue(wishlists[0].StartDate == startDate1);
            Assert.IsTrue(wishlists[0].EndDate == endDate1);

            Assert.IsTrue(wishlists[1].Id == wishlistId2);
            Assert.IsTrue(wishlists[1].OwnerId == ownerId);
            Assert.IsTrue(wishlists[1].Title == title2);
            Assert.IsTrue(wishlists[1].Country == country2);
            Assert.IsTrue(wishlists[1].City == city2);
            Assert.IsTrue(wishlists[1].StartDate == startDate2);
            Assert.IsTrue(wishlists[1].EndDate == endDate2);

        }

        [TestMethod]
        public void GetWishlistsWithNoExistingWishlistsShouldReturnEmptyResultDto()
        {
            //Arrange
            var ownerId = Guid.NewGuid();

            //Act
            var result = _wishlistService.GetWishlists(ownerId);

            //Assert
            _wishlistRepository.Verify(x => x.GetWishlists(ownerId));
            Assert.IsTrue(result.Id == Guid.Empty);
            Assert.IsTrue(result.Success == false);
        }
    }
}
