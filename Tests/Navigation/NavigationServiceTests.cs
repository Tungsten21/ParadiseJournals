using Common.Exceptions;
using CommunityToolkit.Mvvm.Messaging;
using Moq;
using Tests.Navigation;
using ViewModels;
using ViewModels.Controls;
using ViewModels.Interfaces;
using ViewModels.Navigation;

namespace Tests.ViewModels
{
    [TestClass()]
    public class NavigationServiceTests
    {
        private Mock<IServiceProvider> _serviceProvider;
        private Mock<IDialogService> _dialogService;      
        private IMessenger _messenger;
        private INavigationService _navigationService;
        private MenuBarViewModel _menuBarViewModel;
        private MainWindowViewModel _mainWindowViewModel;



        [TestInitialize]
        public void Setup()
        {
            _serviceProvider = new();
            _dialogService = new();
            _messenger = new WeakReferenceMessenger();
            _navigationService = new NavigationService(_serviceProvider.Object, _messenger);
            _menuBarViewModel = new(_navigationService, _dialogService.Object);
            _mainWindowViewModel = new(_serviceProvider.Object, _messenger, _menuBarViewModel);
        }

        [TestMethod]
        public void CallingNavigationServiceWithRegisteredViewModelShouldChangeMainWindowCurrentViewModel()
        {
            //Arrange
            _serviceProvider.Setup(x => x.GetService(typeof(HomeViewModel)))
                .Returns(new HomeViewModel(_dialogService.Object, _messenger));

            //Act
            _navigationService.NavigateToViewModel<HomeViewModel>();

            //Assert
            Assert.IsInstanceOfType(_mainWindowViewModel.CurrentViewModel, typeof(HomeViewModel));
        }

        [TestMethod]
        public void CallingNavigationServiceWithNonRegisteredViewModelThrowException()
        {
            //Act
            Exception? exception = null;
            try
            {
                _navigationService.NavigateToViewModel<UnRegisteredViewModel>();
            }
            catch (Exception e)
            {
                exception = e;
            }

            //Assert
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentInvalidException));
            Assert.IsTrue(exception.Message == "Passed in viewmodel " + typeof(UnRegisteredViewModel).FullName + " is not registered with DI.");
        }
    }
}
