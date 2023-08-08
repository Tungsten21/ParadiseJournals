using AutoMapper;
using Common.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Models;
using Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ViewModels.Controls;
using ViewModels.Interfaces;
using ViewModels.Validation;
using Common.Extensions;
using ViewModels.User;

namespace ViewModels.Dialogs
{
    public partial class LoginViewModel : BaseViewModel , IViewModel, IClosable
    {
        //Properties
        private INavigationService _navigationService;
        private IUserService _userService;
        private readonly MenuBarViewModel _menuBar;
        private readonly IMapper _mapper;

        [ObservableProperty]
        private UserViewModel _tempUser = new();

        [ObservableProperty]
        private string _feedBackText;

        public Action CloseWindow { get; set; }

        //Commands
        [RelayCommand]
        private void AttemptLogin()
        {
            if (!TempUser.IsUsernameAndPasswordValid())
            {
                return;
            }

            var user = _userService.Login(TempUser.Username, TempUser.Password);

            if (!user.IsExistingUser)
            {
                FeedBackText = "An account with the inputted credentials could not be found.";
                return;
            }

            var userModel = _mapper.Map<UserModel>(user);

            UserContext.CurrentUser = userModel;

            _navigationService.NavigateToViewModel<HomeViewModel>(() => _menuBar.IsMenuBarVisible = true);
            CloseWindow?.Invoke();
        }

        

        //Constructors

        public LoginViewModel(MenuBarViewModel menu,
                              IMapper mapper,
                              IUserContext userContext, 
                              INavigationService navigationService, 
                              IUserService userService) : base(userContext)
        {
            _menuBar = menu;
            _mapper = mapper;
            _userService = userService;
            _navigationService = navigationService;
            
        }

        //Methods
    }
}
