using AutoMapper;
using Common.Dtos;
using Data.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public UserDto Login(string username, string password)
        {
            var userDto = new UserDto();

            var loginResult = _userRepository.Login(username, password);

            if (!loginResult.Success)
            {
                return userDto;
            }
            
            var user = _userRepository.GetUser(loginResult.Id);

            _mapper.Map(user, userDto);
            userDto.IsExistingUser = true;

            return userDto;

        }

        public ResultDto Register(UserDto userDto)
        {
            var result = new ResultDto();

            if (_userRepository.DoesUserAlreadyExist(userDto.Username))
            {
                result.Success = false;
                result.Message = "Account alreayd in use (CHANGE)";
                return result;
            }

            result = _userRepository.Register(userDto);

            if(!result.Success)
            {
                result.Message = "ERROR REGISTERING";
            }

            return result;
        }
    }
}
