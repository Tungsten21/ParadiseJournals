using Moq;
using ViewModels.Dialogs;
using ViewModels.Navigation;
using ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using ViewModels.Interfaces;

namespace Tests.ViewModels.Dialogs
{
    [TestClass()]
    public class CreateNewJournalViewModelTests
    {
        private INavigationService _navigationService;
        private CreateNewJournalViewModel _createNewJournalViewModel;
        private IMessenger _messenger;
        private MainWindowViewModel _mainWindowViewModel;
        private Mock<IServiceProvider> _serviceProvider;
        


        [TestInitialize]
        public void Setup()
        {
            _messenger = new WeakReferenceMessenger();
            _serviceProvider = new();
            _navigationService = new NavigationService(_serviceProvider.Object, _messenger);
            _createNewJournalViewModel = new(_navigationService);
            _mainWindowViewModel = new(_serviceProvider.Object, _messenger);
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
