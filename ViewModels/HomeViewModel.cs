using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ViewModels.Dialogs;
using ViewModels.Interfaces;

namespace ViewModels
{
    public partial class HomeViewModel : ObservableObject, IViewModel
    {
        //Properties
        private readonly IDialogService _dialogService;

        //Constructors
        public HomeViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

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

        //Methods
    }
}
