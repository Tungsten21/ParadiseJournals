using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using ViewModels.Dialogs;
using ViewModels.Interfaces;

namespace ViewModels
{
    public partial class EntryViewModel : ObservableObject, IViewModel
    {
        //Properties
        private IDialogService _dialogService;

        //Commands
        [RelayCommand]
        private void OpenLoginDialog()
        {
            _dialogService.ShowDialog<LoginViewModel>("Login", "Large");
        }

        [RelayCommand]
        private void OpenCreateNewUserDialog()
        {
            _dialogService.ShowDialog<CreateNewUserViewModel>("Create New User", "Large");
        }

        //Constructors
        public EntryViewModel(IDialogService dialogService)
        {
           _dialogService = dialogService;
        }

        //Methods
    }
}
