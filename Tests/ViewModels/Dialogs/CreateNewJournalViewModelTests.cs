using Moq;
using ViewModels.Dialogs;
using ViewModels.Navigation;
using ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using ViewModels.Interfaces;
using ViewModels.Controls;
using ViewModels.Items;

namespace Tests.ViewModels.Dialogs
{
    [TestClass()]
    public class CreateNewJournalViewModelTests
    {
        private Mock<IServiceProvider> _serviceProvider;
        private Mock<IDialogService> _dialogService;
        private IMessenger _messenger;
        private INavigationService _navigationService;
        private MenuBarViewModel _menuBarViewModel;
        private CreateNewJournalViewModel _createNewJournalViewModel;
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
            _createNewJournalViewModel = new(_navigationService, _messenger);
            _homeViewModel = new(_dialogService.Object, _messenger);
            _mainWindowViewModel = new(_serviceProvider.Object, _messenger, _menuBarViewModel);

            _serviceProvider.Setup(x => x.GetService(typeof(ViewJournalViewModel))).Returns(new ViewJournalViewModel());
        }

        [TestMethod()]
        public void AttemptToCreateJournalCommandShouldNavigateToViewJournalnSuccessfulValidation()
        {
            //Add mock validation data once added
  
            // Act
            _createNewJournalViewModel.AttemptToCreateJournalCommand.Execute(null);

            // Assert
            Assert.IsInstanceOfType(_mainWindowViewModel.CurrentViewModel, typeof(ViewJournalViewModel));
        }

        [TestMethod()]
        public void AttemptToCreateJournalCommandShouldAddJournalToHomeViewModelOnSuccessfulValidation()
        {
            //Arrange
            JournalViewModel model = new()
            {
                Title = "testTitle",
                Country = "testCountry",
                StartDate = "21/03/23",
                EndDate = "28/03/23"
            };

            _createNewJournalViewModel.JournalViewModel = model;

            //Act
            _createNewJournalViewModel.AttemptToCreateJournalCommand.Execute(null);

            //Assert
            Assert.IsTrue(_homeViewModel.UserJournals.Count == 1);
            Assert.IsTrue(_homeViewModel.AtLeastOneJournal);
            Assert.IsFalse(_homeViewModel.NoJournalsButWishListFound);
            Assert.IsTrue(_homeViewModel.NoWishListsButJournalFound);

            var expectedJournal = _homeViewModel.UserJournals.FirstOrDefault();

            Assert.IsTrue(expectedJournal != null);
            Assert.IsTrue(expectedJournal.Title == "testTitle");
            Assert.IsTrue(expectedJournal.Country == "testCountry");
            Assert.IsTrue(expectedJournal.StartDate == "21/03/2023"); //Parsing DateOnly from model -> produces full year
            Assert.IsTrue(expectedJournal.EndDate == "28/03/2023");
        }
    }
}
