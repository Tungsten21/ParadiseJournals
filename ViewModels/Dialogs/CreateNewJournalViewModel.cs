using AutoMapper;
using AutoMapper.Configuration.Conventions;
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
using System.Net.Http.Headers;
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
                var journalDto = CreateJournal();

                if (journalDto.Id != Guid.Empty)
                {
                    var model = _mapper.Map<JournalModel>(journalDto);

                    _navigationService.NavigateToViewModel<ViewJournalViewModel>(
                        () => _messenger.Send(new ItemCreatedMessage(model))
                    );

                    CloseWindow?.Invoke();
                }
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
        private JournalDto CreateJournal()
        {
            var model = (JournalModel)JournalViewModel.CloneModel();
            var startDate = model.StartDate;
            var endDate = model.EndDate;
            var totalDays = (int)(endDate - startDate).TotalDays + 1;


            var journalDto = _mapper.Map<JournalDto>(JournalViewModel.CloneModel());
            journalDto.OwnerId = _userContext.CurrentUser.Id;
            journalDto.TotalDays = totalDays;

            var result = _journalService.CreateJournal(journalDto);

            var getResult = _journalService.GetJournal(result.Id);

            return getResult;
        }

    }
}
