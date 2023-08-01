using Common.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        ResultDto Login(string username, string password);
        ResultDto Register(UserDto userDto);
        User? GetUser(Guid id);
        bool DoesUserAlreadyExist(string username);
        
    }
}
