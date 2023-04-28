using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Navigation;

namespace ViewModels.Dialogs
{
    public partial class CreateNewWishListViewModel : ObservableObject, IViewModel, IClosable
    {
        //Properties
        private readonly INavigationService _navigationService;
        private readonly HomeViewModel _homeViewModel;

        [ObservableProperty]
        private WishListViewModel _wishListViewModel = new();

        public Action CloseWindow { get; set; }

        //Commands
        [RelayCommand]
        private void AttemptToCreateWishList()
        {
            //TODO: Add validation to ensure necessaery fields have valid input
            if (true)
            {
                _navigationService.NavigateToViewModel<WishListHomeViewModel>
                    (() => AddWishlistToHomeViewModel(_homeViewModel));
                CloseWindow?.Invoke();
            }
        }

        //Constructors
        public CreateNewWishListViewModel(INavigationService navigationService, HomeViewModel homeViewModel)
        {
            _navigationService = navigationService;
            _homeViewModel = homeViewModel;
        }

        //Methods
        private void AddWishlistToHomeViewModel(HomeViewModel homeViewModel)
        {
            homeViewModel.UserWishLists.Add(new(WishListViewModel));
            if(!homeViewModel.AtLeastOneWishlist)
                homeViewModel.AtLeastOneWishlist = true;
        }
    }
}
