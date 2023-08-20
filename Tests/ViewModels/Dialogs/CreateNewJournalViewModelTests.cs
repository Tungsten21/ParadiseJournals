using Moq;
using ViewModels.Dialogs;
using ViewModels.Navigation;
using ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using ViewModels.Interfaces;
using ViewModels.Controls;
using ViewModels.Items;
using AutoMapper;
using Services.Mappers;
using Services.Interfaces;
using ViewModels.Mappers;
using Common.Dtos;
using Models;

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
        private Mock<ItemCache> _itemCache;
        private MainWindowViewModel _mainWindowViewModel;
        private Mock<IUserContext> _userContext;
        private Mock<IJournalService> _journalService;
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
            _journalService = new();
            _navigationService = new NavigationService(_serviceProvider.Object, _messenger);
            _menuBarViewModel = new(_navigationService, _dialogService.Object);
            _itemCache = new();
            _userContext = new();
            _createNewJournalViewModel = new(_mapper, _userContext.Object, _navigationService, _messenger, _journalService.Object);
            _mainWindowViewModel = new(_serviceProvider.Object, _userContext.Object, _messenger, _menuBarViewModel);

            _serviceProvider.Setup(x => x.GetService(typeof(ViewJournalViewModel))).Returns(new ViewJournalViewModel(_messenger));
        }

        [TestMethod()]
        public void AttemptToCreateJournalCommandShouldNavigateToViewJournalnSuccessfulValidation()
        {
            //Arrange
            JournalViewModel model = new()
            {
                Title = "testTitle",
                Country = "testCountry",
                StartDate = "21/03/23",
                EndDate = "28/03/23"
            };

            _journalService.Setup(x => x.CreateJournal(It.IsAny<JournalDto>())).Returns(
                new ResultDto() { Success = true }
                );

            _journalService.Setup(x => x.GetJournal(It.IsAny<Guid>())).Returns(
                new JournalDto() { Id = Guid.NewGuid() }
                );

            _userContext.SetupProperty(x => x.CurrentUser);
            _userContext.Object.CurrentUser = new UserModel() { Id = Guid.NewGuid() };

            _createNewJournalViewModel.JournalViewModel = model;

            // Act
            _createNewJournalViewModel.AttemptToCreateJournalCommand.Execute(null);

            // Assert
            Assert.IsInstanceOfType(_mainWindowViewModel.CurrentViewModel, typeof(ViewJournalViewModel));
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
