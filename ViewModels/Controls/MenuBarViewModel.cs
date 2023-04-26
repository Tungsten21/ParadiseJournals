using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Dialogs;
using ViewModels.Interfaces;

namespace ViewModels.Controls
{
    public partial class MenuBarViewModel : ObservableObject, IViewModel
    {
        //Properties
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;


        [ObservableProperty]
        private bool _isMenuBarVisible;

        //Commands
        [RelayCommand]
        private void NavigateToHomeViewModel()
        {
            _navigationService.NavigateToViewModel<HomeViewModel>();
        }

        [RelayCommand]
        private void OpenCreateNewJournalDialog()
        {
            _dialogService.ShowDialog<CreateNewJournalViewModel>("Create New Journal", "Large");
        }

        [RelayCommand]
        private void OpenCreateNewWishListDialog()
        {
            _dialogService.ShowDialog<CreateNewWishListViewModel>("Create New Wishlist", "Large");
        }

        //Constructors
        public MenuBarViewModel(INavigationService navigationService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        //Methods
    }
}
