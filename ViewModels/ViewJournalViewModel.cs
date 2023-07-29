using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Models;
using Models.Interfaces;
using ViewModels.Interfaces;
using ViewModels.Items;
using ViewModels.Messages;

namespace ViewModels
{
    public partial class ViewJournalViewModel : ObservableObject, IViewModel
    {
        private readonly IMessenger _messenger;

        //Properties
        [ObservableProperty]
        private JournalViewModel _journalViewModel;

        //Commands

        //Constructors
        public ViewJournalViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            _messenger.Register<ItemCreatedMessage>(this, (r, m) => SetJournal(m.Value));
            _messenger.Register<ItemClickedMessage>(this, (r, m) => SetJournal(m.Value));
        }

        //Methods
        private void SetJournal(IModel value)
        {
            if (value is JournalModel model)
                JournalViewModel = new JournalViewModel(model);
        }
    }
}
