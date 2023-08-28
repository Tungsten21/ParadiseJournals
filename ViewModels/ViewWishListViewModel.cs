using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using ViewModels.Dialogs.Context;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Messages;

namespace ViewModels
{
    public partial class ViewWishListViewModel : ObservableObject, IViewModel
    {
        //Properties
        private readonly IMessenger _messenger;
        private readonly IContextPopupService _contextPopupService;

        [ObservableProperty]
        private WishListViewModel _wishListViewModel;

        //Commands
        [RelayCommand]
        private void ShowAddItemContextPopup(string senderItem) // Convert to enum before receiving
        {
            switch (senderItem)
            {
                case "Accommodations":
                    _contextPopupService.ShowPopup<AddWishlistAccommodationViewModel>();
                    break;
                case "Locations":
                    _contextPopupService.ShowPopup<AddWishlistLocationViewModel>();
                    break;
                case "Notes":
                    _contextPopupService.ShowPopup<AddWishlistNoteViewModel>();
                    break;
                default: throw new ArgumentException("Unsupported Wishlist item type");
            }
        }

        //Constructors
        public ViewWishListViewModel(IMessenger messenger, IContextPopupService contextPopupService)
        {
            _messenger = messenger;
            _contextPopupService = contextPopupService;
            _messenger.Register<ItemCreatedMessage>(this, (r, m) => SetWishList(m.Value));
            _messenger.Register<ItemClickedMessage>(this, (r, m) => SetWishList(m.Value));
        }

        //Methods
        private void SetWishList(IModel value)
        {
            if (value is WishListModel model)
                WishListViewModel = new WishListViewModel(model);
        }
    }
}
