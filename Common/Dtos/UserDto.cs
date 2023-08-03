using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public bool IsExistingUser { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }

        public UserDto()
        {
            
        }

        public UserDto(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
