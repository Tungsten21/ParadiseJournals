using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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
            if (JournalViewModel.IsValid())
            {
                CreateJournal();

                _navigationService.NavigateToViewModel<ViewJournalViewModel>
                    (() => _messenger.Send(new ItemCreatedMessage(JournalViewModel.CloneModel())));

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
        private void CreateJournal()
        {
            //Eventually move to its own service input & output -> ServiceModels. Map -> ViewModel Models.
            var model = (JournalModel) JournalViewModel.CloneModel();
            DateOnly startDate = model.StartDate;
            DateOnly endDate = model.EndDate;

            ObservableCollection<JournalDayViewModel> journalDays = new();

            for(DateOnly beginDate = startDate; beginDate <= endDate; beginDate = beginDate.AddDays(1))
            {
                var journalDay = new JournalDayViewModel() { ShortDateFormat = beginDate.ToShortDateString() };
                journalDays.Add(journalDay); 
            }

            JournalViewModel.Days = journalDays;
        }
        
    }
}
