using AutoMapper;
using Common.Dtos;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository : IUserRepository
    {
        private IMapper _mapper;
        private ApplicationDbContext _context;

        public UserRepository(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public bool DoesUserAlreadyExist(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            return user != null;
        }

        public User? GetUser(Guid id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id && user.Deleted == false);
        }

        public ResultDto Login(string username, string password)
        {
            var result = new ResultDto();

            var user = _context.Users.FirstOrDefault(user => user.Username == username &&
                                                             user.Password == password &&
                                                             user.Deleted == false);

            if (user == null)
            {
                return result;
            }

            result.Id = user.Id;
            result.Success = true;

            return result;
        }

        public ResultDto Register(UserDto userDto)
        {
            var result = new ResultDto();

            var userAlredyExists = _context.Users.FirstOrDefault(user => user.Username == userDto.Username) is not null;

            if (userAlredyExists)
            {
                return result;
            }

            var userEntity = _mapper.Map<User>(userDto);

            _context.Users.Add(userEntity);
            _context.SaveChanges();

            var userId = userEntity.Id;

            result.Id = userId;
            result.Success = true;
            return result;
        }
    }
}
