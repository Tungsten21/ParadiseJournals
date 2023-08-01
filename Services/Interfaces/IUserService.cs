using Common.Dtos;

namespace Services.Interfaces
{
    public interface IUserService
    {
        UserDto Login(string username, string password);

        ResultDto Register(UserDto userDto);


    }
}
