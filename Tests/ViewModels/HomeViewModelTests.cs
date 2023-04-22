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

namespace Tests.ViewModels
{
    [TestClass()]
    public class HomeViewModelTests
    {
        private Mock<IDialogService> _dialogService;
        private HomeViewModel _homeViewModel;
        private Mock<INavigationService> _navigationService;

        [TestInitialize]
        public void Setup()
        {
            _dialogService = new();
            _homeViewModel = new(_dialogService.Object);
            _navigationService = new();
        }

        [TestMethod()]
        public void OpenCreateNewJournalDialogCommandShouldCallDialogServiceWithCreateNewJournalViewModel()
        {
            // Arrange
            var createNewJournalViewModel = new CreateNewJournalViewModel(_navigationService.Object);
            _dialogService.SetupProperty(x => x.CurrentViewModel);
            _dialogService.Setup(x => x.ShowDialog<CreateNewJournalViewModel>(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => _dialogService.Object.CurrentViewModel = createNewJournalViewModel);

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
            var createNewWishListViewModel = new CreateNewWishListViewModel();
            _dialogService.SetupProperty(x => x.CurrentViewModel);
            _dialogService.Setup(x => x.ShowDialog<CreateNewWishListViewModel>(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => _dialogService.Object.CurrentViewModel = createNewWishListViewModel);

            // Act
            _homeViewModel.OpenCreateNewWishListDialogCommand.Execute(null);

            // Assert
            _dialogService.Verify(m => m.ShowDialog<CreateNewWishListViewModel>("Create New Wishlist", "Large"));
            Assert.IsInstanceOfType(_dialogService.Object.CurrentViewModel, typeof(CreateNewWishListViewModel));

        }
    }
}
