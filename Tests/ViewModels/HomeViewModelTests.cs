using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Dialogs;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Messages;

namespace Tests.ViewModels
{
    [TestClass()]
    public class HomeViewModelTests
    {
        private Mock<IDialogService> _dialogService;
        private Mock<INavigationService> _navigationService;
        private HomeViewModel _homeViewModel;
        private IMessenger _messenger;
        private Mock<IUserContext> _userContext;
        private Mock<ItemCache> _itemCache;


        [TestInitialize]
        public void Setup()
        {
            _dialogService = new();
            _navigationService = new();
            _messenger = new WeakReferenceMessenger();
            _userContext = new();
            _itemCache = new();

            _homeViewModel = new(_userContext.Object, _itemCache.Object, _dialogService.Object, _messenger, _navigationService.Object);

        }

        [TestMethod()]
        public void OpenCreateNewJournalDialogCommandShouldCallDialogServiceWithCreateNewJournalViewModel()
        {
            // Arrange
            var createNewJournalViewModel = new Mock<CreateNewJournalViewModel>();
            _dialogService.SetupProperty(x => x.CurrentViewModel);
            _dialogService.Setup(x => x.ShowDialog<CreateNewJournalViewModel>(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => _dialogService.Object.CurrentViewModel = createNewJournalViewModel.Object);

            // Act
            _homeViewModel.OpenCreateNewJournalDialogCommand.Execute(null);

            // Assert
            _dialogService.Verify(m => m.ShowDialog<CreateNewJournalViewModel>("Create New Journal", "Large"));
            Assert.IsInstanceOfType(_dialogService.Object.CurrentViewModel, typeof(CreateNewJournalViewModel));

        }

        [TestMethod()]
        public void OpenCreateNewWishListDialogCommandShouldCallDialogServiceWithCreateNewWishListViewModel()
        {
            // Arrange
            var createNewWishListViewModel = new Mock<CreateNewWishListViewModel>();
            _dialogService.SetupProperty(x => x.CurrentViewModel);
            _dialogService.Setup(x => x.ShowDialog<CreateNewWishListViewModel>(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => _dialogService.Object.CurrentViewModel = createNewWishListViewModel.Object);

            // Act
            _homeViewModel.OpenCreateNewWishListDialogCommand.Execute(null);

            // Assert
            _dialogService.Verify(m => m.ShowDialog<CreateNewWishListViewModel>("Create New Wishlist", "Large"));
            Assert.IsInstanceOfType(_dialogService.Object.CurrentViewModel, typeof(CreateNewWishListViewModel));

        }
    }
}
