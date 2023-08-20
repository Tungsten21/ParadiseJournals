using AutoMapper;
using Common.Dtos;
using CommunityToolkit.Mvvm.Messaging;
using Data.Entities;
using Data.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using Services.Interfaces;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Tests.Services
{
    [TestClass()]
    public class UserServiceTests
    {
        private IUserService _userService;
        private Mock<IUserRepository> _userRepository;
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceProfiles>();
            });

            _mapper = new Mapper(mapperConfig);
            _userService = new UserService(_mapper, _userRepository.Object);
        }

        [TestMethod()]
        public void LoginWithValidCredentialsReturnsHydratedUserDto()
        {
            //Arange
            var userName = "TestUsername";
            var password = "password123";

            var userId = Guid.Parse("67ce7098-0dc3-4353-b493-765ad533fe41");
            _userRepository.Setup(x => x.Login(userName, password))
                .Returns(new ResultDto() { Success = true, Id = userId });

            var user = new User()
            {
                Id = userId,
                Username = userName,
                Password = password
            };
            _userRepository.Setup(x => x.GetUser(userId)).Returns(user);

            //Act
            var result = _userService.Login(userName, password);

            //Assert
            _userRepository.Verify(x => x.Login(userName, password));
            _userRepository.Verify(x => x.GetUser(userId));
            Assert.IsTrue(result.Id == userId);
            Assert.IsTrue(result.Username == userName);
            Assert.IsTrue(result.IsExistingUser == true);
        }


        [TestMethod()]
        public void LoginWithNonExistingCredentialsReturnsNonExistentUserDto()
        {
            //Arrange
            var userName = "TestUsername";
            var password = "password123";

            _userRepository.Setup(x => x.Login(userName, password)).Returns(new ResultDto() { Success = false });

            //Act
            var result = _userService.Login(userName, password);

            //Assert
            _userRepository.Verify(x => x.Login(userName, password));
            Assert.IsFalse(result.IsExistingUser);
        }

        [TestMethod()]
        public void RegisterWithNonExistingCredentialsReturnsHydratedResultDto()
        {
            //Arrange
            var userDto = new UserDto()
            {
                Username = "TestUsername",
                Password = "password123",
                FirstName = "Test",
                EmailAddress = "test@gmail.com"
            };

            var userId = Guid.Parse("67ce7098-0dc3-4353-b493-765ad533fe41");
            _userRepository.Setup(x => x.Register(userDto)).Returns(new ResultDto() { Id = userId, Success = true });

            //Act
            var result = _userService.Register(userDto);

            //Assert
            _userRepository.Verify(x => x.DoesUserAlreadyExist("TestUsername"));
            _userRepository.Verify(x => x.Register(userDto));
            Assert.IsTrue(result.Id == userId);
            Assert.IsTrue(result.Success == true);
        }

        [TestMethod()]
        public void RegisterWithExistingCredentialsReturnsFalseSuccessResultDto()
        {
            //Arrange
            var userDto = new UserDto()
            {
                Username = "TestUsername",
                Password = "password123",
                FirstName = "Test",
                EmailAddress = "test@gmail.com"
            };

            _userRepository.Setup(x => x.Register(userDto)).Returns(new ResultDto() { Success = false });
            _userRepository.Setup(x => x.DoesUserAlreadyExist("TestUsername")).Returns(true);

            //Act
            var result = _userService.Register(userDto);

            //Assert
            _userRepository.Verify(x => x.DoesUserAlreadyExist("TestUsername"));
            _userRepository.VerifyNoOtherCalls();
            Assert.IsFalse(result.Success);
        }
    }

}