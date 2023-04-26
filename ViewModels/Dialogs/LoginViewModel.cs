using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ViewModels.Controls;
using ViewModels.Interfaces;

namespace ViewModels.Dialogs
{
    public partial class LoginViewModel : ObservableObject, IViewModel, IClosable
    {
        //Properties
        private INavigationService _navigationService;
        private readonly MenuBarViewModel _menuBar;

        public Action CloseWindow { get; set; }

        //Commands
        [RelayCommand]
        private void AttemptLogin()
        {
            _navigationService.NavigateToViewModel<HomeViewModel>(() => _menuBar.IsMenuBarVisible = true);
            CloseWindow?.Invoke();
        }

        //Constructors
        public LoginViewModel(INavigationService navigationService, MenuBarViewModel menu)
        {
            _navigationService = navigationService;
            _menuBar = menu;
        }

        //Methods
    }
}
