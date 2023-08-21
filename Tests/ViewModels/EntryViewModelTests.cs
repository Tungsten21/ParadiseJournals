using AutoMapper;
using Moq;
using Services.Interfaces;
using ViewModels;
using ViewModels.Controls;
using ViewModels.Dialogs;
using ViewModels.Interfaces;

namespace Tests.ViewModels
{
    [TestClass()]
    public class EntryViewModelTests
    {
        private Mock<IDialogService> _dialogService;
        private Mock<INavigationService> _navigationService;
        private MenuBarViewModel _menuBarViewModel;
        private EntryViewModel _entryViewModel;
        

        [TestInitialize]
        public void Setup()
        {
           _dialogService = new();
           _navigationService = new();
           _menuBarViewModel = new(_navigationService.Object, _dialogService.Object);
           _entryViewModel = new(_dialogService.Object);
        }

        [TestMethod()]
        public void OpenLoginDialogCommandShouldCallDialogServiceWithLoginViewModel()
        {
            // Arrange
            var loginViewModel = new Mock<LoginViewModel>().Object;
            _dialogService.SetupProperty(x => x.CurrentViewModel);
            _dialogService.Setup(x => x.ShowDialog<LoginViewModel>(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => _dialogService.Object.CurrentViewModel = loginViewModel);

            // Act
            _entryViewModel.OpenLoginDialogCommand.Execute(null);

            // Assert
            _dialogService.Verify(m => m.ShowDialog<LoginViewModel>("Login", "Large"));
            Assert.IsInstanceOfType(_dialogService.Object.CurrentViewModel, typeof(LoginViewModel));

        }

        [TestMethod()]
        public void OpenCreateNewUserCommandShouldCallDialogServiceWithCreateNewUserViewModel()
        {
            // Arrange
            var createNewUserViewModel = new Mock<CreateNewUserViewModel>().Object;
            _dialogService.SetupProperty(x => x.CurrentViewModel);
            _dialogService.Setup(x => x.ShowDialog<CreateNewUserViewModel>("Create New User", "Large"))
                .Callback(() => _dialogService.Object.CurrentViewModel = createNewUserViewModel);

            // Act
            _entryViewModel.OpenCreateNewUserDialogCommand.Execute(null);

            // Assert
            _dialogService.Verify(m => m.ShowDialog<CreateNewUserViewModel>("Create New User", "Large"));
            Assert.IsInstanceOfType(_dialogService.Object.CurrentViewModel, typeof(CreateNewUserViewModel));
        }
    }
}