using Moq;
using ViewModels;
using ViewModels.Dialogs;
using ViewModels.Interfaces;
using ViewModels.Navigation;

namespace Tests.ViewModels
{
    [TestClass()]
    public class EntryViewModelTests
    {
        private Mock<IDialogService> _dialogService;
        private Mock<INavigationService> _navigationService;
        private EntryViewModel entryViewModel;
        

        [TestInitialize]
        public void Setup()
        {
           _dialogService = new();
           entryViewModel = new(_dialogService.Object);
           _navigationService = new();
        }

        [TestMethod()]
        public void OpenLoginDialogCommandShouldCreateDialogWithLoginViewModelAsDataContext()
        {
            // Arrange
            var loginViewModel = new LoginViewModel(_navigationService.Object);
            _dialogService.SetupProperty<IViewModel>(x => x.ViewModel);
            _dialogService.Setup(x => x.ShowDialog<LoginViewModel>(It.IsAny<string>(), It.IsAny<string>())).Callback(() => _dialogService.Object.ViewModel = loginViewModel);

            // Act
            entryViewModel.OpenLoginDialogCommand.Execute(null);

            // Assert
            _dialogService.Verify(m => m.ShowDialog<LoginViewModel>("Login", "Large"));
            Assert.IsInstanceOfType(_dialogService.Object.ViewModel, typeof(LoginViewModel));

        }
        
        [TestMethod()]
        public void OpenCreateNewUserDialogCommandShouldCreateDialogWithCreateNewUserViewModelAsDataContext()
        {
            //Act
            entryViewModel.OpenCreateNewUserDialogCommand.Execute(null);

            //Assert
            _dialogService.Verify(m => m.ShowDialog<CreateNewUserViewModel>("Create New User", "Large"));
        }
    }
}