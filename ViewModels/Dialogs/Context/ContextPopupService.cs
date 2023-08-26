using Common.Exceptions;
using CommunityToolkit.Mvvm.Messaging;
using ViewModels.Interfaces;
using ViewModels.Messages;

namespace ViewModels.Dialogs.Context
{
    public class ContextPopupService : IContextPopupService
    {
        private readonly IMessenger _messenger;
        private readonly IServiceProvider _serviceProvider;

        public ContextPopupService(IServiceProvider serviceProvider, IMessenger messenger)
        {
            _messenger = messenger;
            _serviceProvider = serviceProvider;
        }

        public void ShowPopup<TViewModel>(Action? action = null) where TViewModel : IViewModel
        {
            var _destViewModel = (IViewModel)_serviceProvider.GetService(typeof(TViewModel))
                ?? throw new ArgumentException("Passed in viewmodel " + typeof(TViewModel).FullName + " is not registered with DI.");

            action?.Invoke();

            _messenger.Send(new CreateContextPopupMessage(_destViewModel));
            _messenger.Send(new ToggleContextPopupVisibilityMessage(true));
        }

        public void ClosePopup()
        {
            _messenger.Send(new ToggleContextPopupVisibilityMessage(false));
        }

        
    }
}
