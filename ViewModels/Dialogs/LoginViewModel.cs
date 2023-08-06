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

namespace ViewModels.Dialogs
{
    public partial class LoginViewModel : ValidatableViewModel, IViewModel, IClosable
    {
        //Properties
        private INavigationService _navigationService;
        private IUserContext _userContext;
        private IUserService _userService;
        private readonly MenuBarViewModel _menuBar;
        private readonly IMapper _mapper;
        private readonly UserDto _tempUser;

        [Required]
        [MinLength(6)]
        public string Username
        {
            get { return _userName; }
            set
            {
                _tempUser.Username.Clear();
                if (SetProperty(ref _userName, value, true) && GetErrors(nameof(Username)).Count() == 0)
                {
                    _tempUser.Username = value;
                }
            }
        }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string Password
        {
            get { return _password; }
            set
            {
                _tempUser.Password.Clear();
                if (SetProperty(ref _password, value, true) && GetErrors(nameof(Password)).Count() == 0)
                {
                    _tempUser.Password = value;
                }
            }
        }
        [ObservableProperty]
        private string _feedBackText;
        private string _userName;
        private string _password;

        public Action CloseWindow { get; set; }

        //Commands
        [RelayCommand]
        private void AttemptLogin()
        {

            var user = _userService.Login(_tempUser.Username, _tempUser.Password);

            if (!user.IsExistingUser)
            {
                FeedBackText = "An account with the inputted credentials could not be found.";
                return;
            }

            var userModel = _mapper.Map<UserModel>(user);

            _userContext.CurrentUser = userModel;

            _navigationService.NavigateToViewModel<HomeViewModel>(() => _menuBar.IsMenuBarVisible = true);
            CloseWindow?.Invoke();
        }

        

        //Constructors

        public LoginViewModel(MenuBarViewModel menu,
                              IMapper mapper,
                              IUserContext userContext, 
                              INavigationService navigationService, 
                              IUserService userService)
        {
            _menuBar = menu;
            _mapper = mapper;
            _userContext = userContext;
            _userService = userService;
            _navigationService = navigationService;
            
        }

        //Methods
    }
}
