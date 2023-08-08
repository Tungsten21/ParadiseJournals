﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class HomeViewModel : BaseViewModel, IViewModel
    {
        //Properties
        private readonly IDialogService _dialogService;
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        [NotifyPropertyChangedFor(nameof(NoItemsFound))]
        [NotifyPropertyChangedFor(nameof(NoWishListsButJournalFound))]
        [ObservableProperty]
        private bool _atLeastOneJournal;

        [NotifyPropertyChangedFor(nameof(NoItemsFound))]
        [NotifyPropertyChangedFor(nameof(NoJournalsButWishListFound))]
        [ObservableProperty]
        private bool _atLeastOneWishList;

        public bool NoJournalsButWishListFound => AtLeastOneWishList && !AtLeastOneJournal;

        public bool NoWishListsButJournalFound => !AtLeastOneWishList && AtLeastOneJournal;

        public bool NoItemsFound => !AtLeastOneJournal && !AtLeastOneWishList;

        public ObservableCollection<JournalViewModel> UserJournals { get; set; } = new();
        public ObservableCollection<WishListViewModel> UserWishLists { get; set; } = new();

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
        public HomeViewModel(IUserContext userContext, IDialogService dialogService, IMessenger messenger, INavigationService navigationService) : base(userContext)
        {
            _dialogService = dialogService;
            _messenger = messenger;
            _navigationService = navigationService;

            _messenger.Register<ItemCreatedMessage>(this, (r, m) => AddItemOnReceived(m.Value));
        }

        //Methods
        private void AddItemOnReceived(IModel item)
        {
            switch (item)
            {
                case JournalModel journal:

                    var journalVM = new JournalViewModel(journal);
                    journalVM.JournalItemClickedEvent += OnItemClick;
                    UserJournals.Add(journalVM);
                    if(!AtLeastOneJournal)
                        AtLeastOneJournal = true;
                    
                    break;
                case WishListModel wishList:

                    var wishListVM = new WishListViewModel(wishList);
                    //wishListVM.WishListItemClickedEvent = ...
                    UserWishLists.Add(wishListVM);
                    if (!AtLeastOneWishList)
                        AtLeastOneWishList = true;
                    break;

            }

        }

        private void OnItemClick(object? sender, EventArgs e)
        {
            var vm = sender as IClonableModel;

            switch (vm)
            {
                case JournalViewModel journal:
                    _messenger.Send(new ItemClickedMessage(journal.CloneModel()));
                    _navigationService.NavigateToViewModel<ViewJournalViewModel>();
                    break;
            }
        }
    }
}
