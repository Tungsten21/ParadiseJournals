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


        [TestInitialize]
        public void Setup()
        {
            _dialogService = new();
            _navigationService = new();
            _messenger = new WeakReferenceMessenger();
            _homeViewModel = new(_dialogService.Object, _messenger, _navigationService.Object);
        }

        [TestMethod()]
        public void OpenCreateNewJournalDialogCommandShouldCallDialogServiceWithCreateNewJournalViewModel()
        {
            // Arrange
            var createNewJournalViewModel = new CreateNewJournalViewModel(_navigationService.Object, _messenger);
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
            var createNewWishListViewModel = new CreateNewWishListViewModel(_navigationService.Object, _messenger);
            _dialogService.SetupProperty(x => x.CurrentViewModel);
            _dialogService.Setup(x => x.ShowDialog<CreateNewWishListViewModel>(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => _dialogService.Object.CurrentViewModel = createNewWishListViewModel);

            // Act
            _homeViewModel.OpenCreateNewWishListDialogCommand.Execute(null);

            // Assert
            _dialogService.Verify(m => m.ShowDialog<CreateNewWishListViewModel>("Create New Wishlist", "Large"));
            Assert.IsInstanceOfType(_dialogService.Object.CurrentViewModel, typeof(CreateNewWishListViewModel));

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
            Assert.IsTrue(_homeViewModel.UserJournals.Count == 1);
            Assert.IsTrue(_homeViewModel.AtLeastOneJournal);
            Assert.IsFalse(_homeViewModel.NoJournalsButWishListFound);
            Assert.IsTrue(_homeViewModel.NoWishListsButJournalFound);
            Assert.IsFalse(_homeViewModel.NoItemsFound);
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
            Assert.IsTrue(_homeViewModel.UserWishLists.Count == 1);
            Assert.IsTrue(_homeViewModel.AtLeastOneWishList);
            Assert.IsTrue(_homeViewModel.NoJournalsButWishListFound);
            Assert.IsFalse(_homeViewModel.NoWishListsButJournalFound);
            Assert.IsFalse(_homeViewModel.NoItemsFound);
        }
    }
}
