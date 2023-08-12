using AutoMapper;
using Common.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Models;
using Services.Interfaces;
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
    public partial class CreateNewJournalViewModel : BaseViewModel, IViewModel, IClosable
    {


        //Properties
        private readonly IMapper _mapper;
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly IJournalService _journalService;

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
        public CreateNewJournalViewModel(IMapper mapper, IUserContext userContext, INavigationService navigationService, IMessenger messenger, IJournalService journalService) : base(userContext)
        {
            _mapper = mapper;
            _navigationService = navigationService;
            _messenger = messenger;
            _journalService = journalService;
        }

        //Methods
        private void CreateJournal()
        {
            //Eventually move to its own service input & output -> ServiceModels. Map -> ViewModel Models.
            var model = (JournalModel) JournalViewModel.CloneModel();
            DateTime startDate = model.StartDate;
            DateTime endDate = model.EndDate;

            ObservableCollection<JournalDayViewModel> journalDays = new();

            for(DateTime beginDate = startDate; beginDate <= endDate; beginDate = beginDate.AddDays(1))
            {
                var journalDay = new JournalDayViewModel() { ShortDateFormat = beginDate.ToShortDateString() };
                journalDays.Add(journalDay); 
            }

            JournalViewModel.Days = journalDays;

            var journalDto = _mapper.Map<JournalDto>(JournalViewModel.CloneModel());
            journalDto.OwnerId = _userContext.CurrentUser.Id;

            var result = _journalService.CreateJournal(journalDto);
        }
        
    }
}
