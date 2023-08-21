using AutoMapper;
using Common.Dtos;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
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
    public class CreateNewUserViewModelTests
    {
        private CreateNewUserViewModel _createNewUserViewModel;
        private IMapper _mapper;
        private MenuBarViewModel _menuBar;
        private Mock<IUserService> _userSerivce;
        private Mock<INavigationService> _navigationService;
        private Mock<IDialogService> _dialogService;
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
            _userSerivce = new();
            _navigationService = new();
            _dialogService = new();
            _userContext = new();
            _menuBar = new(_navigationService.Object, _dialogService.Object);

            _createNewUserViewModel = new CreateNewUserViewModel(_menuBar, _mapper, _navigationService.Object,
                                                                 _userContext.Object, _userSerivce.Object);
        }

        [TestMethod()]
        public void AttemptRegisterWithValidCredentialsShouldNavigateToHomeViewModel()
        {
            //Arrange
            var user = new UserViewModel()
            {
                Email = "test@gmail.com",
                Username = "TestUser21",
                Password = "password",
                ConfirmPassword = "password",
                FirstName = "Test"
            };

            _createNewUserViewModel.TempUser = user;

            _userSerivce.Setup(x => x.Register(It.IsAny<UserDto>())).Returns(new ResultDto() { Success = true});

            //Act
            _createNewUserViewModel.AttemptRegisterCommand.Execute(null);

            //Assert
            _userSerivce.Verify(x => x.Register(It.IsAny<UserDto>()));
            _navigationService.Verify(x => x.NavigateToViewModel<HomeViewModel>(
                It.IsAny<Action>()
                ));
        }

        [DataRow("testgmail.com", "TestUser21", "password", "password", "Test")]
        [DataRow("test@gmail.com", "TestU", "password", "password", "Test")]
        [DataRow("test@gmail.com", "TestUser21", "passwo", "passwo", "Test")]
        [DataRow("test@gmail.com", "TestUser21", "password123", "password12", "Test")]
        [DataRow("test@gmail.com", "TestUser21", "password12", "password123", "Test")]
        [DataTestMethod()]
        public void AttemptRegisterWithInvalidCredentialsShouldFailValidation(string email, string username, string password, string confirmPassword, string firstName)
        {
            //Arrange
            var user = new UserViewModel()
            {
                Email = email,
                Username = username,
                Password = password,
                ConfirmPassword = confirmPassword,
                FirstName = firstName
            };

            _createNewUserViewModel.TempUser = user;

            //Act
            _createNewUserViewModel.AttemptRegisterCommand.Execute(null);

            //Assert
            Assert.IsTrue(user.HasErrors);
            _userSerivce.VerifyNoOtherCalls();
        }
    }
}
