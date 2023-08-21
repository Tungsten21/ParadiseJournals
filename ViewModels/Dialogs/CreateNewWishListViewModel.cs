using AutoMapper;
using Common.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Data.Entities;
using Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Messages;
using ViewModels.Navigation;
using ViewModels.User;

namespace ViewModels.Dialogs
{
    public partial class CreateNewWishListViewModel : ObservableObject, IViewModel, IClosable
    {
        //Properties
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly IWishlistService _wishlistService;
        private IMapper _mapper;
        private readonly IUserContext _userContext;

        [ObservableProperty]
        private WishListViewModel _wishListViewModel = new();

        public Action CloseWindow { get; set; }

        //Commands
        [RelayCommand]
        private void AttemptToCreateWishList()
        {
            //TODO: Add validation to ensure necessaery fields have valid input
            if (WishListViewModel.IsValid())
            {
                var wishListDto = CreateWishList();

                if (wishListDto.Id != Guid.Empty)
                {
                    var model = _mapper.Map<WishListModel>(wishListDto);

                    _navigationService.NavigateToViewModel<ViewWishListViewModel>(
                        () => _messenger.Send(new ItemCreatedMessage(model))
                    );

                    CloseWindow?.Invoke();
                }
            }
        }

        //Constructors
        public CreateNewWishListViewModel(IMapper mapper, IUserContext userContext, INavigationService navigationService, IMessenger messenger, IWishlistService wishlistService)
        {
            _mapper = mapper;
            _userContext = userContext;
            _navigationService = navigationService;
            _messenger = messenger;
            _wishlistService = wishlistService;
        }

        public CreateNewWishListViewModel()
        {
            
        }

        private WishlistDto CreateWishList()
        {
            var model = (WishListModel)WishListViewModel.CloneModel();

            var wishListDto = _mapper.Map<WishlistDto>(WishListViewModel.CloneModel());
            wishListDto.OwnerId = _userContext.CurrentUser.Id;

            var result = _wishlistService.CreateWishlist(wishListDto);

            var getResult = _wishlistService.GetWishlist(result.Id);

            return getResult;

        }
        //Methods
        
    }
}
