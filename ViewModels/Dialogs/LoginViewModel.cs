using AutoMapper;
using Common.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Models;
using Services.Interfaces;
using ViewModels.Controls;
using ViewModels.Interfaces;

namespace ViewModels.Dialogs
{
    public partial class LoginViewModel : ObservableObject, IViewModel, IClosable
    {
        //Properties
        private INavigationService _navigationService;
        private IUserContext _userContext;
        private IUserService _userService;
        private readonly MenuBarViewModel _menuBar;
        private readonly IMapper _mapper;

        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private string _feedBackText;

        public Action CloseWindow { get; set; }

        //Commands
        [RelayCommand]
        private void AttemptLogin()
        {

            var user = _userService.Login(UserName, Password);

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
