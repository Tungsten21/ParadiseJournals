using Common.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.User;

namespace ViewModels.Dialogs
{
    public partial class CreateNewUserViewModel : ObservableObject, IViewModel, IClosable
    {

        //Properties
        private readonly INavigationService _navigationService;
        private readonly IUserService _userService;

        [ObservableProperty]
        private UserViewModel _user = new();


        public Action CloseWindow { get; set; }

        [RelayCommand]
        private void AttemptRegister()
        {
            var userDto = new UserDto
            {
                FirstName = User.FirstName,
                EmailAddress = User.Email,
                Username = User.Username,
                Password = User.Password,
            };

            var registerResult = _userService.Register(userDto);

            if (!registerResult.Success)
            {
                //Display error messager
                return;
            }

            _navigationService.NavigateToViewModel<HomeViewModel>();
            CloseWindow?.Invoke();

        }

        //Commands

        //Constructors
        public CreateNewUserViewModel(INavigationService navigationService,
                                      IUserService userService)
        {
            _userService = userService;
            _navigationService = navigationService;
        }



        //Methods
    }
}
