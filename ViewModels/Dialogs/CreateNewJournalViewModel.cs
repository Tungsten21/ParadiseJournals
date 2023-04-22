using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace ViewModels.Dialogs
{
    public partial class CreateNewJournalViewModel : ObservableObject, IViewModel, IClosable
    {
        //Properties
        private readonly INavigationService _navigationService;

        public Action CloseWindow { get; set; }
        //Constructors
        public CreateNewJournalViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //Commands
        [RelayCommand]
        private void AttemptToCreateJournal()
        {
           //TODO: Add validation to ensure necessaery fields have valid input
           if(true)
            {
                CloseWindwowAndProgress();
            }
        }

        //Methods
        private void CloseWindwowAndProgress()
        {
            CloseWindow?.Invoke();
            _navigationService.NavigateToViewModel<JournalHomeViewModel>();

        }

    }
}
