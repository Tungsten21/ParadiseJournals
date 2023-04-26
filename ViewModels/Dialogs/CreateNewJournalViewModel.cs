using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Items;

namespace ViewModels.Dialogs
{
    public partial class CreateNewJournalViewModel : ObservableObject, IViewModel, IClosable
    {
        //Properties
        private readonly INavigationService _navigationService;
        private readonly HomeViewModel _homeViewModel;

        [ObservableProperty]
        private JournalViewModel _journalViewModel = new();

        public Action CloseWindow { get; set; }

        //Commands
        [RelayCommand]
        private void AttemptToCreateJournal()
        {
            //TODO: Add validation to ensure necessaery fields have valid input
            if (true)
            {
                _navigationService.NavigateToViewModel<JournalHomeViewModel>
                    (() => AddJournalToHomeViewModel(_homeViewModel));
                CloseWindow?.Invoke();
            }
        }

        //Constructors
        public CreateNewJournalViewModel(INavigationService navigationService, HomeViewModel homeViewModel)
        {
            _navigationService = navigationService;
            _homeViewModel = homeViewModel;
        }

        //Methods
        private void AddJournalToHomeViewModel(HomeViewModel homeViewModel)
        {
            homeViewModel.UserJournals.Add(new(JournalViewModel));
            if (!homeViewModel.AtLeastOneJournal)
                homeViewModel.AtLeastOneJournal = true;
        }
    }
}
