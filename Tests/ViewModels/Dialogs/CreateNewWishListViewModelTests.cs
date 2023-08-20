using CommunityToolkit.Mvvm.Messaging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Controls;
using ViewModels.Dialogs;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Navigation;
using ViewModels;
using AutoMapper;
using Services.Interfaces;
using Services.Mappers;
using Common.Dtos;
using Models;
using Services;
using ViewModels.Mappers;

namespace Tests.ViewModels.Dialogs
{
    [TestClass()]
    public class CreateNewWishListViewModeTests
    {
        private Mock<IServiceProvider> _serviceProvider;
        private Mock<IDialogService> _dialogService;
        private IMessenger _messenger;
        private INavigationService _navigationService;
        private MenuBarViewModel _menuBarViewModel;
        private CreateNewWishListViewModel _createNewWishListViewModel;
        private Mock<ItemCache> _itemCache;
        private MainWindowViewModel _mainWindowViewModel;
        private Mock<IUserContext> _userContext;
        private Mock<IWishlistService> _wishlistService;
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceProfiles>();
                cfg.AddProfile<ViewModelProfiles>();
            });

            _mapper = new Mapper(mapperConfig);

            _serviceProvider = new();
            _dialogService = new();
            _messenger = new WeakReferenceMessenger();
            _wishlistService = new();
            _navigationService = new NavigationService(_serviceProvider.Object, _messenger);
            _menuBarViewModel = new(_navigationService, _dialogService.Object);
            _itemCache = new();
            _userContext = new();
            _createNewWishListViewModel = new(_mapper, _userContext.Object, _navigationService, _messenger, _wishlistService.Object);
            _mainWindowViewModel = new(_serviceProvider.Object, _userContext.Object, _messenger, _menuBarViewModel);

            _serviceProvider.Setup(x => x.GetService(typeof(ViewWishListViewModel))).Returns(new ViewWishListViewModel(_messenger));
        }

        [TestMethod()]
        public void AttemptToCreateWishListCommandShouldNavigateToViewWishListOnSuccessfulValidation()
        {
            //Arrange
            WishListViewModel model = new()
            {
                Title = "testTitle",
                Country = "testCountry",
                StartDate = "21/03/23",
                EndDate = "28/03/23"
            };

            _createNewWishListViewModel.WishListViewModel = model;

            _wishlistService.Setup(x => x.CreateWishlist(It.IsAny<WishlistDto>())).Returns(
                new ResultDto() { Success = true }
            );

            _wishlistService.Setup(x => x.GetWishlist(It.IsAny<Guid>())).Returns(
                new WishlistDto() { Id = Guid.NewGuid() }
                );

            _userContext.SetupProperty(x => x.CurrentUser);
            _userContext.Object.CurrentUser = new UserModel() { Id = Guid.NewGuid() };


            // Act
            _createNewWishListViewModel.AttemptToCreateWishListCommand.Execute(null);

            // Assert
            Assert.IsInstanceOfType(_mainWindowViewModel.CurrentViewModel, typeof(ViewWishListViewModel));
        }

        [DataRow("Ttle", "Sweden", "12/05/23", "19/05/23", "Stockholm", "Stockholm Visit")] //Title 
        [DataRow("Title", "", "12/05/23", "19/05/23", "Stockholm", "Stockholm Visit")] //Country 
        [DataRow("Title", "Sweden", "21/05/23", "19/05/23", "Stockholm", "Stockholm Visit")] //StartDate 
        [DataRow("Title", "Sweden", "12/05/23", "10/05/23", "Stockholm", "Stockholm Visit")] //EndDate 
        [DataRow("Title", "Sweden", "12/05/23", "19/05/23", "Stockholm", "Sto")] //Desc 
        [DataTestMethod()]
        public void CreateWishListlValidationShouldFailWithIllegalEntries(string title, string country, string startDate, string endDate,
            string city, string desc)
        {
            //Arrange
            var model = new WishListViewModel()
            {
                Title = title,
                Country = country,
                StartDate = startDate,
                EndDate = endDate,
                City = city,
                Description = desc
            };

            _createNewWishListViewModel.WishListViewModel = model;

            //Act
            _createNewWishListViewModel.AttemptToCreateWishListCommand.Execute(null);

            //Assert
            Assert.IsTrue(_createNewWishListViewModel.WishListViewModel.HasErrors);
            Assert.IsNotInstanceOfType(_mainWindowViewModel.CurrentViewModel, typeof(ViewWishListViewModel));
        }
    }
}
