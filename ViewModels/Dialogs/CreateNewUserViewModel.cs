﻿using Common.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Services.Interfaces;
using ViewModels.Controls;
using ViewModels.Interfaces;
using ViewModels.User;

namespace ViewModels.Dialogs
{
    public partial class CreateNewUserViewModel : BaseViewModel, IViewModel, IClosable
    {

        //Properties
        private readonly INavigationService _navigationService;
        private readonly MenuBarViewModel _menuBar;
        private readonly IUserService _userService;

        [ObservableProperty]
        private UserViewModel _tempUser = new();

        [ObservableProperty]
        private string _registerFeedbackText;



        public Action CloseWindow { get; set; }

        [RelayCommand]
        private void AttemptRegister()
        {
            if (!TempUser.IsValid())
            {
                return;
            }

            var userDto = new UserDto()
            {
                FirstName = TempUser.FirstName,
                EmailAddress = TempUser.Email,
                Username = TempUser.Username,
                Password = TempUser.Password,
            };
            
            var registerResult = _userService.Register(userDto);

            if (!registerResult.Success)
            {
                RegisterFeedbackText = registerResult.Message;
                return;
            }

            _navigationService.NavigateToViewModel<HomeViewModel>(() => _menuBar.IsMenuBarVisible = true);
            CloseWindow?.Invoke();
        }

        //Commands

        //Constructors
        public CreateNewUserViewModel(MenuBarViewModel menu, INavigationService navigationService,
                                      IUserContext userContext, IUserService userService) : base(userContext)
        {
            _menuBar = menu;
            _userService = userService;
            _navigationService = navigationService;
        }



        //Methods
    }
}
