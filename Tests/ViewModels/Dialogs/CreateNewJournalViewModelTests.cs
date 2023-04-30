using Moq;
using ViewModels.Dialogs;
using ViewModels.Navigation;
using ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using ViewModels.Interfaces;
using ViewModels.Controls;

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
            _mainWindowViewModel = new(_serviceProvider.Object, _messenger, _menuBarViewModel);
        }

        [TestMethod()]
        public void AttemptToCreateJournalCommandShouldNavigateToJournalHomeOnSuccessfulValidation()
        {
            //Add mock validation data once added
            // Arrange
            _serviceProvider.Setup(x => x.GetService(typeof(JournalHomeViewModel))).Returns(new JournalHomeViewModel());

            // Act
            _createNewJournalViewModel.AttemptToCreateJournalCommand.Execute(null);

            // Assert
            Assert.IsInstanceOfType(_mainWindowViewModel.CurrentViewModel, typeof(JournalHomeViewModel));
        }
    }
}
