using Common.Exceptions;
using CommunityToolkit.Mvvm.Messaging;
using Moq;
using Tests.Navigation;
using ViewModels;
using ViewModels.Interfaces;
using ViewModels.Navigation;

namespace Tests.ViewModels
{
    [TestClass()]
    public class NavigationServiceTests
    {
        private Mock<IServiceProvider> _serviceProvider;
        private IMessenger _messenger;
        private MainWindowViewModel _mainWindowViewModel;
        private INavigationService _navigationService;
        

        [TestInitialize]
        public void Setup()
        {
            _serviceProvider = new();
            _messenger = new WeakReferenceMessenger();
            _mainWindowViewModel = new(_serviceProvider.Object, _messenger);
            _navigationService = new NavigationService(_serviceProvider.Object, _messenger);
        }

        [TestMethod]
        public void CallingNavigationServiceWithRegisteredViewModelShouldChangeMainWindowCurrentViewModel()
        {
            //Arrange
            _serviceProvider.Setup(x => x.GetService(typeof(HomeViewModel)))
                .Returns(new HomeViewModel(new Mock<IDialogService>().Object));

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
            Assert.IsTrue(exception.Message == "Passed in viewmodel is not registered with DI.");
        }
    }
}
