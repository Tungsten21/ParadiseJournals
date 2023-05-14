using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
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
        public HomeViewModel(IDialogService dialogService, IMessenger messenger)
        {
            _dialogService = dialogService;
            _messenger = messenger;

            _messenger.Register<ItemCreatedMessage>(this, (r, m) => AddItemOnReceived(m.Value));
        }

        //Methods
        private void AddItemOnReceived(ICreatableItem item)
        {
            switch (item)
            {
                case JournalViewModel:
                    UserJournals.Add((JournalViewModel) item);
                    if(!AtLeastOneJournal)
                        AtLeastOneJournal = true;
                    break;
                case WishListViewModel:
                    UserWishLists.Add((WishListViewModel) item);
                    if (!AtLeastOneWishList)
                        AtLeastOneWishList = true;
                    break;

            }
        }
    }
}
