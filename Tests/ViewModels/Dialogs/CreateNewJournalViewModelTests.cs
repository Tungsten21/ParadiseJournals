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
            _homeViewModel = new(_dialogService.Object, _messenger, _navigationService);
            _mainWindowViewModel = new(_serviceProvider.Object, _messenger, _menuBarViewModel);

            _serviceProvider.Setup(x => x.GetService(typeof(ViewJournalViewModel))).Returns(new ViewJournalViewModel(_messenger));
        }

        [TestMethod()]
        public void AttemptToCreateJournalCommandShouldNavigateToViewJournalnSuccessfulValidation()
        {
            JournalViewModel model = new()
            {
                Title = "testTitle",
                Country = "testCountry",
                StartDate = "21/03/23",
                EndDate = "28/03/23"
            };

            _createNewJournalViewModel.JournalViewModel = model;

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

        [DataRow("Ttle", "Sweden", "12/05/23", "19/05/23", "Stockholm", "Stockholm Visit")] //Title 
        [DataRow("Title", "", "12/05/23", "19/05/23", "Stockholm", "Stockholm Visit")] //Country 
        [DataRow("Title", "Sweden", "21/05/23", "19/05/23", "Stockholm", "Stockholm Visit")] //StartDate 
        [DataRow("Title", "Sweden", "12/05/23", "10/05/23", "Stockholm", "Stockholm Visit")] //EndDate 
        [DataRow("Title", "Sweden", "12/05/23", "19/05/23", "Stockholm", "Sto")] //Desc 
        [DataTestMethod()]
        public void CreateJournalValidationShouldFailWithIllegalEntries(string title, string country, string startDate, string endDate, 
            string city, string desc)
        {
            //Arrange
            JournalViewModel model = new JournalViewModel()
            {
                Title = title,
                Country = country,
                StartDate = startDate,
                EndDate = endDate,
                City = city,
                Description = desc
            };

            _createNewJournalViewModel.JournalViewModel = model;

            //Act
            _createNewJournalViewModel.AttemptToCreateJournalCommand.Execute(null);

            //Assert
            Assert.IsTrue(_createNewJournalViewModel.JournalViewModel.HasErrors);
            Assert.IsNotInstanceOfType(_mainWindowViewModel.CurrentViewModel, typeof(ViewJournalViewModel));
        }
    }
}
