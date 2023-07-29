using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Messages;

namespace ViewModels
{
    public partial class ViewWishListViewModel : ObservableObject, IViewModel
    {
        //Properties
        private IMessenger _messenger;

        [ObservableProperty]
        private WishListViewModel _wishListViewModel;
        //Commands

        //Constructors
        public ViewWishListViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            _messenger.Register<ItemCreatedMessage>(this, (r, m) => SetWishList(m.Value));
        }

        //Methods
        private void SetWishList(object value)
        {
            if (value is WishListModel model)
                WishListViewModel = new WishListViewModel(model);
        }
    }
}
