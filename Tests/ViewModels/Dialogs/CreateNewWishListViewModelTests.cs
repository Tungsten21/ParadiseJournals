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
        private HomeViewModel _homeViewModel;
        private MainWindowViewModel _mainWindowViewModel;

        [TestInitialize]
        public void Setup()
        {
            _serviceProvider = new();
            _dialogService = new();
            _messenger = new WeakReferenceMessenger();
            _navigationService = new NavigationService(_serviceProvider.Object, _messenger);
            _menuBarViewModel = new(_navigationService, _dialogService.Object);
            _createNewWishListViewModel = new(_navigationService, _messenger);
            _homeViewModel = new(_dialogService.Object, _messenger, _navigationService);
            _mainWindowViewModel = new(_serviceProvider.Object, _messenger, _menuBarViewModel);

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

            // Act
            _createNewWishListViewModel.AttemptToCreateWishListCommand.Execute(null);

            // Assert
            Assert.IsInstanceOfType(_mainWindowViewModel.CurrentViewModel, typeof(ViewWishListViewModel));
        }

        [TestMethod()]
        public void AttemptToCreateWishListCommandShouldAddWishListToHomeViewModelOnSuccessfulValidation()
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

            //Act
            _createNewWishListViewModel.AttemptToCreateWishListCommand.Execute(null);

            //Assert
            Assert.IsTrue(_homeViewModel.UserWishLists.Count == 1);
            Assert.IsTrue(_homeViewModel.AtLeastOneWishList);
            Assert.IsFalse(_homeViewModel.NoWishListsButJournalFound);
            Assert.IsTrue(_homeViewModel.NoJournalsButWishListFound);

            var expectedWishList = _homeViewModel.UserWishLists.FirstOrDefault();

            Assert.IsTrue(expectedWishList != null);
            Assert.IsTrue(expectedWishList.Title == "testTitle");
            Assert.IsTrue(expectedWishList.Country == "testCountry");
            Assert.IsTrue(expectedWishList.StartDate == "21/03/2023"); //Parsing DateOnly from model -> produces full year
            Assert.IsTrue(expectedWishList.EndDate == "28/03/2023");
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
