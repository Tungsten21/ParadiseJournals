using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Messages;
using ViewModels.Navigation;

namespace ViewModels.Dialogs
{
    public partial class CreateNewWishListViewModel : ObservableObject, IViewModel, IClosable
    {
        //Properties
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;

        [ObservableProperty]
        private WishListViewModel _wishListViewModel = new();

        public Action CloseWindow { get; set; }

        //Commands
        [RelayCommand]
        private void AttemptToCreateWishList()
        {
            //TODO: Add validation to ensure necessaery fields have valid input
            if (!WishListViewModel.HasErrors)
            {
                _navigationService.NavigateToViewModel<ViewWishListViewModel>
                    (() => _messenger.Send(new ItemCreatedMessage(WishListViewModel.Model.Clone())));
                CloseWindow?.Invoke();
            }
        }

        //Constructors
        public CreateNewWishListViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
        }

        //Methods
        
    }
}
