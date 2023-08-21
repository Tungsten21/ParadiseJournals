using AutoMapper;
using Common.Dtos;
using Moq;
using Services.Interfaces;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Controls;
using ViewModels.Dialogs;
using ViewModels.Interfaces;
using ViewModels.Mappers;
using ViewModels.User;

namespace Tests.ViewModels.Dialogs
{
    [TestClass()]
    public class LoginViewModelTests
    {
        private LoginViewModel _loginViewModel;
        private IMapper _mapper;
        private Mock<IUserService> _userService;
        private Mock<INavigationService> _navigationService;
        private Mock<IDialogService> _dialogService;
        private MenuBarViewModel _menuBar;
        private Mock<IUserContext> _userContext;

        [TestInitialize]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceProfiles>();
                cfg.AddProfile<ViewModelProfiles>();
            });

            _mapper = new Mapper(mapperConfig);

            _userService = new();
            _navigationService = new();
            _dialogService = new();
            _menuBar = new MenuBarViewModel(_navigationService.Object, _dialogService.Object);
            _userContext = new();

            _loginViewModel = new LoginViewModel(_menuBar, _mapper, _userContext.Object, _navigationService.Object, _userService.Object);
        }

        [TestMethod]
        public void AttemptLoginWithExistingCredentialsShouldNavigateToHomeViewModel()
        {
            //Arrange
            var userId = Guid.NewGuid();
            var username = "TestUser21";
            var password = "password123";
            var user = new UserViewModel()
            {
                Username = username,
                Password = password
            };

            _loginViewModel.TempUser = user;

            _userService.Setup(x => x.Login(username, password)).Returns(new UserDto()
            {
                Id = userId,
                IsExistingUser = true,
                Username = username,
            });

            _userContext.SetupProperty(x => x.CurrentUser);

            //Act
            _loginViewModel.AttemptLoginCommand.Execute(null);

            //Assert
            _userService.Verify(x => x.Login(username, password));
            Assert.IsTrue(_userContext.Object.CurrentUser.Id == userId);
            Assert.IsTrue(_userContext.Object.CurrentUser.Username == username);
            _navigationService.Verify(x => x.NavigateToViewModel<HomeViewModel>(It.IsAny<Action>()));
        }

        [TestMethod]
        public void AttemptLoginWithNonExistingCredentialsShouldFailValidation()
        {
            //Arrange
            var userId = Guid.NewGuid();
            var username = "TestUser21";
            var password = "password123";
            var user = new UserViewModel()
            {
                Username = username,
                Password = password
            };

            _loginViewModel.TempUser = user;

            _userService.Setup(x => x.Login(username, password)).Returns(new UserDto(){});

            _userContext.SetupProperty(x => x.CurrentUser);

            //Act
            _loginViewModel.AttemptLoginCommand.Execute(null);

            //Assert
            _userService.Verify(x => x.Login(username, password));
            _userService.VerifyNoOtherCalls();
            _navigationService.VerifyNoOtherCalls();
            Assert.IsNull(_userContext.Object.CurrentUser);
            Assert.IsTrue(_loginViewModel.FeedBackText != "");
        }

        [DataRow("TestUser21", "passwor")]
        [DataRow("TestU", "password123")]
        [DataRow("TestUser21", "")]
        [DataRow("", "password123")]
        [DataRow("", "")]
        [DataTestMethod()]
        public void AttemptLoginWithInvalidCredentialsShouldFailValidation(string username, string password)
        {
            //Arramge
            var user = new UserViewModel()
            {
                Username = username,
                Password = password
            };

            _loginViewModel.TempUser = user;

            _userContext.SetupProperty(x => x.CurrentUser);

            //Act
            _loginViewModel.AttemptLoginCommand.Execute(null);

            //Assert
            _userService.VerifyNoOtherCalls();
            _navigationService.VerifyNoOtherCalls();
            Assert.IsNull(_userContext.Object.CurrentUser);
            Assert.IsTrue(user.HasErrors);
        }
    }
}
