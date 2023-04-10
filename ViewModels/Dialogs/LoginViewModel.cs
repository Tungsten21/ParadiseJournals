using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Navigation;

namespace ViewModels.Dialogs
{
    public partial class LoginViewModel : ObservableObject, IViewModel, IClosable
    {
        private INavigationService _navigationService;

        public Action CloseWindow { get; set; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void AttemptLogin()
        {
            _navigationService.NavigateToViewModel<HomeViewModel>();
            CloseWindow?.Invoke();
        }

    }
}
