using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Dialogs;
using ViewModels.Interfaces;

namespace ViewModels.User
{
    public class UserContext : IUserContext
    {
        private IUserService _userService;

        public UserModel CurrentUser { get; set; }

        public UserContext(IUserService userService) 
        {
            _userService = userService;
        }
    }
}
