using CommunityToolkit.Mvvm.Messaging;
using ViewModels.Items;
using ViewModels.Messages;
using AutoMapper;
using Moq;
using ViewModels.Interfaces;
using Services.Interfaces;
using Services.Mappers;
using Common.Dtos;
using Models;

namespace Tests.ViewModels
{
    [TestClass()]
    public class ItemCacheTests
    {
        private ItemCache _itemCache;
        private IMapper _mapper;
        private WeakReferenceMessenger _messenger;
        private Mock<IUserContext> _userContext;
        private Mock<IJournalService> _journalService;
        private Mock<IWishlistService> _wishlistService;

        [TestInitialize]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceProfiles>();
            });

            _mapper = new Mapper(mapperConfig);
            _messenger = new WeakReferenceMessenger();
            _userContext = new();
            _journalService = new();
            _wishlistService = new();


            _journalService.Setup(x => x.GetJournals(It.IsAny<Guid>())).Returns(
                new ResultDto() { Success = false }
            );

            _wishlistService.Setup(x => x.GetWishlists(It.IsAny<Guid>())).Returns(
                new ResultDto() { Success = false }
            );

            _userContext.SetupProperty(x => x.CurrentUser);
            _userContext.Object.CurrentUser = new UserModel() { Id = Guid.NewGuid() };

            _itemCache = new(_mapper, _messenger, _userContext.Object, _journalService.Object, _wishlistService.Object);

        }


        [TestMethod()]
        public void AddingOneJournalShouldUpdateTheRelevantProperties()
        {
            //Arrange
            var journalToSend = new JournalViewModel();
            var messageToSend = new ItemCreatedMessage(journalToSend.CloneModel());

            //Act
            _messenger.Send(messageToSend);

            //Assert
            Assert.IsTrue(_itemCache.Journals.Count == 1);
            Assert.IsTrue(_itemCache.AtLeastOneJournal);
            Assert.IsFalse(_itemCache.NoJournalsButWishListFound);
            Assert.IsTrue(_itemCache.NoWishListsButJournalFound);
            Assert.IsFalse(_itemCache.NoItemsFound);
        }

        [TestMethod()]
        public void AddingOneWishListShouldUpdateTheRelevantProperties()
        {
            //Arrange
            var wishListToSend = new WishListViewModel();
            var messageToSend = new ItemCreatedMessage(wishListToSend.CloneModel());

            //Act
            _messenger.Send(messageToSend);

            //Assert
            Assert.IsTrue(_itemCache.Wishlists.Count == 1);
            Assert.IsTrue(_itemCache.AtLeastOneWishList);
            Assert.IsTrue(_itemCache.NoJournalsButWishListFound);
            Assert.IsFalse(_itemCache.NoWishListsButJournalFound);
            Assert.IsFalse(_itemCache.NoItemsFound);
        }
    }
}
