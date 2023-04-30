using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ViewModels.Dialogs;
using ViewModels.Interfaces;
using ViewModels.Items;

namespace ViewModels
{
    public partial class HomeViewModel : ObservableObject, IViewModel
    {
        //Properties
        private readonly IDialogService _dialogService;

        [NotifyPropertyChangedFor(nameof(NoItemsDetected))]
        [NotifyPropertyChangedFor(nameof(NoWishListsFound))]
        [ObservableProperty]
        private bool _atLeastOneJournal;

        [NotifyPropertyChangedFor(nameof(NoItemsDetected))]
        [NotifyPropertyChangedFor(nameof(NoJournalsFound))]
        [ObservableProperty]
        private bool _atLeastOneWishList;

        public bool NoJournalsFound => AtLeastOneWishList && !AtLeastOneJournal;

        public bool NoWishListsFound => !AtLeastOneWishList && AtLeastOneJournal;

        public bool NoItemsDetected => !AtLeastOneJournal && !AtLeastOneWishList;

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
        public HomeViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        //Methods
    }
}
