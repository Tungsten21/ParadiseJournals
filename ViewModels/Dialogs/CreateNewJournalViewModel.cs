using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Messages;

namespace ViewModels.Dialogs
{
    public partial class CreateNewJournalViewModel : ObservableObject, IViewModel, IClosable
    {
        //Properties
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;

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
                _navigationService.NavigateToViewModel<WishListHomeViewModel>
                    (() => _messenger.Send(new ItemCreatedMessage(new JournalViewModel(_journalViewModel))));
                CloseWindow?.Invoke();
            }
        }

        //Constructors
        public CreateNewJournalViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
        }

        //Methods
        
    }
}
