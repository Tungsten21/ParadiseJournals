using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Models;
using Models.Interfaces;
using System.Collections.ObjectModel;
using ViewModels.Dialogs;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Messages;

namespace ViewModels
{
    public partial class HomeViewModel : ObservableObject, IViewModel
    {
        //Properties
        private readonly IDialogService _dialogService;
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        private readonly IUserContext _userContext;

        [ObservableProperty]
        private ItemCache _itemCache;

        //Commands
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
        public HomeViewModel(IUserContext userContext, ItemCache itemCache, IDialogService dialogService, IMessenger messenger, 
                             INavigationService navigationService)
        {
            _dialogService = dialogService;
            _messenger = messenger;
            _navigationService = navigationService;
            _userContext = userContext;

            itemCache.ItemClickedEvent += OnItemClick;
            ItemCache = itemCache;

            
        }

        //Methods
        private void OnItemClick(object? sender, EventArgs e)
        {
            var vm = sender as IClonableModel;

            switch (vm)
            {
                case JournalViewModel journal:
                    _navigationService.NavigateToViewModel<ViewJournalViewModel>(
                                            () => _messenger.Send(new ItemClickedMessage(journal.CloneModel()))
                                            );
                    break;
            }
        }
    }
}
